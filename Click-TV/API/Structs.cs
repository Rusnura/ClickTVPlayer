using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Click_TV
{
    [JsonObject(MemberSerialization.OptIn)]
    public struct Channel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("archive")]
        public int Archive { get; set; }

        [JsonProperty("archive_range")]
        public int ArchiveRange { get; set; }

        [JsonProperty("pvr")]
        public int PVR { get; set; }

        [JsonProperty("censored")]
        public int Censored { get; set; }

        [JsonProperty("favorite")]
        public int Favorite { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("monitoring_status")]
        public int MonitoringStatus { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public struct EPG
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("in_archive")]
        public int inArchive { get; set; }

        [JsonProperty("downloadable")]
        public int Downloadable { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public struct ServiceMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("send_time")]
        public string Time { get; set; }
    }
}