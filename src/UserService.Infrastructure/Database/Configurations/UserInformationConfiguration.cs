using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Database.Configurations;

public class UserInformationConfiguration : IEntityTypeConfiguration<UserInformation>
{
    public void Configure(EntityTypeBuilder<UserInformation> builder)
    {
        builder
            .ToTable(nameof(UserInformation), UserServiceDbContext.Schema);

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<UserInformation>(x => x.UserId);

        builder
            .Property(x => x.Gender)
            .HasConversion<short>();

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(254);

        builder
            .Property(x => x.Lastname)
            .HasMaxLength(254);

        builder
            .Property(x => x.Ort)
            .HasMaxLength(254);

        builder
            .HasIndex(x => x.UserId)
            .IsUnique();
    }
}
