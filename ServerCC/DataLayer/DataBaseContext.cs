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
		public DbSet<User> Users { get; set; }
		public DbSet<UsersGroup> UserGroups { get; set; }
		
	}
}