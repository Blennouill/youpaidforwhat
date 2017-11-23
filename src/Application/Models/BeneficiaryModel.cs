using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Application.Models
{
    public class BeneficiaryModel : BaseModel
    {
        [Required]
        public int IdExpense { get; set; }

        [Required]
        public int IdParticipant { get; set; }

        public byte ShareNumber { get; set; }
    }
}