using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Core.Services.Interface
{
    public interface IEventService : IEntityService<Event>
    {
        Event GetByUrl(string url);

        Event GetByAnyUrl(string url);
    }
}
