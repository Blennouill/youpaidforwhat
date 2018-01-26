using AutoMapper;
using ShareFlow.Core.Services.Interface;
using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareFlow.Interface.Process
{
    public class ExpenseProcess : ResourceProcess<ExpenseModel, Expense>, IExpenseProcess
    {
        private readonly IParticipantService _participantService;
        private readonly IAccountService _accountService;
        private readonly IEventService _eventService;
        private readonly IEntityService<Category> _categoryService;

        public ExpenseProcess(IExpenseService expenseService,
                                IMapper mapper,
                                IParticipantService participantService,
                                IEntityService<Category> categoryService,
                                IAccountService accountService,
                                IEventService eventService) : base(expenseService, mapper)
        {
            _participantService = participantService;
            _categoryService = categoryService;
            _accountService = accountService;
            _eventService = eventService;
        }

        /// <summary>
        /// Create a new expense to a participant with updating his account
        /// </summary>
        public ExpenseModel CreateNewExpense(ExpenseModel expenseModel, int participantId)
        {
            var participant = _participantService.GetByID(participantId);
            if (participant == null)
                return null;

            var expense = _mapper.Map<ExpenseModel, Expense>(expenseModel);
            expense.ParticipantId = participant.Id;
            expense = _entityService.Create(expense);

            var account = _accountService.FindOneByParentId(participantId);
            var currentParticipantIsBeneficiary = expenseModel.Beneficiaries.FirstOrDefault(beneficiary => beneficiary.ParticipantId == participantId);
            if (currentParticipantIsBeneficiary != null)
                account.AdditionateAmount(expense.Amount * Convert.ToDecimal(currentParticipantIsBeneficiary.ShareNumber / Convert.ToDouble(expenseModel.Beneficiaries.Sum(beneficiary => beneficiary.ShareNumber))));
            else
                account.AdditionateAmount(expense.Amount);
            _accountService.Update(account);

            foreach (var beneficiary in expenseModel.Beneficiaries.Where(pBeneficiary => pBeneficiary.ParticipantId != participantId))
            {
                account = _accountService.FindOneByParentId(beneficiary.ParticipantId);
                account.SubstractAmount(expense.Amount * Convert.ToDecimal(beneficiary.ShareNumber / Convert.ToDouble(expenseModel.Beneficiaries.Sum(pBeneficiary => pBeneficiary.ShareNumber))));
                _accountService.Update(account);
            }

            return _mapper.Map<Expense, ExpenseModel>(expense);
        }

        /// <summary>
        /// Return expense's list of a specific participant
        /// </summary>
        /// <param name="urlEvent">participant's id</param>
        public IReadOnlyList<ExpenseModel> List(int idParticipant)
        {
            var participant = _participantService.GetByID(idParticipant);
            if (participant == null)
                return null;

            return _mapper.Map<IEnumerable<Expense>, List<ExpenseModel>>(_entityService.FindList(new EqualsExpenseParticipantIdSpecification(participant.Id)));
        }

        public IReadOnlyList<ExpenseModel> ListByEventUrl(string eventUrl)
        {
            var lEvent = _eventService.GetByAnyUrl(eventUrl);
            if (lEvent == null)
                return null;

            return _mapper.Map<IReadOnlyList<Expense>, IReadOnlyList<ExpenseModel>>(((IExpenseService)_entityService).ListFromEventId(lEvent.Id));
        }
    }
}