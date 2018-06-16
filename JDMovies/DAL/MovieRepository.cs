using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace JDMovies.DAL
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private MoviesEntities _db;


        public MovieRepository(MoviesEntities _db)
        {
            this._db = _db;
        }


        public IEnumerable<Film> GetMovies()
        {
            return _db.Films.ToList();
        }

        public Film GetMovieByID(int movieID)
        {
            return _db.Films.Find(movieID);
        }

        public void InsertMovie(Film movie)
        {
            _db.Films.Add(movie);
        }



        public void DeleteMovie(int movieID)
        {
            Film mov = _db.Films.Find(movieID);
            _db.Films.Remove(mov);
        }

        public void UpdateMovie(Film movie)
        {
            //_db.Entry(movie).State = System.Data.Entity.EntityState;
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}