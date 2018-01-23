using Microsoft.AspNetCore.Mvc;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Interface.Filters;
using ShareFlow.Interface.Models;
using ShareFlow.Interface.Process.Interfaces;
using ShareFlow.Interface.Shared;

namespace ShareFlow.Interface.Controllers.Event
{
    [Route("api/participants/{idParticipant}/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseProcess _expenseProcess;

        public ExpensesController(IExpenseProcess expenseProcess)
        {
            _expenseProcess = expenseProcess;
        }

        [HttpGet]
        public IActionResult List(int idParticipant)
        {
            var expenses = _expenseProcess.List(idParticipant);
            if (expenses == null)
                return new NotFoundResult();

            return new OkObjectResult(expenses);
        }

        [HttpGet("{id}", Name = ExpensesRoutingName.EXPENSES_GET_UNIQUE)]
        public IActionResult Get(int id)
        {
            var expense = _expenseProcess.GetByID(id);
            if (expense == null)
                return new NotFoundResult();

            return new OkObjectResult(_expenseProcess.GetByID(id));
        }

        [HttpPost]
        [ModelStateValidationFilter]
        public IActionResult Post([FromBody]ExpenseModel expenseModel, int idParticipant)
        {
            var expense = _expenseProcess.Create(expenseModel, idParticipant);
            if (expense == null)
                return new BadRequestResult();

            return new CreatedAtRouteResult(ExpensesRoutingName.EXPENSES_GET_UNIQUE, new { expense.Id }, expense);
        }
    }
}