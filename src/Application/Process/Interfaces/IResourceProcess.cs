using ShareFlow.Application.Shared.Interfaces;
using System.Collections.Generic;

namespace ShareFlow.Application.Process.Interfaces
{
    public interface IResourceProcess<TModel> where TModel : class, IModel
    {
        IEnumerable<TModel> GetAll();

        TModel GetByID(int id);

        TModel Create(TModel obj);

        TModel Update(TModel obj);

        void Delete(int id);

        void Save();
    }
}