using AssistantBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(u => u.Id)
            .HasColumnName("id");

        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.ChatId)
            .HasColumnName("chat_id");

        builder.HasIndex(u => u.ChatId)
            .IsUnique();
        
        builder.Property(u => u.Username)
            .HasColumnName("username");

        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at");
    }
}