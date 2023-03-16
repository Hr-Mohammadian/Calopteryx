﻿namespace Calopteryx.BuildingBlocks.Infrastructures.Localization;

public class LocalizationSettings
{
    public bool? EnableLocalization { get; set; }
    public string? ResourcesPath { get; set; }
    public string[]? SupportedCultures { get; set; }
    public string? DefaultRequestCulture { get; set; }
    public bool? FallbackToParent { get; set; }
}