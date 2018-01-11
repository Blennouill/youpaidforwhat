using Microsoft.AspNetCore.Mvc;
using ShareFlow.Application.Models;
using ShareFlow.Application.Process.Interfaces;
using ShareFlow.Domain.Interfaces;

namespace ShareFlow.Interface.Controllers
{
    [Route("api/[controller]")]
    public class EventController : BaseResourceController<EventModel, IEventProcess>
    {
        public EventController(IEventProcess eventProcess, IMessageService messageService) : base(eventProcess, messageService)
        {
        }
    }
}