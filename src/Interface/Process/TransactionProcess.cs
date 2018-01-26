using AutoMapper;
using ShareFlow.Core.Services.Interface;
using ShareFlow.Domain.Entities;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareFlow.Interface.Process
{
    public class TransactionProcess : ITransactionProcess
    {
        private readonly ITransactionService _entityService;
        private readonly IEventService _eventService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public TransactionProcess(ITransactionService entityService,
                                IEventService eventService,
                                IAccountService accountService,
                                IMapper mapper)
        {
            _entityService = entityService;
            _eventService = eventService;
            _accountService = accountService;
            _mapper = mapper;
        }

        public IReadOnlyList<TransactionModel> List(string eventUrl)
        {
            var lEvent = _eventService.GetByAnyUrl(eventUrl);
            if (lEvent == null)
                return null;

            this.GenerateTransactionsByEvent(lEvent.Id);

            // check if expenses SUM is equal to SUM of transaction

            return _mapper.Map<IReadOnlyList<Transaction>, IReadOnlyList<TransactionModel>>(_entityService.FindByParentId(lEvent.Id));
        }

        public void GenerateTransactionsByEvent(int eventId)
        {
            var creditorAccounts = _accountService.ListFromEventId(eventId).Where(account => account.IsCreditor()).OrderByDescending(account => account.Amount).ToList();
            var debitorAccounts = _accountService.ListFromEventId(eventId).Where(account => account.IsDebtor()).OrderBy(account => account.Amount).ToList();

            foreach (var creditorAccount in creditorAccounts)
            {
                debitorAccounts.OrderBy(account => account.Amount).ToList();

                foreach (var debitorAccount in debitorAccounts.Where(account => account.Amount < Decimal.Zero))
                {
                    var transaction = new Transaction(eventId, creditorAccount.ParticipantId, debitorAccount.ParticipantId);

                    if (Math.Abs(debitorAccount.Amount) >= creditorAccount.Amount)
                    {
                        transaction.Amount = Math.Abs(creditorAccount.Amount);
                        debitorAccount.AdditionateAmount(creditorAccount.Amount);
                    }
                    else
                    {
                        transaction.Amount = Math.Abs(debitorAccount.Amount);
                        creditorAccount.AdditionateAmount(debitorAccount.Amount);
                    }

                    if (transaction.Amount != 0)
                        _entityService.Create(transaction);
                }
            }
        }
    }
}