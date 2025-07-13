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
            var response = await client.GetStringAsync(apiUrl);

            // Fix for CS8600: Ensure the deserialization result is checked for null
            ReleaseInfo[]? releaseList = JsonConvert.DeserializeObject<ReleaseInfo[]>(response);
            if (releaseList == null|| releaseList.Length == 0)
            {
                return null;
            }
            ReleaseInfo? release = releaseList[0];
            string latestVersion = release.TagName;
            if (string.IsNullOrEmpty(currentVersion))
            {
                return release;
            }
            if(Version.Parse(latestVersion) <= Version.Parse(currentVersion))
            {
                return null;
            }

            return release;
        }

        public static async Task<bool> DownloadAndExtractAsync(string downloadUrl) 
        {
            string tempDir = ".\\Update";
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            string zipPath = Path.Combine(tempDir, "update.zip");

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
            ZipFile.ExtractToDirectory(zipPath, Application.StartupPath, overwriteFiles: true);
            return true;


            // 解压到应用目录
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
