using System;

namespace Calopteryx.Modules.Identity.Core.Tokens.Responses;

public record TokenResponse(string Token, string RefreshToken, DateTime RefreshTokenExpiryTime);