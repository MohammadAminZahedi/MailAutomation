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
            builder.Property(x=>x.IsRemovedFromSender).HasDefaultValue(false);
            builder.Property(x=>x.IsRemovedFromReceiver).HasDefaultValue(false);
        }
    }
}
