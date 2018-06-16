using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JDMovies.DAL
{
    public interface IMovieRepository : IDisposable
    {
        IEnumerable<Film> GetMovies();
        Film GetMovieByID(int movieID);
        void InsertMovie(Film movie);
        void DeleteMovie(int movieID);
        void UpdateMovie(Film movie);
        void Save();

    }
}