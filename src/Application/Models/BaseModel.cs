using ShareFlow.Application.Shared.Interfaces;

namespace ShareFlow.Application.Models
{
    public abstract class BaseModel : IModel
    {
        public int Id { get; internal set; }
    }
}