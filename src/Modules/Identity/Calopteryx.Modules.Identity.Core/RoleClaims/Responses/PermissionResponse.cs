using System.Collections.Generic;

namespace Calopteryx.Modules.Identity.Core.RoleClaims.Responses
{
    public class PermissionResponse
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<RoleClaimResponse> RoleClaims { get; set; }
    }
}