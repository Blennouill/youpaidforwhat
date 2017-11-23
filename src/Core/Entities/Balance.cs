using ShareFlow.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace ShareFlow.Domain.Entities
{
    public class Balance : IEntity
    {
        public int Id { get; set; }
        public int IdEvent { get; set; }

        public List<Transaction> Transactions { get; set; }
        public List<Account> Accounts { get; set; }
    }
}