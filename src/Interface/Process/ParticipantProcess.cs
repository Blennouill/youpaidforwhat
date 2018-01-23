using AutoMapper;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Infrastructure.Data.Extensions;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShareFlow.Interface.Process
{
    public class ParticipantProcess : ResourceProcess<ParticipantModel, Participant>, IParticipantProcess
    {
        private readonly IEntityService<Event> _eventService;

        public ParticipantProcess(IEntityService<Participant> participantService,
                                    IMapper mapper,
                                    IEntityService<Event> eventService) : base(participantService, mapper)
        {
            _eventService = eventService;
        }

        public ParticipantModel Create(ParticipantModel participantModel, string urlEvent)
        {
            var lEvent = _eventService.AsQuery().FilterBy(pEvent => pEvent.Url == urlEvent).FirstOrDefault();

            if (lEvent == null)
                return null;

            var participant = _mapper.Map<ParticipantModel, Participant>(participantModel);
            participant.EventId = lEvent.Id;
            participant = _entityService.Create(participant);
            
            return _mapper.Map<Participant, ParticipantModel>(participant);
        }

        /// <summary>
        /// Return participant's list of the specific event
        /// </summary>
        /// <param name="urlEvent">url of the event</param>
        public IReadOnlyList<ParticipantModel> List(string urlEvent)
        {
            var lEvent = _eventService.AsQuery().FilterBy(pEvent => pEvent.Url == urlEvent || pEvent.ReadingUrl == urlEvent).FirstOrDefault();

            if (lEvent == null)
                return null;

            return _mapper.Map<IEnumerable<Participant>, List<ParticipantModel>>(_entityService.AsQuery().FilterBy(pParticipant => pParticipant.EventId == lEvent.Id).ToList());
        }
    }
}