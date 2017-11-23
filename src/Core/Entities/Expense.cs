using ShareFlow.Domain.Entities.Interfaces;
using System;

namespace ShareFlow.Domain.Entities
{
    public class Expense : IEntity, ITimestampable
    {
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public int IdParticipant { get; set; }
        public int IdCategory { get; set; }

        public string Reason { get; set; }
        public decimal Ammount { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime OperationDate { get; set; }
    }
}