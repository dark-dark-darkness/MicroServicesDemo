using MassTransit;

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace MicroServicesDemo.PlatformsService.Data.ValueGenerators;

public sealed class SequentialGuidValueGenerator : ValueGenerator<Guid>
{


    public override bool GeneratesTemporaryValues => false;

    public override Guid Next(EntityEntry entry)
    {
        return NewId.NextSequentialGuid();
    }
}
