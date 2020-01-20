using System.Collections.Generic;

namespace DataBase.DAO.Interfaces
{
    public interface IDataOperation<T>
    {
        T GetByID(string ID);
        object Add(T entity);
        void Delete(string byID);
        T Update(T entity);
        IList<T> GetAll();
    }
}
