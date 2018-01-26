namespace ShareFlow.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }

        int ParentId { get; }
    }
}