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
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.SentMails).WithOne(x => x.Sender)
                .HasForeignKey(x => x.SenderId).HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ReceivedMails).WithOne(x => x.Receiver)
                .HasForeignKey(x => x.ReceiverId).HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
