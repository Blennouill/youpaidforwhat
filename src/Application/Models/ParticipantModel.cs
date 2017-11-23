using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Application.Models
{
    public class ParticipantModel : BaseModel
    {
        public int IdEvenement { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public byte ShareNumber { get; set; }
    }
}