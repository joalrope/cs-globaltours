using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Specs
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Filter { get; }
        List<Expression<Func<T, object>>>? Includes { get; }
    }
}