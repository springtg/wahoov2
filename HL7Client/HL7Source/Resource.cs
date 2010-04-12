using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HL7Source
{
    public class Resource
    {
        private DataSet _resourceDataset;        

        #region Resource Mapping
        public const string ResourceTableMappingName = "item";
        public const string ResourceKeyMappingName = "key";
        public const string ResourceIdMappingName = "id";
        public const string ResourceValueMappingName = "Value";
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public Resource()
        {
            try
            {
                //1.Loading message file
                this._resourceDataset = new DataSet();
                this._resourceDataset.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\Resource.xml");
            }
            catch
            {
                //4.Exception handling
                throw;
            }
        }
        /// <summary>
        /// Get Resource By ID
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable GetResourceByKey(string key)
        {
            //1. Create datatable
            DataTable resourceTable = this._resourceDataset.Tables[Resource.ResourceTableMappingName].Clone();
            resourceTable.TableName = key;
            //2. Import all rows of this resource by key
            foreach (DataRow dr in this._resourceDataset.Tables[Resource.ResourceTableMappingName].Select(Resource.ResourceKeyMappingName + "='" + key + "'"))
            {
                resourceTable.ImportRow(dr);
            }
            //3. Return 
            return resourceTable;
        }

        /// <summary>
        /// Get resource by key and id
        /// </summary>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetResourceByKey(string key, string id)
        {
            //1. Search resource by key and id
            DataRow[] dr = this._resourceDataset.Tables[Resource.ResourceTableMappingName].Select(Resource.ResourceKeyMappingName + "='" + key + "' AND " + Resource.ResourceIdMappingName + "='" + id + "'");
            //2. Check resource exists or not
            if (dr.Length > 0)
            {
                //2.1. In case resource exists then return value
                if (dr[0][Resource.ResourceValueMappingName] != System.DBNull.Value)
                {
                    return dr[0][Resource.ResourceValueMappingName].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                //2.2. In case resource not exists then return null
                return null;
            }
        }
    }
}

