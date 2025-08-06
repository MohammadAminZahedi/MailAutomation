using MailAutomation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure.Mapping
{
    internal class MailMapping : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder.Property(x=>x.IsRemoved).HasDefaultValue(false);

            builder.HasMany(x => x.Replies).WithOne(x => x.ParentMail)
                .HasForeignKey(x => x.ParentMailId).HasPrincipalKey(x => x.MailId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
