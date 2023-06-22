using MicroServicesDemo.PlatformService.Data.ValueGenerators;
using MicroServicesDemo.PlatformService.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroServicesDemo.PlatformService.Data.EntityConfigurations;

class PlatformEntityConfiguration : IEntityTypeConfiguration<Platform>
{

    /// <summary>
    ///     Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.ToTable("t_platform");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .HasColumnName("id")
               .HasValueGenerator<SequentialGuidValueGenerator>()
               .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
               .HasColumnName("name");

        builder.Property(p => p.Publisher)
               .HasColumnName("publisher");

        builder.Property(p => p.Cost)
               .HasColumnName("cost");

        builder.HasData(GetSeedData());

    }

    private static Platform[] GetSeedData()
    {
        return new Platform[]
        {
            new ()
            {
                Id = Guid.Parse("08db72726ae3bbc500155dd9eab40000"), Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"
            },
            new ()
            {
                Id = Guid.Parse("08db72726ae3bbce00155dd9eab40000"), Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free"
            },
            new ()
            {
                Id = Guid.Parse("08db72726ae3bbcf00155dd9eab40000"), Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"
            }
        };
    }
}
