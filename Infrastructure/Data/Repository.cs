using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Specs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        public Repository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<T> GetOneAsync(int id)
        {
            var item = await _db.Set<T>().FindAsync(id);
            return item!;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetOneSpec(ISpecification<T> spec)
        {
            var item = await applySpecification(spec).FirstOrDefaultAsync();

            return item!;

        }

        public async Task<IReadOnlyList<T>> GetAllSpec(ISpecification<T> spec)
        {
            var items = await applySpecification(spec).ToListAsync();

            return items!;

        }

        private IQueryable<T> applySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_db.Set<T>().AsQueryable(), spec);
        }
    }
}