using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;

namespace ShareFlow.Core.Services.Interface
{
    public interface IEventService : IEntityService<Event>
    {
        Event GetByUrl(string url);

        Event GetByAnyUrl(string url);
    }
}