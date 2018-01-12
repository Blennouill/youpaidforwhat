using AutoMapper;
using ShareFlow.Application.Models;
using ShareFlow.Application.Process;
using ShareFlow.Application.Process.Interfaces;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;

namespace ShareFlow.Domain.Services
{
    public class ParticipantProcess : ResourceProcess<ParticipantModel, Participant>, IParticipantProcess
    {
        private readonly IEntityService<Event> _EventService;

        public ParticipantProcess(IEntityService<Participant> service,
                                    IMapper mapper,
                                    IEntityService<Event> eventService) : base(service, mapper)
        {
            _EventService = eventService;
        }

        public override ParticipantModel Create(ParticipantModel participant)
        {
            var lEvent = _EventService.GetBy(pEvent => pEvent.WrittingURL == participant.UrlWrittingEvent);

            if (lEvent == null)


            return base.Create(obj);
        }
    }
}