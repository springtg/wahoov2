using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WahooData.DBO.Base
{
    public abstract class BaseController
    {
        public BaseController()
        {

        }

        /// <summary>
        /// This method call insert method from DataAccessLayer using the provided parameter.
        /// </summary>
        /// <returns>Return ID if add successful; otherwise return -1.</returns>    
        protected int Add(object item)
        {
            try
            {
                return DataAccessLayer.Insert(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get item match condition contain in obj
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>Return the object</returns>
        protected object GetItem(object condition)
        {
            return DataAccessLayer.GetObject(condition);
        }

        /// <summary>
        /// Get all items match condition contain in obj.
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The list obj match conditions.</returns>
        protected List<object> GetItemsCollection(object condition)
        {
            try
            {
                List<object> items = DataAccessLayer.GetListObject(condition);

                if (items == null || items.Count == 0)
                    return null;
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected List<object> GetItemsCollection(object condition, int index, int? numOfRow)
        {
            try
            {
                List<object> items = DataAccessLayer.GetListObject(condition, index, numOfRow);

                if (items == null || items.Count == 0)
                    return null;
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected List<object> GetItemsCollection(object condition,ref int allrows)
        {
            try
            {
                List<object> items = DataAccessLayer.GetListObject(condition,ref allrows);

                if (items == null || items.Count == 0)
                    return null;
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find all items match condition contain in obj.
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The list obj match conditions.</returns>
        protected List<object> FindItemsCollection(object condition)
        {
            try
            {
                List<object> items = DataAccessLayer.FindListObjects(condition);
                if (items == null || items.Count == 0)
                    return null;
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectCommand"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable GetCustomData(string selectCommand, CommandType type, SqlParameter[] parameters)
        {
            // return DataAccessLayer.GetData(selectCommand, type, parameters);
            return null;
        }
    }
}
