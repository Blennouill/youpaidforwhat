﻿using Microsoft.AspNetCore.Mvc;
using ShareFlow.Interface.Process.Interfaces;

namespace ShareFlow.Interface.Controllers.Event
{
    [Route("api/events/{urlEvent}/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionProcess _transactionProcess;

        public TransactionsController(ITransactionProcess eventProcess)
        {
            _transactionProcess = eventProcess;
        }

        [HttpGet]
        public IActionResult List(string urlEvent)
        {
            var transactions = _transactionProcess.List(urlEvent);
            if (transactions == null)
                return new NotFoundResult();

            return new OkObjectResult(transactions);
        }
    }
}