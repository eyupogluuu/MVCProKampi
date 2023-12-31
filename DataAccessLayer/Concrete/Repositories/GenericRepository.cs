﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : class
	{
		Context c = new Context();
		DbSet<T> _object;
        public GenericRepository()
        {
			_object=c.Set<T>();// yukarda belirttiğim object dışardan gelen T değeri olcak
        }
        public void Delete(T entity)
		{
			var deletedEntity = c.Entry(entity);
			deletedEntity.State = EntityState.Deleted;
			_object.Remove(entity);
			c.SaveChanges();
		}

		public List<T> FList(Expression<Func<T, bool>> filter)
		{
			return _object.Where(filter).ToList();// filtereye göre listele
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			return _object.SingleOrDefault(filter); 
		}

		public void Insert(T entity)
		{
			var addedEntity = c.Entry(entity);
			addedEntity.State = EntityState.Added;
			_object.Add(entity);
			c.SaveChanges();
		}

		public List<T> List()
		{
			return _object.ToList();
			
		}

		public void Update(T entity)
		{
			var updatedEntity = c.Entry(entity);
			updatedEntity.State = EntityState.Modified;
			c.SaveChanges();
		}
	}
}
