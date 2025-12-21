using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Hilfstexte;

namespace UserService.Infrastructure.Database.Configurations;

public class MusicGenreConfiguration : IEntityTypeConfiguration<MusicGenre>
{
    public void Configure(EntityTypeBuilder<MusicGenre> builder)
    {
        builder
            .ToTable(nameof(MusicGenre), UserServiceDbContext.Schema);

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .HasOne<MusicGenre>()
            .WithMany()
            .HasForeignKey(x => x.ParentId);
    }
}
