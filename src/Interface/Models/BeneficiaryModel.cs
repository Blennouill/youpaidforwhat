using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Interface.Models
{
    public class BeneficiaryModel : BaseModel
    {
        [Required]
        public int IdExpense { get; set; }

        [Required]
        public int IdParticipant { get; set; }

        public float ShareNumber { get; set; } = 0;
    }
}