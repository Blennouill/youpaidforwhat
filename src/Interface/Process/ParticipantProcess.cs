﻿using AutoMapper;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
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

        public ParticipantModel Create(ParticipantModel pParticipantModel, string urlEvent)
        {
            var lEvent = _eventService.GetBy(pEvent => pEvent.Url == urlEvent).FirstOrDefault();
            ParticipantModel lParticipantModel = null;

            if (lEvent != null)
            {
                var lParticipant = _mapper.Map<ParticipantModel, Participant>(pParticipantModel);
                lParticipant.IdEvenement = lEvent.Id;
                lParticipant = _entityService.Create(lParticipant);

                lParticipantModel = _mapper.Map<Participant, ParticipantModel>(lParticipant);
            }

            return lParticipantModel;
        }
    }
}