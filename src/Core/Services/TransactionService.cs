using ShareFlow.Core.Services.Interface;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Shared.Interfaces;

namespace ShareFlow.Domain.Services
{
    public class TransactionService : EntityService<Transaction>, ITransactionService
    {
        public TransactionService(IRepository<Transaction> repository) : base(repository)
        {
        }
    }
}