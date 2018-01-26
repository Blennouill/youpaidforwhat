using ShareFlow.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ShareFlow.Core.Specifications
{
    /// <summary>
    /// Is used to check the equality between the event id of a participant
    /// </summary>
    public class EqualsParticipantEventIdSpecification : Specification<Participant>
    {
        private readonly int _eventId;
        
        public EqualsParticipantEventIdSpecification(int eventId)
        {
            _eventId = eventId;
        }
        
        public override Expression<Func<Participant, bool>> ToExpression()
        {
            return participant => participant.EventId == _eventId;
        }
    }
    
}
