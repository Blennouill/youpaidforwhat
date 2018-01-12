using ShareFlow.Interface.Shared.Interfaces;

namespace ShareFlow.Interface.Models
{
    public abstract class BaseModel : IModel
    {
        public int Id { get; internal set; }
    }
}