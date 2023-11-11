using ProductManagementApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions; // the library to make a questioning datas

namespace ProductManagementApplication.BL
{
    public interface IRepository<T> // <T>, to make it Generic
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression); // to filter when you search results. // x=>x.name == "electronic"
        void Add(T entity);
        T Find(int id);
        T Get(Expression<Func<T, bool>> expression);  
        void Update(T entity);
        void Delete(T entity);
        int Save();
    }
}
