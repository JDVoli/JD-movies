using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JDMovies.DAL;

namespace JDMovies.Models
{
    public class MoviesIndexViewModel
    {
        public IEnumerable<Film> Movies { get; set; }
        public IEnumerable<Gatunek> Genres { get; set; }

        public Film Film { get; set; }

        public IEnumerable<string> GetNosniks { get; set; }

        public IEnumerable<string> GetAgeLim { get; set; }


        //public IEnumerable<SelectListItem> GetNosniks2
        //{
        //    get
        //    {
        //        return Movies?.Select(t => new SelectListItem
        //        {
        //            Value = (++it).ToString(),
        //            Text = t.Nosnik
        //        }) ?? new List<SelectListItem>();
        //    }
        //}

        //public IEnumerable<string> GetAgeLim
        //{
        //    get
        //    {
        //        return Movies.Select(a => a.Ogr_wiekowe).Distinct().ToList();
        //    }

        //}




        //public IEnumerable<SelectListItem> GetNosniks
        //{
        //    get
        //    {
        //        return Movies.Select(t => new SelectListItem
        //        {
        //            Text = t.Nosnik
        //        }).Distinct() ?? new List<SelectListItem>();
        //    }
        //}
    }
}