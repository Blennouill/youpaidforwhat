using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Application.Models
{
    /// <summary>
    /// Represent an event
    /// </summary>
    public class EventModel : BaseModel
    {
        public string WrittingURL { get; internal set; }

        public string ReadingURL { get; internal set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [EmailAddress]
        public string OwnerMail { get; set; }
    }
}