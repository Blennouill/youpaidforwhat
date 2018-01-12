using ShareFlow.Core.Shared.Models;

namespace ShareFlow.Domain.Shared.Interfaces
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }
}