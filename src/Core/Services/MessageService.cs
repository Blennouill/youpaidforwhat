using ShareFlow.Domain.Interfaces;
using ShareFlow.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareFlow.Core.Services
{
    /// <summary>
    /// Is used to manage message trough the application
    /// </summary>
    public class MessageService : IMessageService
    {
        private List<IMessage> _messages;

        /// <summary>
        /// Is used to return all the message from the current operation
        /// </summary>
        /// <returns></returns>
        public IList<IMessage> GetMessages()
        {
            return _messages;
        }

        /// <summary>
        /// Check if the current operation has no errors
        /// </summary>
        /// <returns></returns>
        public bool IsValidOperation()
        {
            return !_messages.Any();
        }

        /// <summary>
        /// Is used to add a new message in the current operation
        /// </summary>
        /// <param name="message">the message to add</param>
        public void AddMessage(IMessage message)
        {
            _messages.Add(message);
        }
        
    }
}
