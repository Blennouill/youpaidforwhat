using AutoMapper;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Infrastructure.Data.Extensions;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareFlow.Interface.Process
{
    public class BalanceProcess : IBalanceProcess
    {
        private readonly IEntityService<Balance> _entityService;
        private readonly IEntityService<Event> _eventService;
        private readonly IEntityService<Participant> _participantService;
        private readonly IEntityService<Account> _accountService;
        private readonly IEntityService<Expense> _expenseService;
        private readonly IMapper _mapper;

        public BalanceProcess(IEntityService<Balance> entityService, 
                                IEntityService<Event> eventService, 
                                IEntityService<Participant> participantService, 
                                IEntityService<Account> accountService, 
                                IEntityService<Expense> expenseService,
                                IMapper mapper)
        {
            _entityService = entityService;
            _eventService = eventService;
            _participantService = participantService;
            _accountService = accountService;
            _expenseService = expenseService;
            _mapper = mapper;
        }

        public BalanceModel Create(int eventId)
        {
            this.InitiateAcounts(eventId);
        }

        public void InitiateAcounts(int eventId)
        {
            var participants = _participantService.AsQuery().Where(participant => participant.EventId == eventId).ToList();
            var expenses = 

            foreach (var participant in participants)
            {
                foreach(var expense in _expenseService.AsQuery().LoadChild(expense => expense.Beneficiaries).Where(expense => expense.ParticipantId == participant.Id).ToList())
            }
        }
    }
}
