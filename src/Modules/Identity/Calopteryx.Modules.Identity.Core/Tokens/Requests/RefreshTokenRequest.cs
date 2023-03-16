namespace Calopteryx.Modules.Identity.Core.Tokens.Requests;

public record RefreshTokenRequest(string Token, string RefreshToken);