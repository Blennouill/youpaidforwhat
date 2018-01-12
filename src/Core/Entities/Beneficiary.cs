using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Beneficiary : IEntity
    {
        public int Id { get; set; }
        public int IdExpense { get; set; }
        public int IdParticipant { get; set; }

        public float ShareNumber { get; set; }

        public virtual Participant Participant { get; set; }
    }
}