using BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Web.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.Property(x => x.Lastname).IsRequired();
            builder.Property(x => x.Lastname).HasMaxLength(200);

            builder.HasMany(x => x.Accounts).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            
            
        }
    }
}
