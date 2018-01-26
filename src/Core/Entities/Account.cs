using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }

        public decimal Amount { get; private set; }

        public virtual Participant Participant { get; set; }
        
        public int ParentId { get => ParticipantId; }

        public Account()
        {
        }

        public Account(int participantId)
        {
            this.ParticipantId = participantId;
            this.Amount = decimal.Zero;
        }

        public Account AdditionateAmount(decimal value)
        {
            this.Amount += value;
            
            return this;
        }
        public Account SubstractAmount(decimal value)
        {
            this.Amount -= value;

            return this;
        }

        public bool IsDebtor()
        {
            return Amount < decimal.Zero;
        }

        public bool IsCreditor()
        {
            return Amount > decimal.Zero;
        }
    }
}