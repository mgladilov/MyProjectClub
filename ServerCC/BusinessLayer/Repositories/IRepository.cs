using System.Linq;
using DataLayer.Model;

namespace BusinessLayer.Repositories
{
	public interface IRepository<T> where T : BaseEntity
	{
		T Get(int id);
		IQueryable<T> GetAll();
		T Save(T entity);
		void Delete(int id);
	}
}