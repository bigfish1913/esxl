using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esxl.Help
{
    internal class Updater
    {
        public static async Task<ReleaseInfo?> CheckUpdateAsync()
        {
            string? currentVersion = Config.GetValueByKey("Version");
            using HttpClient client = new();
            string apiUrl = "https://gitee.com/api/v5/repos/laofublog/esxl/releases?access_token=da63399fc78bb7e9df48a660eab43d42&page=1&per_page=20&direction=desc";
            try
            {
                var response = await client.GetStringAsync(apiUrl);

                // Fix for CS8600: Ensure the deserialization result is checked for null
                ReleaseInfo[]? releaseList = JsonConvert.DeserializeObject<ReleaseInfo[]>(response);
                if (releaseList == null || releaseList.Length == 0)
                {
                    return null;
                }
                ReleaseInfo? release = releaseList[0];
                string latestVersion = release.TagName;
                if (string.IsNullOrEmpty(currentVersion))
                {
                    return release;
                }
                if (Version.Parse(latestVersion) <= Version.Parse(currentVersion))
                {
                    return null;
                }

                return release;
            }
            catch
            {
                // If update check fails, silently return null
                return null;
            }
        }

        public static async Task<bool> DownloadAndExtractAsync(string downloadUrl) 
        {
            string tempDir = ".\\Update";
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            string zipPath = Path.Combine(tempDir, "update.zip");

            try
            {
                // 下载ZIP包
                using (HttpClient client = new HttpClient())
                using (var stream = await client.GetStreamAsync(downloadUrl))
                using (var fileStream = File.Create(zipPath))
                {
                    await stream.CopyToAsync(fileStream);
                }

                if (!File.Exists(zipPath))
                {
                    return false;
                }
                
                // Extract to a temporary directory first
                string tempExtractDir = Path.Combine(tempDir, "extracted");
                if (Directory.Exists(tempExtractDir))
                {
                    Directory.Delete(tempExtractDir, true);
                }
                Directory.CreateDirectory(tempExtractDir);
                
                ZipFile.ExtractToDirectory(zipPath, tempExtractDir, overwriteFiles: true);
                
                // Move files to application directory
                foreach (var file in Directory.GetFiles(tempExtractDir))
                {
                    string destFile = Path.Combine(Application.StartupPath, Path.GetFileName(file));
                    File.Copy(file, destFile, true);
                }
                
                // Clean up
                Directory.Delete(tempDir, true);
                
                return true;
            }
            catch
            {
                // Clean up on failure
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
                return false;
            }
        }
        public static void UpdateVersion(string newVersion)
        { 
            Config.SetValueByKey("Version", newVersion);
        }

        public static void RestartApplication()
        {
            
            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }
    }
}
