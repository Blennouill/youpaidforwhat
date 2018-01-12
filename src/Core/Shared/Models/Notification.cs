using ShareFlow.Domain.Shared.Interfaces;
using System;

namespace ShareFlow.Domain.Shared.Models
{
    /// <summary>
    /// Represent an information to return to the user
    /// </summary>
    public class Notification : INotification
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public Notification(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }
    }
}