using Calopteryx.BuildingBlocks.Abstractions.Domain;
using Calopteryx.BuildingBlocks.Abstractions.Interfaces;

namespace Calopteryx.BuildingBlocks.Abstractions.FileStorage;

public interface IFileStorageService : ITransientService
{
    public Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType, CancellationToken cancellationToken = default)
    where T : class;

    public void Remove(string? path);
}