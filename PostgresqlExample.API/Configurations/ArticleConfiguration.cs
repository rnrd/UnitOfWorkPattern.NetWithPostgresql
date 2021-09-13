using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgresqlExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresqlExample.Data.Configurations
{
    //This class is for properties configuration of Article Class. This is a convenience coming with fluent API in .net.
    //Do not forget that properties configurations can be set with annotations in article class.
    class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(s => s.Title).HasMaxLength(300);
            builder.Property(s => s.Description).HasMaxLength(1000);
        }
    }
}
