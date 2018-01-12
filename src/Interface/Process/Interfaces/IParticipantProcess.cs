using ShareFlow.Interface.Models;

namespace ShareFlow.Interface.Process.Interfaces
{
    public interface IParticipantProcess : IResourceProcess<ParticipantModel>
    {
        ParticipantModel Create(ParticipantModel pParticipantModel, string urlEvent);
    }
}