using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.DAL
{
    public class RepoBase<T> where T:class
    {
        private JobListingContext db = new JobListingContext();
        public IQueryable<T> GetAll()
        {
            return db.Set<T>().AsQueryable<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
               
        }

        public void Remove(T item)
        {
            db.Entry<T>(item).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
        public void Update(T item)
        {
            db.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public T Insert(T item)
        {
            var result = db.Set<T>().Add(item);
            db.SaveChanges();
            return result;
        }
    }
}
