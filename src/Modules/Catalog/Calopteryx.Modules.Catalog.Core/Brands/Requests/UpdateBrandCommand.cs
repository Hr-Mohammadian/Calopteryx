using Calopteryx.BuildingBlocks.Abstractions.Commands;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Abstractions.Validation;
using Calopteryx.BuildingBlocks.Infrastructures.Exceptions;
using Calopteryx.Modules.Catalog.Core.Brands.Entities;
using Calopteryx.Modules.Catalog.Core.Brands.Specs;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Calopteryx.Modules.Catalog.Core.Brands.Requests;

public class UpdateBrandCommand : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateBrandCommandValidator : CustomValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator(IRepository<Brand> repository, IStringLocalizer<UpdateBrandCommandValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (brand, name, ct) =>
                    await repository.GetBySpecAsync(new BrandByNameSpec(name), ct)
                        is not Brand existingBrand || existingBrand.Id == brand.Id)
                .WithMessage((_, name) => T["Brand {0} already Exists.", name]);
}

public class UpdateBrandCommandHandler : ICommandHandler<UpdateBrandCommand>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Brand> _repository;
    private readonly IStringLocalizer _t;

    public UpdateBrandCommandHandler(IRepositoryWithEvents<Brand> repository, IStringLocalizer<UpdateBrandCommandHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task HandleAsync(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = brand
        ?? throw new NotFoundException(_t["Brand {0} Not Found.", request.Id]);

        brand.Update(request.Name, request.Description);

        await _repository.UpdateAsync(brand, cancellationToken);

    }
}