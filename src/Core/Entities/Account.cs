using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public int IdParticipant { get; set; }

        public decimal Amount { get; set; }

        public virtual Participant Participant { get; set; }
    }
}