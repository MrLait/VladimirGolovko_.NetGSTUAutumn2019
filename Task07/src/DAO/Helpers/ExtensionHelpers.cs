using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;

namespace DAO.Helpers
{
    /// <summary>
    /// Extension helpers for convert to list
    /// </summary>
    public static class ExtensionHelpers
    {
        /// <summary>
        /// Method to convert table to list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="table">input table</param>
        /// <returns>Returns list of table</returns>
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
