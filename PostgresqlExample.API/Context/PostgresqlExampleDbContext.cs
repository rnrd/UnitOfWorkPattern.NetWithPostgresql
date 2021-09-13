using Microsoft.EntityFrameworkCore;
using PostgresqlExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresqlExample.Data.Context
{
    public class PostgresqlExampleDbContext : DbContext
    {
        public PostgresqlExampleDbContext(DbContextOptions<PostgresqlExampleDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Now the configurations we made ArticleConfiguration.cs will be launched.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresqlExampleDbContext).Assembly);
        }
    }
}
