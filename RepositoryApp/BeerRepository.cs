using RepositoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryApp
{
    public class BeerRepository : IBeerRepository
    {
        private DesignPatternsContext _context;

        public BeerRepository(DesignPatternsContext context)
        {
            _context = context;
        }

        public void Add(Beer data) => _context.Add(data);

        public void Delete(int id)
        {
            Beer? beer = _context.Beers.Find(id);

            if(beer != null)
                _context.Beers.Remove(beer);
        }

        public IEnumerable<Beer> Get() => _context.Beers.ToList();

        public Beer? Get(int id) => _context.Beers.Find(id);

        public void Update(Beer data) => _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        public void Save() => _context.SaveChanges();
    }
}
