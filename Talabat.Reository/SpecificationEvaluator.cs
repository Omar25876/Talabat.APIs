using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
	public static class SpecificationEvaluator<T> where T : BaseEntity
	{
		public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
		{
			var query = inputQuery;
			if (spec.Criteria is not null)
			{
				query = query.Where(spec.Criteria);
			}
			query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

			if (spec.OrderBy is not null)
			{
				query = query.OrderBy(spec.OrderBy);
			}

			if (spec.OrderByDescending is not null )
			{
				query = query.OrderByDescending(spec.OrderByDescending);
			}

			if (spec.IsPagingEnabled)
			{
				query = query.Skip(spec.Skip).Take(spec.Take);
			}

			return query;
		}
	}
}
