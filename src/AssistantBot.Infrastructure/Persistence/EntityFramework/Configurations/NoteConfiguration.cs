using AssistantBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Configurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("notes");

        builder.Property(n => n.Id)
            .HasColumnName("id");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title)
            .HasColumnName("title");

        builder.Property(n => n.Text)
            .HasColumnName("text");

        builder.Property(n => n.CreatedAt)
            .HasColumnName("created_at");

        builder.HasOne(n => n.User)
            .WithMany(n => n.Notes)
            .HasForeignKey(n => n.UserId);
    }
}