using IdentitySample.Domain.Interfaces.Repository;
using IdentitySample.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IdentitySample.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IdentitySampleDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(IdentitySampleDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual void Add(T obj)
        {
            DbSet.Add(obj);
        }

        public virtual T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(T obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
