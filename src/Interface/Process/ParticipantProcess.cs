using AutoMapper;
using ShareFlow.Core.Services.Interface;
using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using System.Collections.Generic;

namespace ShareFlow.Interface.Process
{
    public class ParticipantProcess : ResourceProcess<ParticipantModel, Participant>, IParticipantProcess
    {
        private readonly IEventService _eventService;
        private readonly IAccountService _accountService;

        public ParticipantProcess(IParticipantService participantService,
                                    IMapper mapper,
                                    IEventService eventService,
                                    IAccountService accountService) : base(participantService, mapper)
        {
            _eventService = eventService;
            _accountService = accountService;
        }

        /// <summary>
        /// Create a new participant to an event with initialization of his account
        /// </summary>
        public ParticipantModel CreateNewParticipant(ParticipantModel participantModel, string urlEvent)
        {
            var lEvent = _eventService.GetByUrl(urlEvent);

            if (lEvent == null)
                return null;

            var participant = _mapper.Map<ParticipantModel, Participant>(participantModel);
            participant.EventId = lEvent.Id;
            participant = _entityService.Create(participant);

            _accountService.Create(new Account(participant.Id));

            return _mapper.Map<Participant, ParticipantModel>(participant);
        }

        /// <summary>
        /// Return participant's list of the specific event
        /// </summary>
        public IReadOnlyList<ParticipantModel> List(string urlEvent)
        {
            var lEvent = _eventService.GetByAnyUrl(urlEvent);

            if (lEvent == null)
                return null;

            return _mapper.Map<IEnumerable<Participant>, List<ParticipantModel>>(_entityService.FindList(new EqualsParticipantEventIdSpecification(lEvent.Id)));
        }
    }
}