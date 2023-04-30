using System;
using BookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Category> Category { get; set; }

	}
}

