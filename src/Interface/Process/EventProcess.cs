﻿using AutoMapper;
using ShareFlow.Core.Services.Interface;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Tools;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;

namespace ShareFlow.Interface.Process
{
    public class EventProcess : IEventProcess
    {
        private readonly IEventService _entityService;
        private readonly IMapper _mapper;

        public EventProcess(IEventService service, IMapper mapper)
        {
            _entityService = service;
            _mapper = mapper;
        }

        public EventModel Create(EventModel pEventModel)
        {
            string lConvertedTitle = pEventModel.Title.Substring(0, (pEventModel.Title.Length < 20 ? pEventModel.Title.Length : 20)).ReplaceAccentedCharacter();

            pEventModel.ReadingUrl = string.Concat(lConvertedTitle, "-", System.Guid.NewGuid().ToString().Replace("-", ""));
            pEventModel.Url = string.Concat(lConvertedTitle, "-", System.Guid.NewGuid().ToString().Replace("-", ""));

            if (this.GetByUrl(pEventModel.ReadingUrl) != null || this.GetByUrl(pEventModel.Url) != null)
                this.Create(pEventModel);

            var lEvent = _entityService.Create(_mapper.Map<EventModel, Event>(pEventModel));

            return _mapper.Map<Event, EventModel>(lEvent);
        }

        public EventModel GetByUrl(string url)
        {
            var lEvent = _entityService.GetByUrl(url);

            return _mapper.Map<Event, EventModel>(lEvent);
        }
    }
}