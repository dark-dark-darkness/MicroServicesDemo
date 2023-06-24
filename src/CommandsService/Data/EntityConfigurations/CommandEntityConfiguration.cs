using MicroServicesDemo.CommandsService.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroServicesDemo.CommandsService.Data.EntityConfigurations;

class CommandEntityConfiguration : IEntityTypeConfiguration<Command>
{

    public void Configure(EntityTypeBuilder<Command> builder)
    {
        builder.HasOne(c => c.Platform)
               .WithMany(p => p.Commands)
               .HasForeignKey(c => c.PlatformId);

        //builder.HasData(GetSeedData());

    }

    private static Command[] GetSeedData()
    {
        return new Command[]
        {
            new () { Id = Guid.Parse("8bc37f22429d4f259bc3634d389007b4"), HowTo = "Build a .net project", CommandLine = "commandLine", PlatformId = Guid.Parse("08db72726ae3bbc500155dd9eab40000") }
        };
    }
}
