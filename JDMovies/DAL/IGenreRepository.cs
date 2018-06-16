using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDMovies.DAL
{
    interface IGenreRepository : IDisposable
    {
        IEnumerable<Gatunek> GetGenres();
        Gatunek GetGenreByID(int genreID);

    }
}
