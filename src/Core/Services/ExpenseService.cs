using ShareFlow.Core.Services.Interface;
using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Entities.Interfaces;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShareFlow.Domain.Services
{
    public class ExpenseService : EntityService<Expense>, IExpenseService
    {
        public ExpenseService(IRepository<Expense> repository) : base(repository)
        {
        }
    }
}