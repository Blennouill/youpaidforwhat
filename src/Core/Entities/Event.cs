using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Event : IEntity
    {
        public int Id { get; set; }

        public string Url { get; set; }
        public string ReadingUrl { get; set; }
        public string Title { get; set; }
        public string OwnerMail { get; set; }
    }
}