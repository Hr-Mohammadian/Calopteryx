using Calopteryx.BuildingBlocks.Abstractions.Time;

namespace Calopteryx.BuildingBlocks.Infrastructures.Time;

internal sealed class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}