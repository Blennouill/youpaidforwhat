namespace ShareFlow.Interface.Models
{
    public class TransactionModel : BaseModel
    {
        public int IdBalance { get; set; }
        public int CreditParticipantId { get; set; }
        public int DebitParticipantId { get; set; }

        public decimal Amount { get; set; }
    }
}