using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Api.Model.Base;

namespace TaskManager.Api.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(int id, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll();
        T Update(T item);
        void Delete(int id);
        bool Exists(int id);

        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
