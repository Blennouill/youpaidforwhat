using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Domain.Shared.Interfaces
{
    /// <summary>
    /// Is used to define a type of message which is transmitted through the logic
    /// </summary>
    public interface IMessage
    {
        Guid Id { get; set; }
        string Value { get; set; }
    }
}
