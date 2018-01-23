using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Beneficiary : IEntity
    {
        public int Id { get; set; }

        public double ShareNumber { get; set; } = 1;

        public int ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }

        public int ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
    }
}