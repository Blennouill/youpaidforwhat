using ShareFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Core.Services.Interface
{
    public interface IAccountService
    {
        Account Generate(int participantId, int expenseId, bool isParticipantPayer, );
    }
}
