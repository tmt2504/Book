using System;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

	}
}

