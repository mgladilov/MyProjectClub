using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class DataBaseContext : DbContext
	{
		public DbSet<Computer> Computers { get; set; }
		public DbSet<ComputerGroup> ComputerGroups { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ComputerGroup>()
				.HasMany(i => i.Computers)
				.WithOne(i => i.ComputerGroup)
				.HasForeignKey(i => i.IdGroup);


			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-2KBGUT9;Initial Catalog=gc;Integrated Security=True");
			base.OnConfiguring(optionsBuilder);
		}
	}
}