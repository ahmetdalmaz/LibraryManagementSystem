using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.AuthorId);
            builder.Property(a => a.AuthorId).UseIdentityColumn(1, 1);
            builder.Property(a => a.AuthorName).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(a => a.AuthorSurname).HasColumnType("varchar").HasMaxLength(60);
            builder.Property(a => a.AuthorState).HasColumnType("bit");

            builder.HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey(b => b.AuthorId).HasPrincipalKey(a => a.AuthorId);
        }
    }
}
