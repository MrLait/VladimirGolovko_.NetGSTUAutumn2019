using System.Collections.Generic;

namespace DAO.Interfaces
{
    /// <summary>
    /// Crud interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICRUD<T>
    {
        /// <summary>
        /// Get object by ID from table in database.
        /// </summary>
        /// <param name="byID">Object id.</param>
        /// <returns>Returns object.</returns>
        T GetByID(int byID);

        /// <summary>
        /// Add object to data base.
        /// </summary>
        /// <param name="entity">Object to add in database.</param>
        /// <returns></returns>
        void Add(T entity);

        /// <summary>
        /// Delete object from table by ID.
        /// </summary>
        /// <param name="byID"> ID ibject</param>
        void Delete(int byID);

        /// <summary>
        /// Modify an existing object. 
        /// </summary>
        /// <param name="entity"> Parameters to be changed.</param>
        /// <returns>Returns a new object.</returns>
        T Update(T entity);

        /// <summary>
        /// Method to get all objects from database table.
        /// </summary>
        /// <returns>Returns list of objects</returns>
        IEnumerable<T> GetAll(); // 
    }
}
