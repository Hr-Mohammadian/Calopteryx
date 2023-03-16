using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Abstractions.Validation;
using Calopteryx.Modules.Catalog.Core.Brands.Entities;
using Calopteryx.Modules.Catalog.Core.Products.Entities;
using Calopteryx.Modules.Catalog.Core.Products.Requests;
using Calopteryx.Modules.Catalog.Core.Products.Specs;
using Calopteryx.Modules.Catalog.Shared.Products.Dto;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Calopteryx.Modules.Catalog.Core.Products.Validators;

public class UpdateProductRequestValidator : CustomValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator(IReadRepository<Product> productRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateProductRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (product, name, ct) =>
                    await productRepo.GetBySpecAsync(new ProductByNameSpec(name), ct)
                        is not Product existingProduct || existingProduct.Id == product.Id)
                .WithMessage((_, name) => T["Product {0} already Exists.", name]);

        RuleFor(p => p.Rate)
            .GreaterThanOrEqualTo(1);

        RuleFor(p => p.Image)
            .InjectValidator();

        RuleFor(p => p.BrandId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await brandRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Brand {0} Not Found.", id]);
    }
}