using AutoMapper;
using ShareFlow.Core.Services.Interface;
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
    public class AccountProcess : IAccountProcess
    {
        private readonly IAccountService _entityService;
        private readonly IParticipantService _participantService;
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public AccountProcess(IAccountService entityService, 
                                IParticipantService participantService,
                                IExpenseService expenseService,
                                IMapper mapper)
        {
            _entityService = entityService;
            _participantService = participantService;
            _expenseService = expenseService;
            _mapper = mapper;
        }

        public void GenerateAccount(int participantId)
        {
            throw new NotImplementedException();
        }
    }
}
