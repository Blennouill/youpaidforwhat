using ShareFlow.Interface.Models;
using System.Collections.Generic;

namespace ShareFlow.Interface.Process.Interfaces
{
    public interface IParticipantProcess : IResourceProcess<ParticipantModel>
    {
        ParticipantModel Create(ParticipantModel pParticipantModel, string urlEvent);
        /// <summary>
        /// Return participant's list of the specific event
        /// </summary>
        /// <param name="urlEvent">url of the event</param>
        IReadOnlyList<ParticipantModel> List(string urlEvent);
    }
}