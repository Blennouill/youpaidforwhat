using ShareFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShareFlow.Core.Specifications
{
    /// <summary>
    /// Is used to check the equality between the participant id of an expense
    /// </summary>
    public class EqualsExpenseParticipantIdSpecification : Specification<Expense>
    {
        private readonly int _participantId;
        
        public EqualsExpenseParticipantIdSpecification(int participantId)
        {
            _participantId = participantId;
        }
        
        public override Expression<Func<Expense, bool>> ToExpression()
        {
            return expense => expense.ParticipantId == _participantId;
        }
    }
}
