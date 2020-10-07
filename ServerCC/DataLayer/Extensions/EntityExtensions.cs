using System.Linq;
using DataLayer.Model;

namespace DataLayer.Extensions
{
	public static class EntityExtensions
	{
		public static IQueryable<T> OnlyActive<T>(this IQueryable<T> query)
		where T : BaseEntity
		{
			return query.Where(i => !i.IsDeleted);
		}

	}
}
