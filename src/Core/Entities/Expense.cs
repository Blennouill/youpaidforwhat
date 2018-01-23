using ShareFlow.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace ShareFlow.Domain.Entities
{
    public class Expense : IEntity, ITimestampable
    {
        public int Id { get; set; }

        public string Purpose { get; set; }
        public decimal Amount { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime OperationDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public List<Beneficiary> Beneficiaries { get; set; }
    }
}