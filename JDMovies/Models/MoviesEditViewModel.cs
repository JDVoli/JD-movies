using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JDMovies.DAL;

namespace JDMovies.Models
{
    public class MoviesEditViewModel
    {


        public IEnumerable<Gatunek> Genres { get; set; }

        public Film Film { get; set; }

        public SelectList GetNosniks { get; set; }

        public SelectList GetAgeLim { get; set; }
    }
}