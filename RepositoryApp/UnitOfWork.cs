using RepositoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryApp
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Beer> _beers;
        private IRepository<Brand> _brands;
        private DesignPatternsContext _context;

        public UnitOfWork(DesignPatternsContext context)
        {
            _context = context;
        }

        public IRepository<Beer> Beers
        {
            get
            {
                return _beers == null ? _beers = new Repository<Beer>(_context) : _beers;
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                return _brands == null ? _brands = new Repository<Brand>(_context) : _brands;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
