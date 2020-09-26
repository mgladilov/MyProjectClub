using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class DataBaseContext : DbContext
	{
		public DataBaseContext(DbContextOptions<DataBaseContext> options)
			: base(options)
		{

		}

		public DbSet<Computer> Computers { get; set; }
		public DbSet<ComputerGroup> ComputerGroups { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<TariffInterval> TariffIntervals { get; set; }


		//public override int SaveChanges()
		//{
		//	foreach (var entry in ChangeTracker.Entries())
		//	{
		//		if(entry == null)
		//			continue;


		//		if (entry.Entity is BaseEntity model)
		//		{
		//			if (model.Id > 0)
		//				entry.State = EntityState.Modified;
		//			else
		//			{
		//				entry.State = EntityState.Added;
		//			}

		//		}
		//	}
		//	return base.SaveChanges();
		//}
	}
}