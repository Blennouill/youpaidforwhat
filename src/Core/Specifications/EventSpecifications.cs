using ShareFlow.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ShareFlow.Core.Specifications
{
    /// <summary>
    /// Is used to check if url is equal the event url's or the reading url
    /// </summary>
    public class EqualsToReadingOrWrittingURLSpecification : Specification<Event>
    {
        private readonly string _eventUrl;

        public EqualsToReadingOrWrittingURLSpecification(string eventUrl)
        {
            _eventUrl = eventUrl;
        }

        public override Expression<Func<Event, bool>> ToExpression()
        {
            return lEvent => lEvent.Url == _eventUrl || lEvent.ReadingUrl == _eventUrl;
        }
    }

    /// <summary>
    /// Is used to check if the both event urls parameter is not define already
    /// </summary>
    public class UrlMustBeUniqueSpecification : Specification<Event>
    {
        private readonly Event _event;

        public UrlMustBeUniqueSpecification(Event pEvent)
        {
            _event = pEvent;
        }

        public override Expression<Func<Event, bool>> ToExpression()
        {
            return lEvent => lEvent.Url == _event.Url || lEvent.ReadingUrl == _event.ReadingUrl;
        }
    }

    /// <summary>
    /// Is used to check if url parameter is equal to the main url of an event
    /// </summary>
    public class UrlMustBeEqualToMainUrlSpecification : Specification<Event>
    {
        private readonly string _eventUrl;

        public UrlMustBeEqualToMainUrlSpecification(string eventUrl)
        {
            _eventUrl = eventUrl;
        }

        public override Expression<Func<Event, bool>> ToExpression()
        {
            return lEvent => lEvent.Url == _eventUrl;
        }
    }
}