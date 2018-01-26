using ShareFlow.Core.Services.Interface;
using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Shared.Interfaces;
using System.Linq;

namespace ShareFlow.Domain.Services
{
    public class EventService : EntityService<Event>, IEventService
    {
        public EventService(IRepository<Event> repository) : base(repository)
        {
        }

        public Event GetByUrl(string url)
        {
            return this._repository.Find(new UrlMustBeEqualToMainUrlSpecification(url)).FirstOrDefault();
        }

        public Event GetByAnyUrl(string url)
        {
            return this._repository.Find(new EqualsToReadingOrWrittingURLSpecification(url)).FirstOrDefault();
        }
    }
}