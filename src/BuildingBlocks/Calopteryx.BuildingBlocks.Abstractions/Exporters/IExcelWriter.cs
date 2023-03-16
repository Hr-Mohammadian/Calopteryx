using Calopteryx.BuildingBlocks.Abstractions.Interfaces;

namespace Calopteryx.BuildingBlocks.Abstractions.Exporters;

public interface IExcelWriter : ITransientService
{
    Stream WriteToStream<T>(IList<T> data);
}