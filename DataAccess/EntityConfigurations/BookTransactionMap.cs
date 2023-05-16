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
    public class BookTransactionMap : IEntityTypeConfiguration<BookTransaction>
    {
        public void Configure(EntityTypeBuilder<BookTransaction> builder)
        {
            builder.ToTable("BookTransactions");
            builder.HasKey(bt => bt.BookTransactionId);
            builder.Property(bt => bt.BookTransactionId).UseIdentityColumn(1, 1);
            builder.Property(bt => bt.DueDate).HasColumnType("datetime");
            builder.Property(bt => bt.IssueDate).HasColumnType("datetime");
            builder.Property(bt => bt.ReturnDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(bt => bt.BookId).HasColumnType("int");
            builder.Property(bt => bt.MemberId).HasColumnType("int");
        }
    }
}
