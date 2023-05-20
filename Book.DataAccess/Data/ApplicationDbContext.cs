﻿using System;
using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Category> Category { get; set; }

	}
}

