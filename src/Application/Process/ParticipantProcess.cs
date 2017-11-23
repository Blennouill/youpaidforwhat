using AutoMapper;
using ShareFlow.Application.Models;
using ShareFlow.Application.Process;
using ShareFlow.Application.Process.Interfaces;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;

namespace ShareFlow.Domain.Services
{
    public class ParticipantProcess : ResourceProcess<ParticipantModel, Participant>, IParticipantProcess
    {
        public ParticipantProcess(IEntityService<Participant> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}