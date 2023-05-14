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
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");
            builder.HasKey(m => m.MemberId);
            builder.Property(m => m.MemberId).UseIdentityColumn(1, 1);
            builder.Property(m => m.MemberName).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(m => m.MemberSurname).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(m => m.MemberEmail).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(m => m.MemberPhoneNumber).HasColumnType("char").HasMaxLength(10);
            builder.Property(m => m.MemberState).HasColumnType("bit");

            builder.HasMany(m => m.BookTransactions).WithOne(bt => bt.Member).HasForeignKey(bt => bt.MemberId).HasPrincipalKey(m => m.MemberId);

        }
    }
}
