using Microsoft.AspNetCore.Mvc;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Domain.Shared.Models;
using System.Linq;

namespace ShareFlow.Interface.Controllers
{
    /// <summary>
    /// Base controller which handle model state error
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public BaseController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Build and return a response depending if errors exists
        /// </summary>
        /// <param name="result">Object</param>
        /// <returns></returns>
        protected new IActionResult Response(object result = null)
        {
            if (_messageService.IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _messageService.GetMessages().Select(message => message.Value)
            });
        }

        /// <summary>
        /// Get error from model state control and send to the current messaging service
        /// </summary>
        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMessage);
            }
        }

        /// <summary>
        /// Send the parameter to the message service
        /// </summary>
        /// <param name="message">value of the message</param>
        protected void NotifyError(string message)
        {
            _messageService.AddMessage(new Message(message));
        }
    }
}