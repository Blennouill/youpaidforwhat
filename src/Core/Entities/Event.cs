using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Event : IEntity
    {
        public int Id { get; set; }

        public string WrittingURL { get; set; }
        public string ReadingURL { get; set; }
        public string Title { get; set; }
        public string OwnerMail { get; set; }
    }
}