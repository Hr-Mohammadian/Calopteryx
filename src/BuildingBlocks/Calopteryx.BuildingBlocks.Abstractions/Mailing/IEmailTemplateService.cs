using Calopteryx.BuildingBlocks.Abstractions.Interfaces;

namespace Calopteryx.BuildingBlocks.Abstractions.Mailing;

public interface IEmailTemplateService : ITransientService
{
    string GenerateEmailTemplate<T>(string templateName, T mailTemplateModel);
}