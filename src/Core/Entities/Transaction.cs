using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CreditParticipantId { get; set; }
        public int DebitParticipantId { get; set; }

        public decimal Amount { get; set; }

        public int ParentId { get => EventId; }

        public Transaction() { }

        public Transaction(int eventId, int creditParticipantId, int debitParticipantId)
        {
            this.EventId = eventId;
            this.CreditParticipantId = creditParticipantId;
            this.DebitParticipantId = debitParticipantId; 
        }
    }
}