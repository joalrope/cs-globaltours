using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specs;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetOneAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetOneSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllSpec(ISpecification<T> spec);
    }
}