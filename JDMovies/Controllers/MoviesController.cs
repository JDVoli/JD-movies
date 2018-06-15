using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JDMovies.DAL;

namespace JDMovies.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesEntities _db = new MoviesEntities();


        // GET: Movies
        public ActionResult Index()
        {
            return View(_db.Films.ToList());
        }

        public ActionResult Search(string[] nosnik, string[] ogr_wiek, string[] gatunek)
        {
            

            return View("Index");
        }

        

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var an = _db.Films.FirstOrDefault(m => m.ID_filmu == id);
            
            return View(an);
        }


    }

    



}