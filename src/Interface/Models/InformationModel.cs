using ShareFlow.Domain.Shared.Models;
using System;

namespace ShareFlow.Interface.Models
{
    /// <summary>
    /// Is used to describe a notification
    /// </summary>
    public class InformationModel
    {
        public Guid Id { get; internal set; }

        /// <summary>
        /// Information to display
        /// </summary>
        public Message Message { get; internal set; }
    }
}