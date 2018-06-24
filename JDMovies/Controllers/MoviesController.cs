using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
           
            var vm = new MoviesIndexViewModel
            {
                Movies = unitOfWork.MovieRep.GetMovies(),
                Genres = unitOfWork.GenreRep.GetGenres(),
                GetNosniks = unitOfWork.MovieRep.GetMovies().Select(n => n.Nosnik).Distinct().ToList(),
                GetAgeLim = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList().OrderByDescending(n => n),
                Film = new Film()
            };


            return View(vm);
        }

        [HttpGet]
        public ActionResult Index(MoviesIndexViewModel vm, string search, string[] nosnik = null, string[] ogr_wiek = null, string[] gatunek = null)
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

            var tmp = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList();
            tmp = tmp.Select(m => m.Trim('+')).ToList();


            var output = new List<int>();
            output = tmp.ConvertAll(int.Parse);

            output.Sort((left, right) => left.CompareTo(right));


            vm.GetAgeLim = output.ConvertAll(delegate (int i) { return i+"+".ToString(); });

            return View(vm);
            
        }

        [HttpPost]
        public ActionResult ListOfMovies(string str)
        {
            IEnumerable<Film> mov = null;

            if (str.Contains("według"))
            {
                return View();
            }
            else if (str.Contains("A do Z"))
            {
                mov = unitOfWork.MovieRep.GetMovies().OrderBy(m => m.Tytul);
            }
            else if (str.Contains("Z do A"))
            {
                mov = unitOfWork.MovieRep.GetMovies().OrderByDescending(m => m.Tytul);
                

            }
            else if(str.Contains("od najnowszego"))
            {
                mov = unitOfWork.MovieRep.GetMovies().OrderByDescending(m => m.Data_premiery);

            }
            else
            {
                mov = unitOfWork.MovieRep.GetMovies().OrderBy(m => m.Data_premiery);
            }

            return PartialView("_listOfMovies",mov);
        }


       
        public ActionResult Create()
        {
            var nos = unitOfWork.MovieRep.GetMovies().Select(n => n.Nosnik).Distinct().ToList();


            var tmp = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList();
            tmp = tmp.Select(m => m.Trim('+')).ToList();


            var output = new List<int>();
            output = tmp.ConvertAll(int.Parse);

            output.Sort((left, right) => left.CompareTo(right));


            var ag = output.ConvertAll(delegate (int i) { return i + "+".ToString(); });


            var selectListItemsNos = nos.Select(x => new SelectListItem() { Value = x.ToString(), Text = x }).ToList();
            var selectListItemsAg = ag.Select(x => new SelectListItem() { Value = x.ToString(), Text = x }).ToList();


            var vmc = new MoviesCreateViewModel
            {
                Genres = unitOfWork.GenreRep.GetGenres(),
                GetNosniks = new SelectList(selectListItemsNos),
                GetAgeLim = new SelectList(selectListItemsAg),
                Film = new Film()
            };            

            return View(vmc);
        }



        [HttpPost]
        public ActionResult Create(MoviesCreateViewModel mov, string[] Gatunek)
        {
            if (ModelState.IsValid)
            {

           
                HttpPostedFileBase img = Request.Files["cover"];
                byte[] image = null;



                if (img != null)
                {
                    if (img.ContentLength > 0)
                    {
                        image = new byte[img.ContentLength];
                        img.InputStream.Read(image, 0, img.ContentLength);
                    }
                    else
                    {
                        string custImg = Path.Combine(Server.MapPath("~/Content/Images"), "CustomCover.jpg");
                        FileStream stream = new FileStream(custImg, FileMode.Open, FileAccess.Read);
                        BinaryReader brs = new BinaryReader(stream);
                        image = brs.ReadBytes((int)stream.Length);
                    }

                }


                Film nMov = new Film();

                nMov.Tytul = mov.Film.Tytul;
                nMov.Nosnik = mov.Film.Nosnik;
                nMov.Czas_trwania = mov.Film.Czas_trwania;

                foreach (var i in Gatunek)
                {
                    Gatunek g = unitOfWork.GenreRep.GetGenreByName(i);

                    nMov.Gatuneks.Add(g);
                }

                nMov.Data_premiery = mov.Film.Data_premiery;
                nMov.Ogr_wiekowe = mov.Film.Ogr_wiekowe;
                nMov.Zdjecie = image;

                unitOfWork.MovieRep.InsertMovie(nMov);
                unitOfWork.MovieRep.Save();


                return RedirectToAction(nameof(Index));
            }
            return View(mov);

        }

        public ActionResult Edit(int id)
        {

            var nos = unitOfWork.MovieRep.GetMovies().Select(n => n.Nosnik).Distinct().ToList();

            var tmp = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList();
            tmp = tmp.Select(m => m.Trim('+')).ToList();


            var output = new List<int>();
            output = tmp.ConvertAll(int.Parse);

            output.Sort((left, right) => left.CompareTo(right));


            var ag = output.ConvertAll(delegate (int i) { return i + "+".ToString(); });

            var selectListItemsNos = nos.Select(x => new SelectListItem() { Value = x.ToString(), Text = x }).ToList();
            var selectListItemsAg = ag.Select(x => new SelectListItem() { Value = x.ToString(), Text = x }).ToList();


            var vme = new MoviesEditViewModel
            {

                Genres = unitOfWork.GenreRep.GetGenres(),
                GetNosniks = new SelectList(selectListItemsNos),
                GetAgeLim = new SelectList(selectListItemsAg),
                Film = unitOfWork.MovieRep.GetMovieByID(id)
            };


            return View(vme);
        }

        
        [HttpPost]
        public ActionResult Edit(MoviesEditViewModel movie, int id, string[] Gatunek)
        {

            if (ModelState.IsValid) { 
            
                var toUpdate = unitOfWork.MovieRep.GetMovieByID(id);



                toUpdate.Tytul = movie.Film.Tytul;
                toUpdate.Nosnik = movie.Film.Nosnik;
                toUpdate.Data_premiery = movie.Film.Data_premiery;
                toUpdate.Czas_trwania = movie.Film.Czas_trwania;
                toUpdate.Ogr_wiekowe = movie.Film.Ogr_wiekowe;

                toUpdate.Gatuneks.Clear();

                foreach (var i in Gatunek)
                {
                    Gatunek g = unitOfWork.GenreRep.GetGenreByName(i);
                    toUpdate.Gatuneks.Add(g);
                }


                HttpPostedFileBase img = Request.Files["cover"];
                byte[] image = null;

                if (img != null)
                {
                    if (img.ContentLength > 0)
                    {
                        image = new byte[img.ContentLength];
                        img.InputStream.Read(image, 0, img.ContentLength);
                    }
                }


                if (image != null)
                {
                    toUpdate.Zdjecie = image;
                }

                unitOfWork.MovieRep.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        
        }


        public ActionResult Delete(int id)
        {

            var vmd = new MoviesDeleteViewModel
            {
                Film = new Film()
            };

            vmd.Film = unitOfWork.MovieRep.GetMovieByID(id);
            
            return View(vmd);
        }


        [HttpPost, ActionName("Delete")]        
        public ActionResult DeleteConfirmed(int id)
        {
            //if (ModelState.IsValid)
            //{
                unitOfWork.MovieRep.DeleteMovie(id);
                unitOfWork.MovieRep.Save();

                return RedirectToAction(nameof(Index));

            //}

            //return View();
        }




    }

    



}