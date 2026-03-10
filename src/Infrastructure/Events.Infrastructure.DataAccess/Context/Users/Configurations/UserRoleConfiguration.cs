using Events.Domain.Aggregates.UserAggregate;
using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.DataAccess.Context.Users.Configurations;

/// <inheritdoc />
public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UsersRoles");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .HasMaxLength(DomainConstraints.User.Role.MaxLength)
            .IsRequired();

        builder.HasData(UserRole.Admin);
        builder.HasData(UserRole.User);
    }
}