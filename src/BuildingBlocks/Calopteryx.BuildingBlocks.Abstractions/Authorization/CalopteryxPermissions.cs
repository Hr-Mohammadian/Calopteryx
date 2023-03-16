using System.Collections.ObjectModel;

namespace Calopteryx.BuildingBlocks.Abstractions.Authorization;

public static class CalopteryxAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class CalopteryxResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
    public const string Brands = nameof(Brands);
}

public static class CalopteryxPermissions
{
    private static readonly CalopteryxPermission[] _all = new CalopteryxPermission[]
    {
        new("View Dashboard", CalopteryxAction.View, CalopteryxResource.Dashboard),
        new("View Hangfire", CalopteryxAction.View, CalopteryxResource.Hangfire),
        new("View Users", CalopteryxAction.View, CalopteryxResource.Users),
        new("Search Users", CalopteryxAction.Search, CalopteryxResource.Users),
        new("Create Users", CalopteryxAction.Create, CalopteryxResource.Users),
        new("Update Users", CalopteryxAction.Update, CalopteryxResource.Users),
        new("Delete Users", CalopteryxAction.Delete, CalopteryxResource.Users),
        new("Export Users", CalopteryxAction.Export, CalopteryxResource.Users),
        new("View UserRoles", CalopteryxAction.View, CalopteryxResource.UserRoles),
        new("Update UserRoles", CalopteryxAction.Update, CalopteryxResource.UserRoles),
        new("View Roles", CalopteryxAction.View, CalopteryxResource.Roles),
        new("Create Roles", CalopteryxAction.Create, CalopteryxResource.Roles),
        new("Update Roles", CalopteryxAction.Update, CalopteryxResource.Roles),
        new("Delete Roles", CalopteryxAction.Delete, CalopteryxResource.Roles),
        new("View RoleClaims", CalopteryxAction.View, CalopteryxResource.RoleClaims),
        new("Update RoleClaims", CalopteryxAction.Update, CalopteryxResource.RoleClaims),
        new("View Products", CalopteryxAction.View, CalopteryxResource.Products, IsBasic: true),
        new("Search Products", CalopteryxAction.Search, CalopteryxResource.Products, IsBasic: true),
        new("Create Products", CalopteryxAction.Create, CalopteryxResource.Products),
        new("Update Products", CalopteryxAction.Update, CalopteryxResource.Products),
        new("Delete Products", CalopteryxAction.Delete, CalopteryxResource.Products),
        new("Export Products", CalopteryxAction.Export, CalopteryxResource.Products),
        new("View Brands", CalopteryxAction.View, CalopteryxResource.Brands, IsBasic: true),
        new("Search Brands", CalopteryxAction.Search, CalopteryxResource.Brands, IsBasic: true),
        new("Create Brands", CalopteryxAction.Create, CalopteryxResource.Brands),
        new("Update Brands", CalopteryxAction.Update, CalopteryxResource.Brands),
        new("Delete Brands", CalopteryxAction.Delete, CalopteryxResource.Brands),
        new("Generate Brands", CalopteryxAction.Generate, CalopteryxResource.Brands),
        new("Clean Brands", CalopteryxAction.Clean, CalopteryxResource.Brands),
        new("View Tenants", CalopteryxAction.View, CalopteryxResource.Tenants, IsRoot: true),
        new("Create Tenants", CalopteryxAction.Create, CalopteryxResource.Tenants, IsRoot: true),
        new("Update Tenants", CalopteryxAction.Update, CalopteryxResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", CalopteryxAction.UpgradeSubscription, CalopteryxResource.Tenants, IsRoot: true)
    };

    public static IReadOnlyList<CalopteryxPermission> All { get; } = new ReadOnlyCollection<CalopteryxPermission>(_all);
    public static IReadOnlyList<CalopteryxPermission> Root { get; } = new ReadOnlyCollection<CalopteryxPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<CalopteryxPermission> Admin { get; } = new ReadOnlyCollection<CalopteryxPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<CalopteryxPermission> Basic { get; } = new ReadOnlyCollection<CalopteryxPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record CalopteryxPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public int? Id;
    public string? RoleId;
    public string Name => NameFor(Action, Resource);
    public string Description = Description;
    public string Group = Resource;
    public string Type = Action;
    public string Value = NameFor(Action, Resource);
    public bool Selected = false;
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
