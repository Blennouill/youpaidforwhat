using AutoMapper;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Infrastructure.Data.Extensions;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShareFlow.Interface.Process
{
    public class ExpenseProcess : ResourceProcess<ExpenseModel, Expense>, IExpenseProcess
    {
        private readonly IEntityService<Participant> _participantService;
        private readonly IEntityService<Category> _categoryService;

        public ExpenseProcess(IEntityService<Expense> expenseService,
                                IMapper mapper,
                                IEntityService<Participant> participantService,
                                IEntityService<Category> categoryService) : base(expenseService, mapper)
        {
            _participantService = participantService;
            _categoryService = categoryService;
        }

        public ExpenseModel Create(ExpenseModel expenseModel, int idParticipant)
        {
            var participant = _participantService.AsQuery().FilterBy(pParticipant => pParticipant.Id == idParticipant).FirstOrDefault();
            if (participant == null)
                return null;

            var expense = _mapper.Map<ExpenseModel, Expense>(expenseModel);
            expense.ParticipantId = participant.Id;

            expense = _entityService.Create(expense);

            return _mapper.Map<Expense, ExpenseModel>(expense); 
        }

        /// <summary>
        /// Return expense's list of a specific participant
        /// </summary>
        /// <param name="urlEvent">participant's id</param>
        public IReadOnlyList<ExpenseModel> List(int idParticipant)
        {
            var participant = _participantService.AsQuery().FilterBy(pParticipant => pParticipant.Id == idParticipant).FirstOrDefault();

            if (participant == null)
                return null;

            return _mapper.Map<IEnumerable<Expense>, List<ExpenseModel>>(_entityService.AsQuery().LoadChild(pExpense => pExpense.Beneficiaries).Where(pExpense => pExpense.ParticipantId == participant.Id).ToList());
        }
    }
}