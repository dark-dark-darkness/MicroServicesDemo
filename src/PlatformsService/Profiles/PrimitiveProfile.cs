using Mapster;

namespace MicroServicesDemo.PlatformsService.Profiles;

public class PrimitiveProfile : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Guid, string>()
              .MapWith(guid => guid.ToString("N"));
    }
}
