using Microsoft.AspNetCore.Mvc;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Interface.Process.Interfaces;
using ShareFlow.Interface.Shared.Interfaces;

namespace ShareFlow.Interface.Controllers
{
    public abstract class BaseResourceController<TModel, TIRessourceProcess> : BaseController
                    where TModel : class, IModel
                    where TIRessourceProcess : class, IResourceProcess<TModel>
    {
        protected readonly IResourceProcess<TModel> _resourceProcess;

        public BaseResourceController(TIRessourceProcess resourceProcess, IMessageService messageService) : base(messageService)
        {
            _resourceProcess = resourceProcess;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_resourceProcess.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_resourceProcess.GetByID(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]TModel entity)
        {
            if (!ModelState.IsValid)
                return Response(entity);

            var lEntity = _resourceProcess.Create(entity);

            return new OkObjectResult(lEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TModel entity)
        {
            if (!ModelState.IsValid)
                return Response(entity);

            var lEntity = _resourceProcess.Update(entity);

            return new OkObjectResult(lEntity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _resourceProcess.Delete(id);

            return new OkResult();
        }
    }
}