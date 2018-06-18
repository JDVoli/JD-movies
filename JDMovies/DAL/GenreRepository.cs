using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JDMovies.DAL
{
    public class GenreRepository : IGenreRepository, IDisposable
    {

        private MoviesEntities _db;


        public GenreRepository(MoviesEntities _db)
        {
            this._db = _db;
        }


        public IEnumerable<Gatunek> GetGenres()
        {
            return _db.Gatuneks.ToList();
        }


        public Gatunek GetGenreByName(string gat)
        {
            return _db.Gatuneks.Single(n => n.Nazwa == gat);
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