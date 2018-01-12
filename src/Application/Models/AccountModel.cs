using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Application.Models
{
    public class AccountModel : BaseModel
    {
        public int IdParticipant { get; set; }
        
        public decimal Amount { get; internal set; }
    }
}