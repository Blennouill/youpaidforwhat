﻿using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Core.Services.Interface
{
    public interface IExpenseService : IEntityService<Expense>
    {
        /// <summary>
        /// Retourn the list of expenses which is owned by an event
        /// </summary>
        IReadOnlyList<Expense> ListFromEventId(int eventId);
    }
}
