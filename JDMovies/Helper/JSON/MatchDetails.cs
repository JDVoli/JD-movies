// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var matchDetails = MatchDetails.FromJson(jsonString);

namespace MatchDet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MatchDetails
    {
        [JsonProperty("seasonId")]
        public long SeasonId { get; set; }

        [JsonProperty("queueId")]
        public long QueueId { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("participantIdentities")]
        public ParticipantIdentity[] ParticipantIdentities { get; set; }

        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("mapId")]
        public long MapId { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("teams")]
        public Team[] Teams { get; set; }

        [JsonProperty("participants")]
        public Participant[] Participants { get; set; }

        [JsonProperty("gameDuration")]
        public long GameDuration { get; set; }

        [JsonProperty("gameCreation")]
        public long GameCreation { get; set; }
    }

    public partial class ParticipantIdentity
    {
        [JsonProperty("player")]
        public Player Player { get; set; }

        [JsonProperty("participantId")]
        public long ParticipantId { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("currentPlatformId")]
        public CurrentPlatformId CurrentPlatformId { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        [JsonProperty("platformId")]
        public PlatformId PlatformId { get; set; }

        [JsonProperty("currentAccountId")]
        public long CurrentAccountId { get; set; }

        [JsonProperty("profileIcon")]
        public long ProfileIcon { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("accountId")]
        public long AccountId { get; set; }
    }

    public partial class Participant
    {
        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("spell1Id")]
        public long Spell1Id { get; set; }

        [JsonProperty("participantId")]
        public long ParticipantId { get; set; }

        [JsonProperty("highestAchievedSeasonTier")]
        public string HighestAchievedSeasonTier { get; set; }

        [JsonProperty("spell2Id")]
        public long Spell2Id { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("timeline")]
        public Timeline Timeline { get; set; }

        [JsonProperty("championId")]
        public long ChampionId { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        [JsonProperty("visionScore")]
        public long VisionScore { get; set; }

        [JsonProperty("magicDamageDealtToChampions")]
        public long MagicDamageDealtToChampions { get; set; }

        [JsonProperty("largestMultiKill")]
        public long LargestMultiKill { get; set; }

        [JsonProperty("totalTimeCrowdControlDealt")]
        public long TotalTimeCrowdControlDealt { get; set; }

        [JsonProperty("longestTimeSpentLiving")]
        public long LongestTimeSpentLiving { get; set; }

        [JsonProperty("perk1Var1")]
        public long Perk1Var1 { get; set; }

        [JsonProperty("perk1Var3")]
        public long Perk1Var3 { get; set; }

        [JsonProperty("perk1Var2")]
        public long Perk1Var2 { get; set; }

        [JsonProperty("tripleKills")]
        public long TripleKills { get; set; }

        [JsonProperty("perk5")]
        public long Perk5 { get; set; }

        [JsonProperty("perk4")]
        public long Perk4 { get; set; }

        [JsonProperty("playerScore9")]
        public long PlayerScore9 { get; set; }

        [JsonProperty("playerScore8")]
        public long PlayerScore8 { get; set; }

        [JsonProperty("kills")]
        public long Kills { get; set; }

        [JsonProperty("playerScore1")]
        public long PlayerScore1 { get; set; }

        [JsonProperty("playerScore0")]
        public long PlayerScore0 { get; set; }

        [JsonProperty("playerScore3")]
        public long PlayerScore3 { get; set; }

        [JsonProperty("playerScore2")]
        public long PlayerScore2 { get; set; }

        [JsonProperty("playerScore5")]
        public long PlayerScore5 { get; set; }

        [JsonProperty("playerScore4")]
        public long PlayerScore4 { get; set; }

        [JsonProperty("playerScore7")]
        public long PlayerScore7 { get; set; }

        [JsonProperty("playerScore6")]
        public long PlayerScore6 { get; set; }

        [JsonProperty("perk5Var1")]
        public long Perk5Var1 { get; set; }

        [JsonProperty("perk5Var3")]
        public long Perk5Var3 { get; set; }

        [JsonProperty("perk5Var2")]
        public long Perk5Var2 { get; set; }

        [JsonProperty("totalScoreRank")]
        public long TotalScoreRank { get; set; }

        [JsonProperty("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        [JsonProperty("damageDealtToTurrets")]
        public long DamageDealtToTurrets { get; set; }

        [JsonProperty("physicalDamageDealtToChampions")]
        public long PhysicalDamageDealtToChampions { get; set; }

        [JsonProperty("damageDealtToObjectives")]
        public long DamageDealtToObjectives { get; set; }

        [JsonProperty("perk2Var2")]
        public long Perk2Var2 { get; set; }

        [JsonProperty("perk2Var3")]
        public long Perk2Var3 { get; set; }

        [JsonProperty("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

        [JsonProperty("perk2Var1")]
        public long Perk2Var1 { get; set; }

        [JsonProperty("perk4Var1")]
        public long Perk4Var1 { get; set; }

        [JsonProperty("totalDamageTaken")]
        public long TotalDamageTaken { get; set; }

        [JsonProperty("perk4Var3")]
        public long Perk4Var3 { get; set; }

        [JsonProperty("largestCriticalStrike")]
        public long LargestCriticalStrike { get; set; }

        [JsonProperty("largestKillingSpree")]
        public long LargestKillingSpree { get; set; }

        [JsonProperty("quadraKills")]
        public long QuadraKills { get; set; }

        [JsonProperty("magicDamageDealt")]
        public long MagicDamageDealt { get; set; }

        [JsonProperty("item2")]
        public long Item2 { get; set; }

        [JsonProperty("item3")]
        public long Item3 { get; set; }

        [JsonProperty("item0")]
        public long Item0 { get; set; }

        [JsonProperty("item1")]
        public long Item1 { get; set; }

        [JsonProperty("item6")]
        public long Item6 { get; set; }

        [JsonProperty("item4")]
        public long Item4 { get; set; }

        [JsonProperty("item5")]
        public long Item5 { get; set; }

        [JsonProperty("perk1")]
        public long Perk1 { get; set; }

        [JsonProperty("perk0")]
        public long Perk0 { get; set; }

        [JsonProperty("perk3")]
        public long Perk3 { get; set; }

        [JsonProperty("perk2")]
        public long Perk2 { get; set; }

        [JsonProperty("perk3Var3")]
        public long Perk3Var3 { get; set; }

        [JsonProperty("perk3Var2")]
        public long Perk3Var2 { get; set; }

        [JsonProperty("perk3Var1")]
        public long Perk3Var1 { get; set; }

        [JsonProperty("damageSelfMitigated")]
        public long DamageSelfMitigated { get; set; }

        [JsonProperty("magicalDamageTaken")]
        public long MagicalDamageTaken { get; set; }

        [JsonProperty("perk0Var2")]
        public long Perk0Var2 { get; set; }

        [JsonProperty("firstInhibitorKill")]
        public bool FirstInhibitorKill { get; set; }

        [JsonProperty("trueDamageTaken")]
        public long TrueDamageTaken { get; set; }

        [JsonProperty("assists")]
        public long Assists { get; set; }

        [JsonProperty("perk4Var2")]
        public long Perk4Var2 { get; set; }

        [JsonProperty("goldSpent")]
        public long GoldSpent { get; set; }

        [JsonProperty("trueDamageDealt")]
        public long TrueDamageDealt { get; set; }

        [JsonProperty("participantId")]
        public long ParticipantId { get; set; }

        [JsonProperty("physicalDamageDealt")]
        public long PhysicalDamageDealt { get; set; }

        [JsonProperty("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        [JsonProperty("totalDamageDealtToChampions")]
        public long TotalDamageDealtToChampions { get; set; }

        [JsonProperty("physicalDamageTaken")]
        public long PhysicalDamageTaken { get; set; }

        [JsonProperty("totalPlayerScore")]
        public long TotalPlayerScore { get; set; }

        [JsonProperty("win")]
        public bool Win { get; set; }

        [JsonProperty("objectivePlayerScore")]
        public long ObjectivePlayerScore { get; set; }

        [JsonProperty("totalDamageDealt")]
        public long TotalDamageDealt { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("perkPrimaryStyle")]
        public long PerkPrimaryStyle { get; set; }

        [JsonProperty("perkSubStyle")]
        public long PerkSubStyle { get; set; }

        [JsonProperty("turretKills")]
        public long TurretKills { get; set; }

        [JsonProperty("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        [JsonProperty("trueDamageDealtToChampions")]
        public long TrueDamageDealtToChampions { get; set; }

        [JsonProperty("goldEarned")]
        public long GoldEarned { get; set; }

        [JsonProperty("killingSprees")]
        public long KillingSprees { get; set; }

        [JsonProperty("unrealKills")]
        public long UnrealKills { get; set; }

        [JsonProperty("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        [JsonProperty("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        [JsonProperty("champLevel")]
        public long ChampLevel { get; set; }

        [JsonProperty("doubleKills")]
        public long DoubleKills { get; set; }

        [JsonProperty("inhibitorKills")]
        public long InhibitorKills { get; set; }

        [JsonProperty("firstInhibitorAssist")]
        public bool FirstInhibitorAssist { get; set; }

        [JsonProperty("perk0Var1")]
        public long Perk0Var1 { get; set; }

        [JsonProperty("combatPlayerScore")]
        public long CombatPlayerScore { get; set; }

        [JsonProperty("perk0Var3")]
        public long Perk0Var3 { get; set; }

        [JsonProperty("visionWardsBoughtInGame")]
        public long VisionWardsBoughtInGame { get; set; }

        [JsonProperty("pentaKills")]
        public long PentaKills { get; set; }

        [JsonProperty("totalHeal")]
        public long TotalHeal { get; set; }

        [JsonProperty("totalMinionsKilled")]
        public long TotalMinionsKilled { get; set; }

        [JsonProperty("timeCCingOthers")]
        public long TimeCCingOthers { get; set; }
    }

    public partial class Timeline
    {
        [JsonProperty("lane")]
        public string Lane { get; set; }

        [JsonProperty("participantId")]
        public long ParticipantId { get; set; }

        [JsonProperty("goldPerMinDeltas")]
        public Dictionary<string, double> GoldPerMinDeltas { get; set; }

        [JsonProperty("creepsPerMinDeltas")]
        public Dictionary<string, double> CreepsPerMinDeltas { get; set; }

        [JsonProperty("xpPerMinDeltas")]
        public Dictionary<string, double> XpPerMinDeltas { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("damageTakenPerMinDeltas")]
        public Dictionary<string, double> DamageTakenPerMinDeltas { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("firstDragon")]
        public bool FirstDragon { get; set; }

        [JsonProperty("bans")]
        public object[] Bans { get; set; }

        [JsonProperty("firstInhibitor")]
        public bool FirstInhibitor { get; set; }

        [JsonProperty("win")]
        public string Win { get; set; }

        [JsonProperty("firstRiftHerald")]
        public bool FirstRiftHerald { get; set; }

        [JsonProperty("firstBaron")]
        public bool FirstBaron { get; set; }

        [JsonProperty("baronKills")]
        public long BaronKills { get; set; }

        [JsonProperty("riftHeraldKills")]
        public long RiftHeraldKills { get; set; }

        [JsonProperty("firstBlood")]
        public bool FirstBlood { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("firstTower")]
        public bool FirstTower { get; set; }

        [JsonProperty("vilemawKills")]
        public long VilemawKills { get; set; }

        [JsonProperty("inhibitorKills")]
        public long InhibitorKills { get; set; }

        [JsonProperty("towerKills")]
        public long TowerKills { get; set; }

        [JsonProperty("dominionVictoryScore")]
        public long DominionVictoryScore { get; set; }

        [JsonProperty("dragonKills")]
        public long DragonKills { get; set; }
    }

    public enum CurrentPlatformId { Eun1 };

    public enum PlatformId { Eun1, Euw1 };

    public enum Role { DuoSupport, None, Solo, DuoCarry };

    public partial class MatchDetails
    {
        public static MatchDetails FromJson(string json) => JsonConvert.DeserializeObject<MatchDetails>(json, MatchDet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MatchDetails self) => JsonConvert.SerializeObject(self, MatchDet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                CurrentPlatformIdConverter.Singleton,
                PlatformIdConverter.Singleton,
                RoleConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CurrentPlatformIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CurrentPlatformId) || t == typeof(CurrentPlatformId?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "EUN1")
            {
                return CurrentPlatformId.Eun1;
            }
            throw new Exception("Cannot unmarshal type CurrentPlatformId");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CurrentPlatformId)untypedValue;
            if (value == CurrentPlatformId.Eun1)
            {
                serializer.Serialize(writer, "EUN1");
                return;
            }
            throw new Exception("Cannot marshal type CurrentPlatformId");
        }

        public static readonly CurrentPlatformIdConverter Singleton = new CurrentPlatformIdConverter();
    }

    internal class PlatformIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PlatformId) || t == typeof(PlatformId?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "eun1":
                    return PlatformId.Eun1;
                case "euw1":
                    return PlatformId.Euw1;
                default:
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
            switch (value)
            {
                case PlatformId.Eun1:
                    serializer.Serialize(writer, "EUN1");
                    return;
                case PlatformId.Euw1:
                    serializer.Serialize(writer, "EUW1");
                    return;
            }
            throw new Exception("Cannot marshal type PlatformId");
        }

        public static readonly PlatformIdConverter Singleton = new PlatformIdConverter();
    }

    internal class RoleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "DUO_SUPPORT":
                    return Role.DuoSupport;
                case "NONE":
                    return Role.None;
                case "SOLO":
                    return Role.Solo;
                case "DUO_CARRY":
                    return Role.DuoCarry;
                default:
                    return Role.None;
            }
            throw new Exception("Cannot unmarshal type Role");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Role)untypedValue;
            switch (value)
            {
                case Role.DuoSupport:
                    serializer.Serialize(writer, "DUO_SUPPORT");
                    return;
                case Role.None:
                    serializer.Serialize(writer, "NONE");
                    return;
                case Role.Solo:
                    serializer.Serialize(writer, "SOLO");
                    return;
            }
            throw new Exception("Cannot marshal type Role");
        }

        public static readonly RoleConverter Singleton = new RoleConverter();
    }
}
