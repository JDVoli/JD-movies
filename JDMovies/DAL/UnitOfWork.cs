using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JDMovies.DAL
{
    public class UnitOfWork : IDisposable
    {

        private MoviesEntities _context = new MoviesEntities();
        private MovieRepository _movieRep;
        private GenreRepository _genreRep;


        public MovieRepository MovieRep
        {
            get
            {

                if (this._movieRep == null)
                {
                    this._movieRep = new MovieRepository(_context);
                }
                return _movieRep;
            }
        }

        public GenreRepository GenreRep
        {
            get
            {

                if (this._genreRep == null)
                {
                    this._genreRep = new GenreRepository(_context);
                }
                return _genreRep;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}