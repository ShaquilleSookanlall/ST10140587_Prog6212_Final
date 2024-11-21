using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ST10140587_Prog6212_Part2.Models;

namespace ST10140587_Prog6212_Part2.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<User> User { get; set; }

		public DbSet<Claim> Claims { get; set; }
	}
}