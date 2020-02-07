using DAO.Interfaces;
using DBModelsLinqToSql.Interfaces;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Reflection;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    /// <summary>
    /// That class describes generic repository and implemented method of ICRUD interface.
    /// </summary>
    /// <typeparam name="T">Input models</typeparam>
    public class Repository<T> : ICRUD<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Data context.
        /// </summary>
        private readonly DataContext _dbDataContext;

        /// <summary>
        /// Constructor <see cref="Repository{T}"/>
        /// </summary>
        /// <param name="dbConString">Connection string to database.</param>
        public Repository(string dbConString)
        {
            _dbDataContext = new DataContext(dbConString)
            {
                DeferredLoadingEnabled = false
            };
        }

        /// <summary>
        /// Property to get table from database.
        /// </summary>
        public Table<T> GetTable
        {
            get { return _dbDataContext.GetTable<T>(); }
        }

        /// <summary>
        /// Implementation get all method. Get all data from database.
        /// </summary>
        /// <returns>Returns list of objects</returns>
        public IEnumerable<T> GetAll()
        {
            return GetTable;
        }

        /// <summary>
        /// Modify an existing object. 
        /// </summary>
        /// <param name="entity">Object with parameters to be changed.</param>
        /// <returns>Returns changed object.</returns>
        public T Update(T entity)
        {
            var singleObjFromTable = GetTable.Where(x => x.ID.Equals(entity.ID)).Single();
            var changedParamObj =  GetUpdateParameter(entity, singleObjFromTable);
            SubmitChanges();
            return (T)changedParamObj;
        }

        /// <summary>
        /// Get object by ID from table in database.
        /// </summary>
        /// <param name="byID">Object id.</param>
        /// <returns>Returns object by id.</returns>
        public T GetByID(int byID)
        {
            var singleObjFromTable = GetTable.Where(x => x.ID.Equals(byID)).Single();
            return singleObjFromTable;
        }

        /// <summary>
        /// Add object to database.
        /// </summary>
        /// <param name="entity">Object to add in database.</param>
        public void Add(T entity)
        {
            GetTable.InsertOnSubmit(entity);
            SubmitChanges();
        }

        /// <summary>
        /// Delete object from table by ID.
        /// </summary>
        /// <param name="byID">ID oject.</param>
        public void Delete(int byID)
        {
            var singleObjFromTable = GetTable.Where(x => x.ID.Equals(byID)).SingleOrDefault();
            GetTable.DeleteOnSubmit(singleObjFromTable);
            SubmitChanges();
        }

        /// <summary>
        /// Submit all chages in database.
        /// </summary>
        private void SubmitChanges()
        {
            _dbDataContext.SubmitChanges();
        }

        /// <summary>
        /// Updata fields from one object to other.
        /// </summary>
        /// <param name="from">Main object.</param>
        /// <param name="to">Target object.</param>
        /// <returns>Returns updated object.</returns>
        private static object GetUpdateParameter(object from, object to)
        {
            PropertyInfo[] fieldsTo = to.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] fieldsFrom = from.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var fTo in fieldsTo)
            {
                foreach (var fFrom in fieldsFrom)
                {
                    if (fTo.Name == fFrom.Name)
                    {
                        fTo.SetValue(to, fFrom.GetValue(from));
                        break;
                    }
                }
            }
            return to;
        }
    }
}
