// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var championDetails = ChampionDetails.FromJson(jsonString);



namespace ChampDet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ChampionDetails
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class ChampionDetails
    {
        public static ChampionDetails FromJson(string json) => JsonConvert.DeserializeObject<ChampionDetails>(json, ChampDet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ChampionDetails self) => JsonConvert.SerializeObject(self, ChampDet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
