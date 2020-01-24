using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using DAO.Helpers;
using DAO.Interfaces;
using DatabaseModels.Interfaces;

namespace DAO.DBAccessTechnology.SqlClientUsingReflectionRepository
{
    public abstract class AbstractRepository<T> : ICRUD<T> where T : IEntity, new()
    {
        public string DbConString { get; private set; }

        public AbstractRepository(string dbConString)
        {
            DbConString = dbConString;
        }

        public object Add(T entity)
        {
            if (entity == null)
                throw new ArgumentException(typeof(T).Name + "object Should not be Null when Saving to database");

            var storedProcedure = "Add" + entity.GetType().Name;

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection); //using

                try
                {
                    sqlCommand.Parameters.AddRange(GetAddParameter(entity).ToArray());
                    sqlConnection.Open();
                    return sqlCommand.ExecuteScalar();
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException("Some Error occured at database, if error in stored procedure. See inner exception for more detail exception." + storedProcedure, sqlEx);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IList<T> GetAll()
        {
            string tableName = new T().GetType().Name;
            string storedProcedure = "GetAll" + tableName;
            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection);
                SqlDataAdapter adpt = new SqlDataAdapter(sqlCommand); //using
                try
                {
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    var objT = ds.Tables[0].ToList<T>();
                    return objT;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException("Some Error occured at database, if error in stored procedure. See inner exception for more detail exception." + storedProcedure, sqlEx);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public T GetByID(int byID)
        {
            if (byID == 0 )
                throw new NullReferenceException("byID should not be 0");

            string tableName = new T().GetType().Name;
            string storedProcedure = "Get" + tableName + "ByID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection, new SqlParameter[] { new SqlParameter(tableName + "ID", byID)});
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                try
                {
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    var objT = ds.Tables[0].ToList<T>().SingleOrDefault();
                    return objT;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException("Some Error occured at database, if error in stored procedure. See inner exception for more detail exception." + storedProcedure, sqlEx);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public T Update(T entity)
        {
            //entity not null

            string tableName = new T().GetType().Name;
            string storedProcedure = "Update" + tableName;
            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {

                SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddRange(GetUpdateParameter(entity).ToArray());

                SqlDataAdapter adpt = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();

                try
                {
                    adpt.Fill(ds);
                    var objT = ds.Tables[0].ToList<T>();
                    return objT.SingleOrDefault();
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException("Class Name and Table name must be same for this method. See inner exception", sqlEx);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(int byID)
        {
            if (byID == 0)
                throw new NullReferenceException("byID should not be 0");

            string tableName = new T().GetType().Name;
            string storedProcedure = "Delete" + tableName + "ByID";

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection, new SqlParameter[] { new SqlParameter(tableName + "ID", byID) });

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException("Some Error occured at database, if error in stored procedure. See inner exception for more detail exception." + storedProcedure, sqlEx);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private List<SqlParameter> GetAddParameter(object obj)
        {
            PropertyInfo[] fields = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sqlParams = new List<SqlParameter>();
            foreach (var f in fields)
            {
                if (f.GetCustomAttributes(false).Length != 0)
                {
                    if (f.GetCustomAttributesData()[0].AttributeType.Name != "KeyAttribute") //f.GetCustomAttributes(false).Length == 0 && 
                    {
                        sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
                    }
                }
                else
                {
                    sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
                }
            }
            return sqlParams;
        }

        private List<SqlParameter> GetUpdateParameter(object obj)
        {
            PropertyInfo[] fields = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sqlParams = new List<SqlParameter>();
            foreach (var f in fields)
            {
                sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
            }
            return sqlParams;
        }

        private SqlCommand SqlCommandInstance(string storedProcedure, SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(storedProcedure, sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand;
        }

        private SqlCommand SqlCommandInstance(string storedProcedure, SqlConnection sqlConnection, SqlParameter[] sqlParamArr)
        {
            SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParamArr);
            return sqlCommand;
        }
    }
}
