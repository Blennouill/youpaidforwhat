using System.Collections.Generic;

namespace ShareFlow.Application.Models
{
    public class BalanceModel : BaseModel
    {
        public int IdEvent { get; set; }

        public List<TransactionModel> Transactions { get; set; }
        public List<AccountModel> Accounts { get; set; }
    }
}