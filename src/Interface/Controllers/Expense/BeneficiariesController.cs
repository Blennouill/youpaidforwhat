using Microsoft.AspNetCore.Mvc;
using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Interface.Shared;

namespace ShareFlow.Interface.Controllers.Event
{
    [Route("api/expense/{expenseId}/[controller]")]
    public class BeneficiariesController : ControllerBase
    {
        private readonly IEntityService<Beneficiary> _beneficiaryService;

        public BeneficiariesController(IEntityService<Beneficiary> beneficiaryService)
        {
            _beneficiaryService = beneficiaryService;
        }

        [HttpGet]
        public IActionResult List(int expenseId)
        {
            var expenses = _beneficiaryService.FindByParentId(expenseId);
            if (expenses == null)
                return new NotFoundResult();

            return new OkObjectResult(expenses);
        }

        [HttpGet("{id}", Name = BeneficiariesRoutingName.BENEFICIARIES_GET_UNIQUE)]
        public IActionResult Get(int expenseId, int id)
        {
            var expense = _beneficiaryService.GetByID(id);
            if (expense == null)
                return new NotFoundResult();

            return new OkObjectResult(_beneficiaryService.GetByID(id));
        }
    }
}