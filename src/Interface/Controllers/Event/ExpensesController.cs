using Microsoft.AspNetCore.Mvc;
using ShareFlow.Interface.Process.Interfaces;

namespace ShareFlow.Interface.Controllers.Events
{
    [Route("api/events/{eventUrl}/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseProcess _expenseProcess;

        public ExpensesController(IExpenseProcess expenseProcess)
        {
            _expenseProcess = expenseProcess;
        }

        [HttpGet]
        public IActionResult List(string eventUrl)
        {
            var expenses = _expenseProcess.ListByEventUrl(eventUrl);
            if (expenses == null)
                return new NotFoundResult();

            return new OkObjectResult(expenses);
        }
    }
}