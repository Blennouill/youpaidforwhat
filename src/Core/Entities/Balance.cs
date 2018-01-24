using ShareFlow.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace ShareFlow.Domain.Entities
{
    public class Balance : IEntity
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}