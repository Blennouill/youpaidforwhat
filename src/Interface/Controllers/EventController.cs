using Microsoft.AspNetCore.Mvc;
using ShareFlow.Application.Models;
using ShareFlow.Application.Process.Interface;

namespace ShareFlow.Interface.Controllers
{
    [Route("api/[controller]")]
    public class EventController : BaseResourceController<EventModel, IEventProcess>
    {
        public EventController(IEventProcess eventProcess) : base(eventProcess)
        {
        }
    }
}