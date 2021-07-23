using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Specifications
{
    public class BaseSpecifcation<T> : ISpecification<T>
    {
        public BaseSpecifcation()
        {
        }

        public BaseSpecifcation(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        public Expression<Func<T, decimal>> DecimalOrderBy { get; private set; }

        public Expression<Func<T, DateTime>> DateOrderBy { get; private set; }

        public Expression<Func<T, decimal>> DecimalOrderByDescending { get; private set; }

        public Expression<Func<T, DateTime>> DateOrderByDescending { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T,object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddDecimaOrderBy(Expression<Func<T, decimal>> orderByExpression)
        {
            DecimalOrderBy = orderByExpression;
        }


        protected void AddDateOrderBy(Expression<Func<T, DateTime>> orderByExpression)
        {
            DateOrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
        protected void AddDecimalOrderByDescending(Expression<Func<T, decimal>> orderByDescExpression)
        {
            DecimalOrderByDescending = orderByDescExpression;
        }
        protected void AddDateOrderByDescending(Expression<Func<T, DateTime>> orderByDescExpression)
        {
            DateOrderByDescending = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}

