using ShareFlow.Interface.Shared.Interfaces;
using System.Collections.Generic;

namespace ShareFlow.Interface.Process.Interfaces
{
    public interface IResourceProcess<TModel> where TModel : class, IModel
    {
        IEnumerable<TModel> GetAll();

        TModel GetByID(int id);

        void Save();
    }
}