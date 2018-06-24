using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChampDet;
using MatchDet;
using MatchHist;
using RestSharp;

namespace JDMovies.Helper
{
    public class RitoAPIHelper
    {
        private readonly string APIKey = "RGAPI-b20f7ab1-bcb8-45e1-ad5d-81032a3cfb7c";
        private readonly RestClient client = new RestClient("https://eun1.api.riotgames.com/lol");
        public readonly long accountID = 22440767;


        public ChampionDetails GetChampionDetails(long id)
        {
           
            var request = new RestRequest($"/static-data/v3/champions/{id}", Method.GET);
            request.AddParameter("locale", "pl_PL");


            request.AddParameter("api_key", APIKey);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var championDetails = ChampionDetails.FromJson(content);
            return championDetails;
        }

        public MatchDetails GetMatchDetails(long id)
        {

            var request = new RestRequest($"/match/v3/matches/{id}", Method.GET);            


            request.AddParameter("api_key", APIKey);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var matchDetails = MatchDetails.FromJson(content);
            return matchDetails;
        }

        public MatchHistory GetMatchHistory()
        {
            var request = new RestRequest($"/match/v3/matchlists/by-account/{accountID}", Method.GET);
            request.AddParameter("endIndex", "5");

            request.AddParameter("api_key", APIKey);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var matchHistory = MatchHistory.FromJson(content);
            return matchHistory;

        }

    }
}