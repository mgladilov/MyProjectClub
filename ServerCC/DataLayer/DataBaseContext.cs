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
		
	}
}