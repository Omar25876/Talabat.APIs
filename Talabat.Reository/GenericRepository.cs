using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Reository.Data;
using Talabat.Repository;

namespace Talabat.Reository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly StoreContext _dbContext;

		public GenericRepository(StoreContext dbContext)
		{
			_dbContext = dbContext;
		}

		#region Without Specification
		public async Task<IReadOnlyList<T>> GetAllAsync() {

			if (typeof(T) == typeof(Product))
			{
				return await _dbContext.Products
					.Include(p => p.ProductBrand)
					.Include(p => p.ProductType)
					.ToListAsync() as IReadOnlyList<T>;
			}
			else {
				return await _dbContext.Set<T>().ToListAsync();
			}
			
		}

	
		public Task<T> GetByIdAsync(int id) => _dbContext.Set<T>().FindAsync(id).AsTask();

		#endregion

		#region With Specification

		public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> Spec)
		{
			return await ApplySpecification(Spec).ToListAsync();
		}

		public async Task<T> GetEntityWithSpecAsync(ISpecifications<T> Spec)
		{
			return await ApplySpecification(Spec).FirstOrDefaultAsync();
		}

		#endregion


		public Task<int> GetCountWithSpecAsync(ISpecifications<T> Spec)
		{
			return ApplySpecification(Spec).CountAsync();
		}

		private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
		{
			return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
		}

		public async Task Add(T item)
		{
			await _dbContext.Set<T>().AddAsync(item);
		}

		public void Delete(T item) =>	_dbContext.Set<T>().Remove(item);
		public void Update(T item) =>	_dbContext.Set<T>().Update(item);
	}


}
