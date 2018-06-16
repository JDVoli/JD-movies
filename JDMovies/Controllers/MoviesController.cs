using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JDMovies.DAL;
using JDMovies.Models;

namespace JDMovies.Controllers
{
    public class MoviesController : Controller
    {

        private UnitOfWork unitOfWork = new UnitOfWork();



        // GET: Movies
        public ActionResult Index()
        {
            
            var vm = new MoviesViewModel
            {
                Movies = unitOfWork.MovieRep.GetMovies(),
                Genres = unitOfWork.GenreRep.GetGenres(),
                GetNosniks = unitOfWork.MovieRep.GetMovies().Select(n => n.Nosnik).Distinct().ToList(),
                GetAgeLim = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList(),
                Film = new Film()
            };


            return View(vm);
        }
        [HttpGet]
        public ActionResult Index(MoviesViewModel vm, string search, string[] nosnik = null, string[] ogr_wiek = null, string[] gatunek = null)
        {

            nosnik = nosnik ?? new string[0];
            ogr_wiek = ogr_wiek ?? new string[0];
            gatunek = gatunek ?? new string[0];


            var films = unitOfWork.MovieRep.GetMovies();

            if (!string.IsNullOrEmpty(search))
            {
                films = unitOfWork.MovieRep.GetMovies().Where(m => m.Tytul.ToLower().Contains(search.ToLower()));
            }
            else if (nosnik.Length > 0 || ogr_wiek.Length > 0 || gatunek.Length > 0)
            {
                films = unitOfWork.MovieRep.GetMovies().Where(m => nosnik.Contains(m.Nosnik) || ogr_wiek.Contains(m.Ogr_wiekowe) || (m.Gatuneks.Any(c => gatunek.Contains(c.Nazwa))));
            }

            
            vm.Movies = films;
            vm.Genres = unitOfWork.GenreRep.GetGenres();
            vm.GetNosniks = unitOfWork.MovieRep.GetMovies().Select(n => n.Nosnik).Distinct().ToList();
            vm.GetAgeLim = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList();


            return View(vm);
        }




        public ActionResult Create(MoviesViewModel vm)
        {
            vm.Genres = unitOfWork.GenreRep.GetGenres();


            return View(vm);
        }

        public ActionResult Edit(MoviesViewModel vm,int id)
        {
            vm.Film = unitOfWork.MovieRep.GetMovieByID(id);
            vm.Genres = unitOfWork.GenreRep.GetGenres();


            return View(vm);
        }

        public ActionResult Delete(MoviesViewModel vm,int id)
        {
            //unitOfWork.MovieRep.DeleteMovie(id);

            var movie = unitOfWork.MovieRep.GetMovieByID(id);

            vm.Film = movie;

            return View(vm);
        }

        public void AddImage()
        {
            
        }


    }

    



}