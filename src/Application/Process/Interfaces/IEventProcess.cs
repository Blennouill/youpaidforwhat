using ShareFlow.Application.Models;
using ShareFlow.Application.Process.Interfaces;

namespace ShareFlow.Application.Process.Interfaces
{
    public interface IEventProcess : IResourceProcess<EventModel>
    {
    }
}