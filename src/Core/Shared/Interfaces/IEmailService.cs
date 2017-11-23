using ShareFlow.Core.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Domain.Shared.Interfaces
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }
}
