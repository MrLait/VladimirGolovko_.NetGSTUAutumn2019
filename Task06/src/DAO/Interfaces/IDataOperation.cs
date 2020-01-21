using System.Collections.Generic;

namespace DAO.Interfaces
{
    public interface IDataOperation<T>
    {
        T GetByID(int byID);
        object Add(T entity);
        void Delete(int byID);
        T Update(T entity);
        IList<T> GetAll();
    }
}
