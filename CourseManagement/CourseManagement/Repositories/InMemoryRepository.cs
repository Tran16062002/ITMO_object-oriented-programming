using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseManagement.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T entity) => _items.Add(entity);

        public void Remove(T entity) => _items.Remove(entity);

        public IEnumerable<T> GetAll() => _items;

        public T? GetById(Guid id)
        {
            var prop = typeof(T).GetProperty("Id");
            return _items.FirstOrDefault(x => prop != null && prop.GetValue(x)?.Equals(id) == true);
        }
    }
}
