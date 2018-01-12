using System.ComponentModel.DataAnnotations;

namespace ShareFlow.Interface.Models
{
    /// <summary>
    /// Represent an event
    /// </summary>
    public class EventModel : BaseModel
    {
        public string Url { get; internal set; }

        public string ReadingUrl { get; internal set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [EmailAddress]
        public string OwnerMail { get; set; }
    }
}