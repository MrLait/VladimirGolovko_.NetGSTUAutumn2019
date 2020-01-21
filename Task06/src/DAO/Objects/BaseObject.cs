using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using DAO.Helpers;
using DAO.Interfaces;


namespace DAO.Objects
{
    public abstract class BaseObject<T> : IDataOperation<T> where T : new()
    {
        public string DbConString { get; private set; }

        public BaseObject(string dbConString)
        {
            DbConString = dbConString;
        }

        public object Add(T entity)
        {
            if (entity == null)
                throw new ArgumentException(typeof(T).Name + "object Should not be Null when Saving to database");

            var storedProcedure = "Add" + entity.GetType().Name;

            using (SqlConnection connection = new SqlConnection(DbConString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    command.Parameters.AddRange(GetAddParameter(entity).ToArray());
                    connection.Open();
                    return command.ExecuteScalar();
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException("Some Error occured at database, if error in stored procedure, delete it from DB. See inner exception for more detail exception." + storedProcedure, sqlEx);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(int byID)
        {

            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByID(int byID)
        {
            if (byID == 0 )
                throw new NullReferenceException("byID Should not be 0");

            string tableName = new T().GetType().Name;
            var storedProcedure = "Get" + tableName + "ByID";
            using (SqlConnection connection = new SqlConnection(DbConString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SqlCommandInstance(storedProcedure, connection, new SqlParameter[] { new SqlParameter(tableName + "ID", byID)}));

                try
                {
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    var objT = ds.Tables[0].ToList<T>().SingleOrDefault();
                    return objT;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException("Exception: See inner exception.", sqlEx);
                }
                catch (Exception ex)
                {

                }
                return default(T);
            }
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        private List<SqlParameter> GetAddParameter(object obj)
        {
            PropertyInfo[] fields = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sqlParams = new List<SqlParameter>();
            foreach (var f in fields)
            {
                if (f.GetCustomAttributes(false).Length == 0)
                {
                    sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
                }
            }
            return sqlParams;
        }

        private SqlCommand SqlCommandInstance(string storedProcedureName, SqlConnection con, SqlParameter[] sqlParamArr)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = storedProcedureName,
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(sqlParamArr);
            return cmd;
        }

        IList<T> IDataOperation<T>.GetAll()
        {
            throw new System.NotImplementedException();
        }


       

    }
}
