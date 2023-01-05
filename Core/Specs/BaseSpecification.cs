using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specs
{
    public class BaseSpecification<T> : ISpecification<T>
    {

        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>>? filter)
        {
            Filter = filter;
        }

        public Expression<Func<T, bool>>? Filter { get; }

        public List<Expression<Func<T, object>>>? Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes!.Add(includeExpression);
        }
    }
}