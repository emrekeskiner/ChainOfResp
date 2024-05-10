using Microsoft.EntityFrameworkCore;

namespace ChainOfResp.DAL
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=ultrabook;Initial Catalog=ChainOfDb;Integrated Security=True");
		}

		public DbSet<CustomerProcess> CustomerProcesses { get; set; }
	}
}
