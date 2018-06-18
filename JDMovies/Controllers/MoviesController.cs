using System;
using System.Collections.Generic;
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
            vm.GetAgeLim = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList().OrderByDescending(n => n);


            return View(vm);
        }






        [HttpGet]
        public ActionResult Create(MoviesCreateViewModel vmc)
        {
            var nos = unitOfWork.MovieRep.GetMovies().Select(n => n.Nosnik).Distinct().ToList();
            var ag = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList().OrderByDescending(n => n).ToList();

            var selectListItemsNos = nos.Select(x => new SelectListItem() { Value = x.ToString(), Text = x }).ToList();
            var selectListItemsAg = ag.Select(x => new SelectListItem() { Value = x.ToString(), Text = x }).ToList();

            vmc.Genres = unitOfWork.GenreRep.GetGenres();
            vmc.GetNosniks = new SelectList(selectListItemsNos);
            vmc.GetAgeLim = new SelectList(selectListItemsAg);

            return View(vmc);
        }

        [HttpPost]
        public ActionResult Create(Film film, string Nosnik, string Ogr_wiekowe, string Data_premiery, string[] Gatunek)
        {

            HttpPostedFileBase img = Request.Files["Zdjecie"];
            byte[] image = null;

            

            if (img != null)
            {               
                if(img.ContentLength > 0)
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
            
                nMov.Tytul = film.Tytul;
                nMov.Nosnik = Nosnik;
                nMov.Czas_trwania = film.Czas_trwania;

                foreach(var i in Gatunek)
                {
                    Gatunek g = unitOfWork.GenreRep.GetGenreByName(i);                    

                    nMov.Gatuneks.Add(g);
            }
                
                nMov.Data_premiery = DateTime.Parse(Data_premiery);
                nMov.Ogr_wiekowe = Ogr_wiekowe;
                nMov.Zdjecie = image;

            unitOfWork.MovieRep.InsertMovie(nMov);
            unitOfWork.MovieRep.Save();


            return RedirectToAction(nameof(Index));


        }

     
        //public ActionResult Edit(MoviesEditViewModel vme,int id)
        //{
        //    var nos = unitOfWork.MovieRep.GetMovies().Select(n => n.Nosnik).Distinct().ToList();
        //    var ag = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList().OrderByDescending(n => n);


        //    vme.Film = unitOfWork.MovieRep.GetMovieByID(id);
        //    vme.Genres = unitOfWork.GenreRep.GetGenres();
        //    vme.IGetNosniks = nos;
        //    vme.IGetAgeLim = ag;
        //    vme.GetNosniks = new SelectList(nos);
        //    vme.GetAgeLim = new SelectList(ag);


        //    return View(vme);
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var nos = unitOfWork.MovieRep.GetMovies().Select(n => n.Nosnik).Distinct().ToList();
            var ag = unitOfWork.MovieRep.GetMovies().Select(n => n.Ogr_wiekowe).Distinct().ToList().OrderByDescending(n => n).ToList();

            var selectListItemsNos = nos.Select(x => new SelectListItem() { Value = x.ToString(), Text = x }).ToList();
            var selectListItemsAg = ag.Select(x => new SelectListItem() { Value = x.ToString(), Text = x }).ToList();


            var vme = new MoviesEditViewModel
            {               
                
                Genres = unitOfWork.GenreRep.GetGenres(),
                GetNosniks = new SelectList(selectListItemsNos),
                GetAgeLim = new SelectList(selectListItemsAg),
                Film = new Film()
            };

            vme.Film = unitOfWork.MovieRep.GetMovieByID(id);

        

            return View(vme);
        }


        // TU SIĘ WYPIERDALA


        [HttpPost]
        public ActionResult Edit(Film movie, int id)
        {
            
            //toUpdate.Tytul = mve.Film.Tytul;
            //toUpdate.Nosnik = mve.Film.Nosnik;
            //toUpdate.Data_premiery = mve.Film.Data_premiery;
            //toUpdate.Czas_trwania = mve.Film.Czas_trwania;
            //toUpdate.Ogr_wiekowe = mve.Film.Ogr_wiekowe;
            //toUpdate.Gatuneks = mve.Film.Gatuneks;

            //HttpPostedFileBase img = Request.Files["Zdjecie"];
            //byte[] image = null;
            
            //if (img != null)
            //{
            //    if (img.ContentLength > 0)
            //    {
            //        image = new byte[img.ContentLength];
            //        img.InputStream.Read(image, 0, img.ContentLength);
            //    }
            //}


            //if(image == null)
            //{
            //    toUpdate.Zdjecie = mve.Film.Zdjecie;
            //}
            //else
            //{
            //    toUpdate.Zdjecie = image;
            //}
            
            unitOfWork.MovieRep.Save();

            return View();
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

        //[HttpPost]
        //public ActionResult Delete(MoviesDeleteViewModel vmd, int id)
        //{
        //    vmd.Film = unitOfWork.MovieRep.GetMovieByID(id);

        //    return View(vmd);
        //}

        [HttpPost, ActionName("Delete")]        
        public ActionResult DeleteConfirmed(int id)
        {
            
            unitOfWork.MovieRep.DeleteMovie(id);
            unitOfWork.MovieRep.Save();

            return RedirectToAction(nameof(Index));
        }




    }

    



}