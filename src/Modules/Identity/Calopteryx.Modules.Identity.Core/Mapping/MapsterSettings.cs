using Calopteryx.BuildingBlocks.Abstractions.Authorization;
using Calopteryx.Modules.Identity.Core.RoleClaims.Entities;
using Calopteryx.Modules.Identity.Core.RoleClaims.Responses;
using Calopteryx.Modules.Identity.Shared.RoleClaims.Dto;
using Mapster;

namespace Calopteryx.Modules.Identity.Core.Mapping;

public class MapsterSettings
{
    public static void Configure()
    {
        // here we will define the type conversion / Custom-mapping
        // More details at https://github.com/MapsterMapper/Mapster/wiki/Custom-mapping

        // This one is actually not necessary as it's mapped by convention
        // TypeAdapterConfig<Product, ProductDto>.NewConfig().Map(dest => dest.BrandName, src => src.Brand.Name);
        TypeAdapterConfig<ApplicationRoleClaim, PermissionDto>.NewConfig()
            .Map(dest => dest.Permission, src => src.ClaimValue);
        TypeAdapterConfig<CalopteryxPermission, RoleClaimResponse>.NewConfig()
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Group, src => src.Group)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Selected, src => src.Selected)
            .Map(dest => dest.RoleId, src => src.RoleId)
            .Map(dest => dest.Type, src => src.Type);

        TypeAdapterConfig<ApplicationRoleClaim, RoleClaimResponse>.NewConfig()
            .Map(dest => dest.Value, src => src.ClaimValue)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Type, src => src.ClaimType)
            .Map(dest => dest.RoleId, src => src.RoleId);
    }
}