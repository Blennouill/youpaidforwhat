using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Application.Models
{
    public class AccountModel : BaseModel
    {
        public int IdParticipant { get; set; }

        [Required]
        public decimal Ammount { get; set; }
    }
}