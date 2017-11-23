using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Core.Shared.Models
{
    public class EmailMessage
    {
        public List<EmailAddress> To { get; set; }
        public List<EmailAddress> From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailMessage()
        {
            To = new List<EmailAddress>();
        }
    }
}
