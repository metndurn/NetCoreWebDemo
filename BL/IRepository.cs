using System.Linq.Expressions;

namespace BL
{
	public interface IRepository<T> where T : class/*sart kosarak class oldugunu belirttik*/
	{
		List<T> GetAll();
		List<T> GetAll(Expression<Func<T, bool>> expression);
		T Get();
		T Get(Expression<Func<T, bool>> expression);//bir veya birden fazla linqu sorgusu yapabiliriz
		T Find(int id);
		int Add(T entity);
		int Update(T entity);
		int Remove(T entity);
		Task<T> GetByAsync();
		Task<IEnumerable<T>> GetAllByAsync();

	}
}
