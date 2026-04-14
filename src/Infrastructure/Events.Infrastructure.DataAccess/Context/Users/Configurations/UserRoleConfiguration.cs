using Events.Domain.Aggregates.Users;
using Events.Domain.Aggregates.Users.Constraints;
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
            .HasMaxLength(UserConstrains.Role.MaxLength)
            .IsRequired();

        builder.HasData(UserRole.Admin);
        builder.HasData(UserRole.User);
    }
}