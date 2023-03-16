using System.Collections.Generic;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Interfaces;
using Calopteryx.BuildingBlocks.Abstractions.Wrapper;
using Calopteryx.Modules.Identity.Core.RoleClaims.Requests;
using Calopteryx.Modules.Identity.Core.RoleClaims.Responses;

namespace Calopteryx.Modules.Identity.Core.RoleClaims.Services
{
    public interface IRoleClaimService : ITransientService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}