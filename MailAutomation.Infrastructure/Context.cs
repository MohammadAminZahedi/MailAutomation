using MailAutomation.Domain;
using MailAutomation.Infrastructure.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MailAutomation.Infrastructure
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Mail> Mails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; initial catalog=Test_MailAutomationDB; integrated security=true; trust server certificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new MailMapping());
            base.OnModelCreating(builder);
        }
    }
}
