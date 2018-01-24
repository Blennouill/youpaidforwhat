﻿using AutoMapper;
using ShareFlow.Core.Services.Interface;
using ShareFlow.Core.Specifications;
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
        private readonly IEventService _eventService;

        public ParticipantProcess(IParticipantService participantService,
                                    IMapper mapper,
                                    IEventService eventService) : base(participantService, mapper)
        {
            _eventService = eventService;
        }

        public ParticipantModel Create(ParticipantModel participantModel, string urlEvent)
        {
            var lEvent = _eventService.GetByUrl(urlEvent);

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
            var lEvent = _eventService.GetByAnyUrl(urlEvent);

            if (lEvent == null)
                return null;

            return _mapper.Map<IEnumerable<Participant>, List<ParticipantModel>>(_entityService.FindList(new EqualsParticipantEventIdSpecification(lEvent.Id)));
        }
    }
}