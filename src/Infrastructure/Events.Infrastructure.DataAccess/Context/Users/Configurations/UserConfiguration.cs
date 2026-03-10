using Events.Domain.Aggregates.UserAggregate;
using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Users.Configurations;

/// <inheritdoc />
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(e => e.Id);

        builder.OwnsOne(e => e.PersonName)
            .Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(DomainConstraints.User.PersonName.MaxLength)
            .IsRequired();

        builder.OwnsOne(e => e.PersonName)
            .Property(x => x.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(DomainConstraints.User.PersonName.MaxLength)
            .IsRequired();

        builder.OwnsOne(e => e.PersonName)
            .Property(x => x.Patronymic)
            .HasColumnName("Patronymic")
            .HasMaxLength(DomainConstraints.User.PersonName.MaxLength);

        builder.OwnsOne(e => e.Email, emailBuilder =>
        {
            emailBuilder.Property(x => x.Value)
                .HasColumnName("Email")
                .HasMaxLength(DomainConstraints.Email.MaxLength)
                .IsRequired();

            emailBuilder.HasIndex(x => x.Value)
                .IsUnique();
        });

        builder.OwnsOne(e => e.Password)
            .Property(x => x.Value)
            .HasColumnName("Password")
            .HasMaxLength(DomainConstraints.Password.MaxLength)
            .IsRequired();

        builder.HasOne(e => e.Role)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(e => e.Role).AutoInclude();

        builder.Property(e => e.AvatarFilename);

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

        builder.Property(e => e.UpdatedAt)
            .IsRequired();
    }
}