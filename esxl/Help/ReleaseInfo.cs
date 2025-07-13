using System;
using Newtonsoft.Json;

namespace esxl.Help
{
    internal class ReleaseInfo
    {   
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tag_name")]
        public required string TagName { get; set; }

        [JsonProperty("target_commitish")]
        public string TargetCommitish { get; set; }

        [JsonProperty("prerelease")]
        public bool Prerelease { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("author")]
        public Author AuthorInfo { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("assets")]
        public required Asset[] Assets { get; set; }

        public class Author
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("login")]
            public string Login { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("avatar_url")]
            public string AvatarUrl { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("html_url")]
            public string HtmlUrl { get; set; }

            [JsonProperty("remark")]
            public string Remark { get; set; }

            [JsonProperty("followers_url")]
            public string FollowersUrl { get; set; }

            [JsonProperty("following_url")]
            public string FollowingUrl { get; set; }

            [JsonProperty("gists_url")]
            public string GistsUrl { get; set; }

            [JsonProperty("starred_url")]
            public string StarredUrl { get; set; }

            [JsonProperty("subscriptions_url")]
            public string SubscriptionsUrl { get; set; }

            [JsonProperty("organizations_url")]
            public string OrganizationsUrl { get; set; }

            [JsonProperty("repos_url")]
            public string ReposUrl { get; set; }

            [JsonProperty("events_url")]
            public string EventsUrl { get; set; }

            [JsonProperty("received_events_url")]
            public string ReceivedEventsUrl { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public class Asset
        {
            [JsonProperty("browser_download_url")]
            public required string BrowserDownloadUrl { get; set; }

            [JsonProperty("name")]
            public required string Name { get; set; }
        }
    }
}
