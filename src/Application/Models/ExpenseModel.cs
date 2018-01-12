using System;

namespace ShareFlow.Application.Models
{
    public class ExpenseModel : BaseModel
    {
        public int IdEvent { get; set; }
        public int IdParticipant { get; set; }
        public int IdCategory { get; set; }

        public string Purpose { get; set; }
        public decimal Ammount { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime OperationDate { get; set; }
    }
}