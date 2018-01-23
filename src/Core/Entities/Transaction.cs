using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public int BalanceId { get; set; }
        public int CreditParticipantId { get; set; }
        public int DebitParticipantId { get; set; }

        public decimal Amount { get; set; }
    }
}