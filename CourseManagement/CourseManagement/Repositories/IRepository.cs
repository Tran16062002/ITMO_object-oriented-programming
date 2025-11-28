using System;
using System.Collections.Generic;

namespace CourseManagement.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        T? GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
