using RepositoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryApp
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }

        public IRepository<Brand> Brands { get; }

        public void Save();
    }
}
