using AssistantBot.Domain.Entities;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");

        builder.Property(l => l.Id)
            .HasColumnName("id");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Latitude)
            .HasColumnName("latitude");
        
        builder.Property(l => l.Longitude)
            .HasColumnName("longitude");

        builder.Property(l => l.CreatedAt)
            .HasColumnName("created_at");

        builder.HasOne(l => l.User)
            .WithOne(l => l.Location)
            .HasForeignKey<Location>(l => l.UserId);
    }
}