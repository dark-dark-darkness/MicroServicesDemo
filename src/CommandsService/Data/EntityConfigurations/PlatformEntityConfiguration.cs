using MicroServicesDemo.CommandsService.Data.ValueGenerators;
using MicroServicesDemo.CommandsService.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroServicesDemo.CommandsService.Data.EntityConfigurations;

class PlatformEntityConfiguration : IEntityTypeConfiguration<Platform>
{

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

        builder.HasMany(p => p.Commands)
               .WithOne(c => c.Platform)
               .HasForeignKey(c => c.PlatformId);

        //builder.HasData(GetSeedData());
    }

    private static Platform[] GetSeedData()
    {
        return new Platform[]
        {
            new ()
            {
                Id = Guid.Parse("08db72726ae3bbc500155dd9eab40000"), Name = "Dot Net"
            },
            new ()
            {
                Id = Guid.Parse("08db72726ae3bbce00155dd9eab40000"), Name = "SQL Server Express"
            },
            new ()
            {
                Id = Guid.Parse("08db72726ae3bbcf00155dd9eab40000"), Name = "Kubernetes"
            }
        };
    }
}
