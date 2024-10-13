using BookingManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        public Task<T> Add(T entity);
        public T Update(T entity);
        public Task<T> Get(Guid id);
        public Task<IQueryable<T>> GetAll();
        public T Remove(Guid id);
    }
}
