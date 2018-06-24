// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace MatchHist
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MatchHistory
    {
        [JsonProperty("matches")]
        public Match[] Matches { get; set; }

        [JsonProperty("endIndex")]
        public long EndIndex { get; set; }

        [JsonProperty("startIndex")]
        public long StartIndex { get; set; }

        [JsonProperty("totalGames")]
        public long TotalGames { get; set; }
    }

    public partial class Match
    {
        [JsonProperty("lane")]
        public string Lane { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("champion")]
        public long Champion { get; set; }

        [JsonProperty("platformId")]
        public PlatformId PlatformId { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("queue")]
        public long Queue { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("season")]
        public long Season { get; set; }
    }

    public enum PlatformId { Eun1 };

    public partial class MatchHistory
    {
        public static MatchHistory FromJson(string json) => JsonConvert.DeserializeObject<MatchHistory>(json, MatchHist.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MatchHistory self) => JsonConvert.SerializeObject(self, MatchHist.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                PlatformIdConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PlatformIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PlatformId) || t == typeof(PlatformId?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "EUN1")
            {
                return PlatformId.Eun1;
            }
            throw new Exception("Cannot unmarshal type PlatformId");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PlatformId)untypedValue;
            if (value == PlatformId.Eun1)
            {
                serializer.Serialize(writer, "EUN1");
                return;
            }
            throw new Exception("Cannot marshal type PlatformId");
        }

        public static readonly PlatformIdConverter Singleton = new PlatformIdConverter();
    }
}
