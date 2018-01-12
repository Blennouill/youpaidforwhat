namespace ShareFlow.Interface.Models
{
    public class TransactionModel : BaseModel
    {
        public int IdBalance { get; set; }
        public int IdCreditParticipant { get; set; }
        public int IdDebitParticipant { get; set; }

        public decimal Ammount { get; set; }
    }
}