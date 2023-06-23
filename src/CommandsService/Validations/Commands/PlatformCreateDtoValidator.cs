using FluentValidation;

using MicroServicesDemo.CommandsService.Shared.Dtos.Commands;

namespace MicroServicesDemo.CommandsService.Validations.Commands;

public class CommandCreateDtoValidator : AbstractValidator<CommandCreateDto>
{
    public CommandCreateDtoValidator()
    {
        RuleFor(p => p.HowTo).NotEmpty();
        RuleFor(p => p.CommandLine).NotEmpty();
    }
}
