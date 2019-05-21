using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JobListing.DAL;

namespace JobListing.BLL
{
    public class ServiceBase<T> where T : class
    {
        private RepoBase<T> db = new RepoBase<T>();

        public IQueryable<T> GetAll()
        {
            return db.GetAll();
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return db.FindBy(expression);
        }
        public void Remove(T item)
        {
            db.Remove(item);
        }
        public void Update(T item)
        {
            db.Update(item);
        }
        public T Insert(T item)
        {
        return db.Insert(item); 
        }
     
    }
}
