using ChampDet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JDMovies.Helper;
using JDMovies.Models;


namespace JDMovies.Controllers
{
    public class JDsController : Controller
    {
        // GET: JDs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LOL()
        {
            var rito = new RitoAPIHelper();
            
            var matchHistory = rito.GetMatchHistory();

            var list = new List<Glodos>();

            
            foreach(var i in matchHistory.Matches)
            {
                var match = rito.GetMatchDetails(i.GameId);
                var play = match.ParticipantIdentities.Single(m => m.Player.AccountId == rito.accountID);

                var ulumulu = match.Participants.Single(m => m.ParticipantId == play.ParticipantId);

                var champ = rito.GetChampionDetails(ulumulu.ChampionId);

                var kills = ulumulu.Stats.Kills;
                var dedy = ulumulu.Stats.Deaths;

                list.Add(new Glodos { Champion = $"{champ.Name} {champ.Title}", Kills = kills, Dedy = dedy });

            }


            return PartialView("_KrzyczDisunio",list);
        }



    }
}