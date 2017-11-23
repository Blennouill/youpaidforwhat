using Microsoft.AspNetCore.Mvc;
using ShareFlow.Application.Models;
using ShareFlow.Application.Process.Interfaces;

namespace ShareFlow.Interface.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantController : BaseResourceController<ParticipantModel, IParticipantProcess>
    {
        public ParticipantController(IParticipantProcess participantProcess) : base(participantProcess)
        {
        }
    }
}