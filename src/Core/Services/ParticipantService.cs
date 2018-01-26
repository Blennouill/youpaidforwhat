using ShareFlow.Core.Services.Interface;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Shared.Interfaces;

namespace ShareFlow.Domain.Services
{
    public class ParticipantService : EntityService<Participant>, IParticipantService
    {
        public ParticipantService(IRepository<Participant> repository) : base(repository)
        {
        }
    }
}