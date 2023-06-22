using Mapster;

namespace MicroServicesDemo.PlatformService.Profiles;

public class PrimitiveProfile : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Guid, string>()
              .MapWith(guid => guid.ToString("N"));
    }
}
