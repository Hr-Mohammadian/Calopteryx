using Calopteryx.BuildingBlocks.Abstractions.Interfaces;

namespace Calopteryx.BuildingBlocks.Abstractions.Mailing;

public interface IMailService : ITransientService
{
    Task SendAsync(MailRequest request, CancellationToken ct);
}