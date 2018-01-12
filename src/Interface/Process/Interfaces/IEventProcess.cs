using ShareFlow.Interface.Models;

namespace ShareFlow.Interface.Process.Interfaces
{
    public interface IEventProcess
    {
        EventModel GetByUrl(string url);

        EventModel Create(EventModel model);
    }
}