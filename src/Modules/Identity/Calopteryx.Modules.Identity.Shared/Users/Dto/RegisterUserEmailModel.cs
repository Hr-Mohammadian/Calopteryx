namespace Calopteryx.Modules.Identity.Shared.Users.Dto;

public class RegisterUserEmailModel
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Url { get; set; } = default!;
}