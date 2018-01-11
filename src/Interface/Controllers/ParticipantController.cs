using Microsoft.AspNetCore.Mvc;
using ShareFlow.Application.Models;
using ShareFlow.Application.Process.Interfaces;
using ShareFlow.Domain.Interfaces;

namespace ShareFlow.Interface.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantController : BaseResourceController<ParticipantModel, IParticipantProcess>
    {
        public ParticipantController(IParticipantProcess participantProcess, IMessageService messageService) : base(participantProcess, messageService)
        {
        }
    }
}