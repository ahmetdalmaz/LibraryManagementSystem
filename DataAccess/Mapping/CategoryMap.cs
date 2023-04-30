using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId).UseIdentityColumn(1, 1);
            builder.Property(c => c.CategoryName).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(c => c.CategoryState).HasColumnType("bit");
            builder.HasMany(c=>c.Books).WithOne(b=>b.Category).HasForeignKey(b=>b.CategoryId).HasPrincipalKey(c=>c.CategoryId);
         
        }
    }
}
