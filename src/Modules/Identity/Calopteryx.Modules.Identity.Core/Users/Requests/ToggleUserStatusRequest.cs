namespace Calopteryx.Modules.Identity.Core.Users.Requests;

public class ToggleUserStatusRequest
{
    public bool ActivateUser { get; set; }
    public string? UserId { get; set; }
}
