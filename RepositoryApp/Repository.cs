using Microsoft.EntityFrameworkCore;
using RepositoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryApp
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DesignPatternsContext _context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(DesignPatternsContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity data) => dbSet.Add(data);

        public void Delete(int id)
        {
            TEntity? row = dbSet.Find(id);

            if(row != null)
                dbSet.Remove(row);
        }

        public IEnumerable<TEntity> Get() => dbSet.ToList();

        public TEntity? Get(int id) => dbSet.Find(id);

        public void Update(TEntity data) => dbSet.Entry(data).State = EntityState.Modified;

        public void Save() => _context.SaveChanges();
    }
}
