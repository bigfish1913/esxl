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
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public async Task<bool> CheckUpdateAsync()
        {
            string? currentVersion = Config.GetValueByKey("Version");
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://gitee.com/api/v5/repos/laofublog/esxl/releases?access_token=da63399fc78bb7e9df48a660eab43d42&page=1&per_page=20&direction=desc";
                var response = await client.GetStringAsync(apiUrl);
                dynamic release = JsonConvert.DeserializeObject(response);
                string latestVersion = release.tag_name;

                return Version.Parse(latestVersion) > Version.Parse(currentVersion);
            }
        }

        public async Task DownloadAndExtractAsync(string downloadUrl)
        {
            string tempDir = Path.GetTempPath() + "\\Update";
            string zipPath = Path.Combine(tempDir, "update.zip");

            // 下载ZIP包
            using (HttpClient client = new HttpClient())
            using (var stream = await client.GetStreamAsync(downloadUrl))
            using (var fileStream = File.Create(zipPath))
            {
                await stream.CopyToAsync(fileStream);
            }

            // 解压到应用目录
            ZipFile.ExtractToDirectory(zipPath, Application.StartupPath, overwriteFiles: true);
        }
        public void RestartApplication()
        {
            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }
    }
}
