using ShareFlow.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Application.Models
{
    /// <summary>
    /// Represent an information to return to the user
    /// </summary>
    public class Message : IMessage
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public Message(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }
    }
}
