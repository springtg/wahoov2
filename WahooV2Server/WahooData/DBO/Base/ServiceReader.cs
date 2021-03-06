﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using WahooConfiguration;
using WahooCommon;

namespace WahooData.DBO.Base
{
    public class ServiceReader
    {
        private static string _conectionString=GeneralConn();
        public ServiceReader()
        {
        }
        /// <summary>
        /// Lay data
        /// </summary>
        /// <param name="objCondition"></param>
        /// <returns></returns>
        public static DataTable GetData(object objCondition)
        {
            string strTableName = ((TableAttribute)(objCondition.GetType().GetCustomAttributes(true)[0])).TableName.ToString();            
            try
            {
                int count = (objCondition.GetType()).GetProperties().Count();
                SqlParameter []param = new SqlParameter[count];
                int i = 0;
                foreach (PropertyInfo property in (objCondition.GetType()).GetProperties())
                {
                    if (property.GetCustomAttributes(true).Length > 0)
                    {
                        ColumnAttribute attribute = ((ColumnAttribute)(property.GetCustomAttributes(true)[0]));
                        if (attribute.ColumnType == SqlDbType.DateTime)
                        {
                            string currentLang = string.Empty;
                            //CommonFunction.IsLocalLang(out currentLang);
                            //System.IFormatProvider cul = new System.Globalization.CultureInfo(currentLang, true);
                            string datetimeData = null;
                            if (property.GetValue(objCondition, null) != null)
                            {
                                //datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString(), cul).ToString("MM/dd/yyyy");
                                datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString()).ToString("MM/dd/yyyy");
                            }
                            param[i] = new SqlParameter("@" + attribute.ColumnName, datetimeData);
                        }
                        else
                        {
                            if (property.GetValue(objCondition, null) != string.Empty)
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, property.GetValue(objCondition, null));
                            }
                            else
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, null);
                            }
                        }
                        i++;
                    }
                }
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(ServiceReader._conectionString, CommandType.StoredProcedure, strTableName + "_Select", param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception)
            {                
                throw;
            }
            return new DataTable();
        }

        /// <summary>
        /// Lay du lieu theo ten bang va so record can lay, lay tu so record nao
        /// </summary>
        /// <param name="strTableName">Ten table</param>
        /// <param name="index">Bat dau tu record nao </param>
        /// <param name="numofRow">So record can lay</param>
        /// <returns></returns>
        public static DataTable GetData(object objCondition, int startRecordIndex, int? amountOfRecord)
        {
            string strTableName = ((TableAttribute)(objCondition.GetType().GetCustomAttributes(true)[0])).TableName.ToString();
            try
            {
                int count = (objCondition.GetType()).GetProperties().Count();
                count += 2;
                SqlParameter[] param = new SqlParameter[count];
                int i = 0;
                foreach (PropertyInfo property in (objCondition.GetType()).GetProperties())
                {
                    if (property.GetCustomAttributes(true).Length > 0)
                    {
                        ColumnAttribute attribute = ((ColumnAttribute)(property.GetCustomAttributes(true)[0]));
                        if (attribute.ColumnType == SqlDbType.DateTime)
                        {
                            string currentLang = string.Empty;
                            //CommonFunction.IsLocalLang(out currentLang);
                            //System.IFormatProvider cul = new System.Globalization.CultureInfo(currentLang, true);
                            string datetimeData = null;
                            if (property.GetValue(objCondition, null) != null)
                            {
                                //datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString(), cul).ToString("MM/dd/yyyy");
                                datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString()).ToString("MM/dd/yyyy");
                            }
                            param[i] = new SqlParameter("@" + attribute.ColumnName, datetimeData);
                        }
                        else
                        {
                            if (property.GetValue(objCondition, null) != string.Empty)
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, property.GetValue(objCondition, null));
                            }
                            else
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, null);
                            }
                        }
                        i++;
                    }
                }
                param[i] = new SqlParameter("@startRecordIndex", startRecordIndex);
                param[i + 1] = new SqlParameter("@amountOfRecord", amountOfRecord);
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(ServiceReader._conectionString, CommandType.StoredProcedure, strTableName + "_Select_Paging", param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new DataTable();
        }

        /// <summary>
        /// Lay du lieu theo ten bang va so record can lay, lay tu so record nao
        /// </summary>
        /// <param name="strTableName">Ten table</param>
        /// <param name="index">Bat dau tu record nao </param>
        /// <param name="numofRow">So record can lay</param>
        /// <returns></returns>
        public static DataTable GetData(object objCondition, ref int AllRows)
        {
            string strTableName = ((TableAttribute)(objCondition.GetType().GetCustomAttributes(true)[0])).TableName.ToString();
            try
            {
                int count = (objCondition.GetType()).GetProperties().Count();
                count += 2;
                SqlParameter[] param = new SqlParameter[count+2];
                int i = 0;
                foreach (PropertyInfo property in (objCondition.GetType()).GetProperties())
                {
                    if (property.GetCustomAttributes(true).Length > 0)
                    {
                        ColumnAttribute attribute = ((ColumnAttribute)(property.GetCustomAttributes(true)[0]));
                        if (attribute.ColumnType == SqlDbType.DateTime)
                        {
                            string currentLang = string.Empty;
                            //CommonFunction.IsLocalLang(out currentLang);
                            //System.IFormatProvider cul = new System.Globalization.CultureInfo(currentLang, true);
                            string datetimeData = null;
                            if (property.GetValue(objCondition, null) != null)
                            {
                                //datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString(), cul).ToString("MM/dd/yyyy");
                                datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString()).ToString("MM/dd/yyyy");
                            }
                            param[i] = new SqlParameter("@" + attribute.ColumnName, datetimeData);
                        }
                        else
                        {
                            if (property.GetValue(objCondition, null) != string.Empty)
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, property.GetValue(objCondition, null));
                            }
                            else
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, null);
                            }
                        }
                        i++;
                    }
                }
                //param[i] = new SqlParameter("@PageNum", SqlDbType.Int);
                //param[i].Value =1;
                //i++;
                //param[i] = new SqlParameter("@PageSize", SqlDbType.Int);
                //param[i].Value =500;
                //i++;
                param[i] = new SqlParameter("@TotalRowsNum", SqlDbType.Int);
                param[i].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(ServiceReader._conectionString, CommandType.StoredProcedure, "DownloadReport_Select_Paging2", param);
                if (ds != null && ds.Tables.Count > 0)
                {
                    AllRows = WahooConfiguration.DataTypeProtect.ProtectInt32(param[i].Value);
                    return ds.Tables[0];
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new DataTable();
        }


        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Insert(object objCondition)
        {
            string tableName = ((TableAttribute)(objCondition.GetType().GetCustomAttributes(true)[0])).TableName.ToString();            
            int primarykeyIndex = -1;
            bool isPrimaryIntType = false;
            try
            {
                int count = (objCondition.GetType()).GetProperties().Count();
                SqlParameter[] param = new SqlParameter[count];
                int i = 0;
                foreach (PropertyInfo property in (objCondition.GetType()).GetProperties())
                {
                    if (property.GetCustomAttributes(true).Length > 0)
                    {
                        ColumnAttribute attribute = ((ColumnAttribute)(property.GetCustomAttributes(true)[0]));
                        if (attribute.ColumnType == SqlDbType.DateTime)
                        {
                            string currentLang = string.Empty;
                            //CommonFunction.IsLocalLang(out currentLang);
                            //System.IFormatProvider cul = new System.Globalization.CultureInfo(currentLang, true);
                            string datetimeData = null;
                            if (property.GetValue(objCondition, null) != null)
                            {
                                //datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString(), cul).ToString("MM/dd/yyyy");
                                datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString()).ToString("MM/dd/yyyy");
                            }
                            param[i] = new SqlParameter("@" + attribute.ColumnName, datetimeData);
                        }
                        else if (attribute.IsPrimaryKey)
                        {
                            primarykeyIndex = i;
                            if (attribute.ColumnType.ToString().ToUpper().Equals("INT"))
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, 0);
                                param[i].Direction = ParameterDirection.Output;
                                isPrimaryIntType = true;
                            }
                        }
                        else
                        {
                            if (property.GetValue(objCondition, null) != string.Empty)
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, property.GetValue(objCondition, null));
                            }
                            else
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, null);
                            }
                        }                        
                        i++;
                    }
                }
                string storeName = tableName + "_Insert" ;
                int success = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, storeName, param);
                if (isPrimaryIntType == true && success > 0)
                {
                    if (primarykeyIndex > -1 && param[primarykeyIndex].Value != null)
                    {
                        return Convert.ToInt32(param[primarykeyIndex].Value.ToString());
                    }
                }
                else if ((isPrimaryIntType == false && success > 0))
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }            
            return -1;
        }

        /// <summary>
        /// Pass du lieu tu mot object bat ky cho service 
        /// Service se tu dong insert du lieu tuong ung voi table user dua vao
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Update(object objCondition)
        {
            string strTableName = ((TableAttribute)(objCondition.GetType().GetCustomAttributes(true)[0])).TableName.ToString();
            try
            {
                int count = (objCondition.GetType()).GetProperties().Count();
                SqlParameter[] param = new SqlParameter[count];
                int i = 0;
                foreach (PropertyInfo property in (objCondition.GetType()).GetProperties())
                {
                    if (property.GetCustomAttributes(true).Length > 0)
                    {
                        ColumnAttribute attribute = ((ColumnAttribute)(property.GetCustomAttributes(true)[0]));
                        if (attribute.ColumnType == SqlDbType.DateTime)
                        {
                            string currentLang = string.Empty;
                            //CommonFunction.IsLocalLang(out currentLang);
                            //System.IFormatProvider cul = new System.Globalization.CultureInfo(currentLang, true);
                            string datetimeData = null;
                            if (property.GetValue(objCondition, null) != null)
                            {
                                //datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString(), cul).ToString("MM/dd/yyyy");
                                datetimeData = DateTime.Parse(property.GetValue(objCondition, null).ToString()).ToString("MM/dd/yyyy");
                            }
                            param[i] = new SqlParameter("@" + attribute.ColumnName, datetimeData);
                        }
                        else
                        {
                            if (property.GetValue(objCondition, null) != string.Empty)
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, property.GetValue(objCondition, null));
                            }
                            else
                            {
                                param[i] = new SqlParameter("@" + attribute.ColumnName, null);
                            }
                        }
                        i++;
                    }
                }
                string storeName = strTableName + "_Update";
                int success = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, storeName, param);
                if (success > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public static bool Delete(object obj)
        {
            try
            {
                string primarykeyValue = string.Empty;
                string tableName = string.Empty;
                string primaryKey = GetObjectPrimaryKeyInfo(obj, out primarykeyValue, out tableName);
                SqlParameter param = new SqlParameter("@" + primaryKey, primarykeyValue);
                string storeName = tableName + "_Delete";

                int i = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, storeName, param);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }        

        private static string GetObjectPrimaryKeyInfo(object obj, out string primarykeyValue, out string tableName)
        {
            primarykeyValue = string.Empty;
            tableName = ((TableAttribute)(obj.GetType().GetCustomAttributes(true)[0])).TableName.ToString();
            foreach (PropertyInfo property in (obj.GetType()).GetProperties())
            {
                if (property.GetCustomAttributes(true).Length > 0)
                {
                    ColumnAttribute attribute = ((ColumnAttribute)(property.GetCustomAttributes(true)[0]));
                    if (attribute.IsPrimaryKey)
                    {
                        primarykeyValue = property.GetValue(obj, null).ToString();
                        return attribute.ColumnName;
                    }
                }
            }
            return string.Empty;
        }
        private static string GeneralConn()
        {
            Config configObl = new Config(System.Reflection.Assembly.GetEntryAssembly().Location + ".config");
            string _pass = "!@#vtc123work";
            string _init = "@1B2c3D4e5F6g7H8";
            string con = configObl.ReadSetting("strConnectionString");
            RijndaelEnhanced rH = new RijndaelEnhanced(_pass, _init);
            return rH.Decrypt(con);
        }
        /// <summary>
        /// Update all channel to STARTED, STOPED...
        /// </summary>
        /// <param name="statusExecute"></param>
        /// <returns></returns>
        public static bool UpdateAllChannelStatusExecute(string statusExecute)
        {
            try
            {
                SqlParameter param = new SqlParameter("@STATUSEXECUTE", statusExecute);
                int i = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, "UPDATE_ALL_CHANNEL_STATUSEXECUTE", param);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update all channel to deploy or not
        /// </summary>
        /// <param name="isDeployed"></param>
        /// <returns></returns>
        public static bool UpdateAllChannelDeployed(Boolean isDeployed)
        {
            try
            {
                SqlParameter param = new SqlParameter("@IsDeployed", isDeployed);
                int i = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, "UPDATE_ALL_CHANNEL_ISDEPLOYED", param);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete HistoryChannel of Channel
        /// </summary>
        /// <param name="isDeployed"></param>
        /// <returns></returns>
        public static bool DeleteHistoryOfChannel(int idChannel)
        {
            try
            {
                SqlParameter param = new SqlParameter("@IdChannel", idChannel);
                int i = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, "DELETE_HISTORYOFCHANNEL_IDCHANNEL", param);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool EmailNotification_Delete(int id)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", id);
                int i = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, "EmailNotification_Delete", param);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public static bool EmailNotification_Insert(string strDisplayName, string strEmail)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DisplayName", strDisplayName);
                param[1] = new SqlParameter("@Email", strEmail);
                int i = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, "EmailNotification_Insert", param);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EmailNotification_Update(int id,string strDisplayName, string strEmail)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ID", id);
                param[1] = new SqlParameter("@DisplayName", strDisplayName);
                param[2] = new SqlParameter("@Email", strEmail);
                int i = SqlHelper.ExecuteNonQuery(ServiceReader._conectionString, CommandType.StoredProcedure, "EmailNotification_Update", param);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EmailNotification_Select()
        {
            try
            {
                return SqlHelper.ExecuteDataset(ServiceReader._conectionString, CommandType.StoredProcedure, "EmailNotification_select").Tables[0];
             
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getClientDisconnected()
        {
            try
            {
                SqlParameter[] para=new SqlParameter[2];
                para[0] = new SqlParameter("@FromMinute", AliasMessage.FROM_MINUTE);
                para[1] = new SqlParameter("@ToMinute", AliasMessage.TO_MINUTE);
                return SqlHelper.ExecuteDataset(ServiceReader._conectionString, CommandType.StoredProcedure, "sp_Get_CLient_Disconnected", para).Tables[0];
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
