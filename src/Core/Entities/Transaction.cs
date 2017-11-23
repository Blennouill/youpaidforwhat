using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public int IdBalance { get; set; }
        public int IdCreditParticipant { get; set; }
        public int IdDebitParticipant { get; set; }

        public decimal Ammount { get; set; }
    }
}