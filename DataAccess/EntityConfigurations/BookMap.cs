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
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.BookId).UseIdentityColumn(1, 1);
            builder.Property(b => b.BookName).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(b=>b.PageCount).HasColumnType("int");
            builder.Property(b => b.BookState).HasColumnType("bit");

            builder.HasMany(b => b.BookTransactions).WithOne(bt => bt.Book).HasForeignKey(bt => bt.BookId).HasPrincipalKey(b => b.BookId);
        }
    }
}
