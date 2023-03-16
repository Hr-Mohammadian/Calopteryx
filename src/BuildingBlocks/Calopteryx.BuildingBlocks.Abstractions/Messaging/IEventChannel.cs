using System.Threading.Channels;
using Calopteryx.BuildingBlocks.Abstractions.Events;

namespace Calopteryx.BuildingBlocks.Abstractions.Messaging;

public interface IEventChannel
{
    ChannelReader<IEvent> Reader { get; }
    ChannelWriter<IEvent> Writer { get; }
}