using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.Model;

namespace BusinessLayer.Repositories
{
	public class Repository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly DataBaseContext _context;

		public Repository(DataBaseContext context)
		{
			_context = context;
		}
		public T Get(int id)
		{
			return _context.Set<T>().FirstOrDefault(i => i.Id == id);
		}

		public IQueryable<T> GetAll()
		{
			return _context.Set<T>();
		}

		public T Save(T entity)
		{
			if (entity.Id <= 0)
				return _saveNew(entity);

			var db = Get(entity.Id);
			_context.Entry(db).CurrentValues.SetValues(entity);
			_context.SaveChanges();
			return entity;
		}

		private T _saveNew(T entity)
		{
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
			return entity;
		}

		public void Delete(int id)
		{
			var entity = Get(id);
			if(entity == null)
				throw new Exception($"Entity with id = {id} not found");

			entity.IsDeleted = true;
			_context.SaveChanges();
		}
	}
}
