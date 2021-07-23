using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, decimal>> DecimalOrderBy { get; }
        Expression<Func<T, DateTime>> DateOrderBy { get; }
        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, decimal>> DecimalOrderByDescending { get; }
        Expression<Func<T, DateTime>> DateOrderByDescending { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
