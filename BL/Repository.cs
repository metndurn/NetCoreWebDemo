using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/*KATMANLI MIMARI KULLANARAK BIRBIRLERINE REFERANS ETTIK VE SART KOSARAK NEW YAPMASINA OLANAK SAGLADIK*/
namespace BL
{
	public class Repository<T> : IRepository<T> where T : class, IEntity, new()
	{
		private DataBaseContext context;
		private DbSet<T> _objectSet;
		public Repository()
		{
			if (context == null)
			{
				context = new DataBaseContext();
				_objectSet = context.Set<T>();
			}
		}
		public int Add(T entity)//ekleme metodudur
		{
			_objectSet.Add(entity);
			return context.SaveChanges();
		}

		public T Find(int id)//gelen id ye gore bulup gosterecek metoddur
		{
			return _objectSet.Find(id);
		}

		public T Get()
		{
			throw new NotImplementedException();
		}

		public T Get(Expression<Func<T, bool>> expression)//expression buna gore oldugu kaydı gerı getırır
		{
			return _objectSet.FirstOrDefault(expression);
		}

		public List<T> GetAll(int id)//geri listeleri dondurur
		{
			return _objectSet.ToList();
		}

		public List<T> GetAll(Expression<Func<T, bool>> expression)//expression ile filtreleme yapılabilinir
		{
			return _objectSet.Where(expression).ToList();
		}

		public List<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> GetAllByAsync()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByAsync()
		{
			throw new NotImplementedException();
		}

		public int Remove(T entity)//kayıtları sıler
		{
			_objectSet.Remove(entity);
			return context.SaveChanges();
		}

		public int Update(T entity)//etkilenen kayıt sayısını dondurur
		{
			_objectSet.Update(entity);
			return context.SaveChanges();
		}
	}
}
