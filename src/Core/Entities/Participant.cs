using ShareFlow.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace ShareFlow.Domain.Entities
{
    public class Participant : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Email { get; set; }
        public float ShareNumber { get; set; } = 1;

        public int EventId { get; set; }
    }
}