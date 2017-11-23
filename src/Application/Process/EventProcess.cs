using AutoMapper;
using ShareFlow.Application.Models;
using ShareFlow.Application.Process;
using ShareFlow.Application.Process.Interfaces;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Domain.Tools;

namespace ShareFlow.Domain.Services
{
    public class EventProcess : ResourceProcess<EventModel, Event>, IEventProcess
    {
        public EventProcess(IEntityService<Event> service, IMapper mapper) : base(service, mapper)
        {
        }

        public override EventModel Create(EventModel pEvent)
        {
            string lConvertedTitle = pEvent.Title.Substring(0, (pEvent.Title.Length < 20 ? pEvent.Title.Length : 20)).ReplaceAccentedCharacter();

            pEvent.ReadingURL = string.Concat(lConvertedTitle, System.Guid.NewGuid().ToString().Replace("-", ""));
            pEvent.WrittingURL = string.Concat(lConvertedTitle, System.Guid.NewGuid().ToString().Replace("-", ""));

            return base.Create(pEvent);
        }
    }
}