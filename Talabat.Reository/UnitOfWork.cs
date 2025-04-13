﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Reository;
using Talabat.Reository.Data;

namespace Talabat.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly StoreContext _dbContext;
		private Hashtable _repositories;

		public UnitOfWork(StoreContext dbContext)
		{
			_dbContext = dbContext;
			_repositories = new Hashtable();
		}
		public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();

		public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

		public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
		{
			var type = typeof(TEntity).Name;
			if (_repositories.ContainsKey(type))
			{
				var Repository = new GenericRepository<TEntity>(_dbContext);
				_repositories.Add(type, Repository);

			}

			return (IGenericRepository<TEntity>) _repositories[type];
		}
	}
}
