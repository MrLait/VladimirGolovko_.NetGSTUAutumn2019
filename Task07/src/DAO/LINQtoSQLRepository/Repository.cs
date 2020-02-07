using DAO.Interfaces;
using DBModelsLinqToSql.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DAO.DBAccessTechnology.LINQtoSQLRepository
{
    public class Repository<T> : ICRUD<T> where T : class, IEntity, new()
    {
        public string DbConString { get; private set; }

        public DataContext DbDataContext;

        public Repository(string dbConString)
        {
            DbConString = dbConString;

            DbDataContext = new DataContext(dbConString);
            DbDataContext.DeferredLoadingEnabled = false;
        }

        public Table<T> GetTable
        {
            get { return DbDataContext.GetTable<T>(); }
        }

        public IEnumerable<T> GetAll()
        {
            return GetTable;
        }

        public T Update(T entity)
        {
            var singleObjFromTable = GetTable.Where(x => x.ID.Equals(entity.ID)).Single();
            var changedParamObj =  GetUpdateParameter(entity, singleObjFromTable);
            SubmitChanges();
            return (T)changedParamObj;
        }

        public T GetByID(int byID)
        {
            var singleObjFromTable = GetTable.Where(x => x.ID.Equals(byID)).Single();
            return singleObjFromTable;
        }


        public void Add(T entity)
        {
            GetTable.InsertOnSubmit(entity);
            SubmitChanges();
       }

        public void Delete(int byID)
        {
            var singleObjFromTable = GetTable.Where(x => x.ID.Equals(byID)).SingleOrDefault();
            GetTable.DeleteOnSubmit(singleObjFromTable);
            SubmitChanges();
        }

        private void SubmitChanges()
        {
            DbDataContext.SubmitChanges();
        }

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
