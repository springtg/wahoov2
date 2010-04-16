using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace WahooData.DBO.Base
{
    public class DataAccessLayer
    {
        public DataAccessLayer()
        {

        }
        #region Helper
        /// <summary>
        /// Create a new instance of object with specified type.
        /// </summary>
        /// <param name="type">The type of object.</param>
        /// <returns>The new instance of object with default constructor.</returns>
        private static object NewInstance(Type type)
        {
            try
            {
                ConstructorInfo ci = type.GetConstructor(new Type[0]);
                if (ci == null)
                {
                    return null;
                }
                return ci.Invoke(null);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get the properties collection contain in obj
        /// </summary>
        /// <param name="obj">Object to get properties.</param>
        /// <returns>Return a list contain properties collection.</returns>
        private static List<PropertyInfo> GetProperties(Type type)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.GetCustomAttributes(true).Length > 0)
                {
                    properties.Add(property);
                }
            }

            return properties;
        }

        /// <summary>
        /// Get list result from database
        /// </summary>
        /// <param name="type">Type of object.</param>
        /// <param name="sqlDrd">The SqlDataReader contain records set.</param>
        /// <param name="properties">List of properties obj object.</param>
        /// <returns>Return the list object contain results set.</returns>
        private static List<object> GetListResult(Type type, DataTable datatable, List<PropertyInfo> properties)
        {
            try
            {
                List<object> objCollection = new List<object>();
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    object itemObject = NewInstance(type);
                    foreach (PropertyInfo property in properties)
                    {
                        ColumnAttribute attribute = ((ColumnAttribute)(property.GetCustomAttributes(true)[0]));
                        if (datatable.Rows[i][attribute.ColumnName] != null && datatable.Rows[i][attribute.ColumnName] != DBNull.Value)
                        {
                            property.SetValue(itemObject, datatable.Rows[i][attribute.ColumnName], null);
                        }
                    }
                    objCollection.Add(itemObject);
                }
                return objCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Insert(object obj)
        {
            return ServiceReader.Insert(obj);
        }

        /// <summary>
        /// Update an obj mapping to database.
        /// </summary>
        /// <param name="obj">The obj will be updated.</param>
        /// <returns></returns>
        public static bool Update(object obj)
        {
            return ServiceReader.Update(obj);
        }

        /// <summary>
        /// Get the first obj match objcondition
        /// </summary>
        /// <param name="objCondition">The obj contain conditions to filter</param>
        /// <returns></returns>
        public static object GetObject(object objCondition)
        {
            try
            {
                List<object> objCollection = GetListObject(objCondition);
                if (objCollection == null || objCollection.Count == 0)
                    return null;
                return objCollection[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all objects mapping to database
        /// </summary>
        /// <param name="objCondition">The obj contain conditions to filter</param>
        /// <returns>Return the list object match conditions.</returns>
        public static List<object> GetListObject(object objCondition)
        {
            if (objCondition == null)
                return null;
            try
            {
                Type type = objCondition.GetType();
                List<PropertyInfo> properties = GetProperties(type);
                DataTable datatable = new DataTable();
                datatable = ServiceReader.GetData(objCondition);
                List<object> objCollection = GetListResult(type, datatable, properties);
                return objCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCondition"></param>
        /// <returns></returns>
        public static List<object> GetListObject(object objCondition, int startRecordIndex, int? amountOfRecord)
        {
            if (objCondition == null)
                return null;
            try
            {
                Type type = objCondition.GetType();
                List<PropertyInfo> properties = GetProperties(type);
                DataTable dataTable = new DataTable();
                dataTable = ServiceReader.GetData(objCondition, startRecordIndex, amountOfRecord);
                List<object> objCollection = GetListResult(type, dataTable, properties);
                return objCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCondition"></param>
        /// <returns></returns>
        public static List<object> GetListObject(object objCondition,ref int allrows)
        {
            if (objCondition == null)
                return null;
            try
            {
                Type type = objCondition.GetType();
                List<PropertyInfo> properties = GetProperties(type);
                DataTable dataTable = new DataTable();
                dataTable = ServiceReader.GetData(objCondition,ref allrows);
                List<object> objCollection = GetListResult(typeof(DownloadReport), dataTable, GetProperties(typeof(DownloadReport)));
                return objCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find all obj match objcondition
        /// </summary>
        /// <param name="objCondition">The obj contain conditions to filter</param>
        /// <returns>Return the list object match conditions.</returns>
        public static List<object> FindListObjects(object objCondition)
        {
            List<PropertyInfo> properties = GetProperties(objCondition.GetType());
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType != typeof(System.String)) continue;

                object value = property.GetValue(objCondition, null);
                if (value == null) continue;

                property.SetValue(objCondition, string.Format("%{0}%", value), null);
            }
            return GetListObject(objCondition);
        }

        /// <summary>
        /// Delete an obj mapping to database
        /// </summary>
        /// <param name="obj">The obj will be deleted.</param>
        /// <returns></returns>
        public static bool Delete(object obj)
        {
            return ServiceReader.Delete(obj);
        }
        /// <summary>
        /// Update all channel to STARTED, STOPED...
        /// </summary>
        /// <param name="statusExecute"></param>
        /// <returns></returns>
        public static bool UpdateAllChannelStatusExecute(string statusExecute)
        {
            return ServiceReader.UpdateAllChannelStatusExecute(statusExecute);
        }
        /// <summary>
        /// Update all channel to isDeploy or not
        /// </summary>
        /// <param name="isDeployed"></param>
        /// <returns></returns>
        public static bool UpdateAllChannelDeployed(Boolean isDeployed)
        {
            return ServiceReader.UpdateAllChannelDeployed(isDeployed);
        }

        /// <summary>
        /// Delete HistoryChannel of Channel
        /// </summary>
        /// <param name="isDeployed"></param>
        /// <returns></returns>
        public static bool DeleteHistoryOfChannel(int idChannel)
        {
            return ServiceReader.DeleteHistoryOfChannel(idChannel);
        }

        #endregion
    }
}
