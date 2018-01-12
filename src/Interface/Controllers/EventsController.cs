using Microsoft.AspNetCore.Mvc;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using ShareFlow.Interface.Shared;

namespace ShareFlow.Interface.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventProcess _eventProcess;

        public EventsController(IEventProcess eventProcess)
        {
            _eventProcess = eventProcess;
        }

        [HttpGet("{url}", Name = EventsRoutingName.EVENTS_GET_UNIQUE)]
        public IActionResult Get(string url)
        {
            var lEvent = _eventProcess.GetByUrl(url);
            if (lEvent == null)
                return new NotFoundResult();

            return new OkObjectResult(_eventProcess.GetByUrl(url));
        }

        [HttpPost]
        public IActionResult Post([FromBody]EventModel eventModel)
        {
            var lEvent = _eventProcess.Create(eventModel);

            return new CreatedAtRouteResult(EventsRoutingName.EVENTS_GET_UNIQUE, new { lEvent.Url }, lEvent);
        }
    }
}