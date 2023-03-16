namespace Calopteryx.Modules.Identity.Core.Users.Requests.Password;

public class ResetPasswordRequest
{
    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Token { get; set; }
}