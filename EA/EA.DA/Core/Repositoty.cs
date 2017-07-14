using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace EA.DA.Core
{
    public class Repositoty : IRepository
    {
        private DataContext _dataContext;

        public Repositoty(IDbFactory dbFactory)
        {
            _dataContext = dbFactory.GetDataContext;
        }

        public IQueryable<T> All<T>() where T : class
        {
            return _dataContext.Set<T>().AsQueryable();
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return All<T>().FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? _dataContext.Set<T>().Where<T>(filter).AsQueryable() : _dataContext.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual void Create<T>(T TObject) where T:class
        {
            var newEntry = _dataContext.Set<T>().Add(TObject);
        }

        public virtual void Delete<T>(T TObject) where T : class
        {
            _dataContext.Set<T>().Remove(TObject);
        }

        public virtual void Update<T>(T TObject) where T : class
        {
            try
            {
                var entry = _dataContext.Entry(TObject);
                _dataContext.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = Filter<T>(predicate);
            foreach(var obj in objects)
            {
                _dataContext.Set<T>().Remove(obj);
            }
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dataContext.Set<T>().Count<T>(predicate) > 0;
        }

        public virtual T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dataContext.Set<T>().FirstOrDefault<T>(predicate);
        }

        public virtual void ExecuteProcedure(string procudureCommand, params SqlParameter[] sqlParams)
        {
            _dataContext.Database.ExecuteSqlCommand(procudureCommand, sqlParams);
        }
    }
}
