using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Entities;

namespace TestTask.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(userEntity => userEntity.Id);
            builder.Property(userEntity => userEntity.Id).ValueGeneratedOnAdd();

            builder.Property(userEntity => userEntity.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(userEntity => userEntity.BirthDate)
                .IsRequired();

            builder.Property(userEntity => userEntity.IsMarried)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(userEntity => userEntity.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(userEntity => userEntity.Salary)
                .HasPrecision(10, 2)
                .IsRequired();
        }
    }
}
