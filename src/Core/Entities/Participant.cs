using ShareFlow.Domain.Entities.Interfaces;

namespace ShareFlow.Domain.Entities
{
    public class Participant : IEntity
    {
        public int Id { get; set; }
        public int IdEvenement { get; set; }

        public string FirstName { get; set; }
        public string Email { get; set; }
        public byte ShareNumber { get; set; }
    }
}