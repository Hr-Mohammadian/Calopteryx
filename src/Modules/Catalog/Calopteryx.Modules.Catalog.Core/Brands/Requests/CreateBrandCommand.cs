using Calopteryx.BuildingBlocks.Abstractions.Commands;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Abstractions.Validation;
using Calopteryx.Modules.Catalog.Core.Brands.Entities;
using Calopteryx.Modules.Catalog.Core.Brands.Specs;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Calopteryx.Modules.Catalog.Core.Brands.Requests;

public class CreateBrandCommand : ICommand
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateBrandCommandValidator : CustomValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator(IReadRepository<Brand> repository, IStringLocalizer<CreateBrandCommandValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new BrandByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Brand {0} already Exists.", name]);
}

public class CreateBrandCommandHandler : ICommandHandler<CreateBrandCommand>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Brand> _repository;

    public CreateBrandCommandHandler(IRepositoryWithEvents<Brand> repository) => _repository = repository;

    public async Task HandleAsync(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new Brand(request.Name, request.Description);

        await _repository.AddAsync(brand, cancellationToken);

    }
}