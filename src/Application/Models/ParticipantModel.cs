using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Application.Models
{
    /// <summary>
    /// Represent a participant to an event
    /// </summary>
    public class ParticipantModel : BaseModel
    {
        [Required]
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