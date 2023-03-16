

using System.Threading;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Interfaces;
using Calopteryx.Modules.Identity.Core.Tokens.Requests;
using Calopteryx.Modules.Identity.Core.Tokens.Responses;

namespace Calopteryx.Modules.Identity.Core.Tokens.Services;

public interface ITokenService : ITransientService
{
    Task<TokenResponse> GetTokenAsync(TokenRequest request, string ipAddress, CancellationToken cancellationToken);

    Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest request, string ipAddress);
}