using FluentValidation;

using MicroServicesDemo.PlatformsService.Shared.Dtos.Platforms;

namespace MicroServicesDemo.PlatformsService.Validations.Platforms;

public class PlatformCreateDtoValidator : AbstractValidator<PlatformCreateDto>
{
    public PlatformCreateDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Publisher).NotEmpty();
        RuleFor(p => p.Cost).NotEmpty();
    }
}
