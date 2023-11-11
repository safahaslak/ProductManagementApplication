using ProductManagementApplication.Data;
using ProductManagementApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.BL
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected DatabaseContext context; // database from Entity Framework
        protected DbSet<T> dbSet;  // db set with generic
        public Repository()
        {
            if (context == null) // if context is empty 
            {
                context = new DatabaseContext(); // set an example from DatabaseContext
                dbSet = context.Set<T>(); 
            }        
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Find(int id)
        {
            
            return dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).ToList();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.AddOrUpdate(entity);
        }
    }
}
