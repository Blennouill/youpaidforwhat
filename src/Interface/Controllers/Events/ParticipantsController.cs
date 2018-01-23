using Microsoft.AspNetCore.Mvc;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Interface.Filters;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using ShareFlow.Interface.Shared;

namespace ShareFlow.Interface.Controllers.Event
{
    [Route("api/events/{urlEvent}/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantProcess _participantProcess;

        public ParticipantsController(IParticipantProcess participantProcess)
        {
            _participantProcess = participantProcess;
        }

        [HttpGet]
        public IActionResult List(string urlEvent)
        {
            var participants = _participantProcess.List(urlEvent);
            if (participants == null)
                return new NotFoundResult();

            return new OkObjectResult(participants);
        }

        [HttpGet("{id}", Name = ParticipantsRoutingName.PARTICIPANTS_GET_UNIQUE)]
        public IActionResult Get(int id)
        {
            var participant = _participantProcess.GetByID(id);
            if (participant == null)
                return new NotFoundResult();

            return new OkObjectResult(_participantProcess.GetByID(id));
        }

        [HttpPost]
        [ModelStateValidationFilter]
        public IActionResult Post([FromBody]ParticipantModel participantModel, string urlEvent)
        {
            var participant = _participantProcess.Create(participantModel, urlEvent);
            if (participant == null)
                return new BadRequestResult();

            return new CreatedAtRouteResult(ParticipantsRoutingName.PARTICIPANTS_GET_UNIQUE, new { participant.Id }, participant);
        }
    }
}