﻿using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Core.Services.Interface
{
    public interface IAccountService : IEntityService<Account>
    {
        /// <summary>
        /// Retourn the list of account which is owned by an event
        /// </summary>
        IReadOnlyList<Account> ListFromEventId(int eventId);
    }
}
