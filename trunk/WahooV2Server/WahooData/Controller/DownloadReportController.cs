using System;
using System.Collections.Generic;
using WahooData.DBO.Base;
using WahooData.DBO;

namespace WahooData.Controller
{
	/// <summary>
    /// The controller of DownloadReport
    /// </summary>
    public class DownloadReportController : BaseController
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DownloadReportController()
        {
        }
        /// <summary>
        /// Insert item to database.
        /// </summary>
        /// <returns>Return ID if add successful; otherwise return -1.</returns>    
        public int Add(DownloadReport item)
        {
            try
            {
                return base.Add(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get DownloadReport object match condition contain in obj.
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>Return the DownloadReport match conditions.</returns>
        public DownloadReport GetItem(DownloadReport condition)
        {
            return (DownloadReport)base.GetItem(condition);
        }

        /// <summary>
        /// Get DownloadReport collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The DownloadReport collection match conditions.</returns>
        public List<DownloadReport> GetItemsCollection(DownloadReport condition)
        {
            try
            {
                List<object> items = base.GetItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<DownloadReport>(delegate(object objDownloadReport)
                {
                    return (DownloadReport)objDownloadReport;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="index"></param>
        /// <param name="numOfRow"></param>
        /// <returns></returns>
        public List<DownloadReport> GetItemsCollection(DownloadReport condition, int index, int numOfRow)
        {
            try
            {
                List<object> items = base.GetItemsCollection(condition, index, numOfRow);
                if (items == null)
                    return null;

                return items.ConvertAll<DownloadReport>(delegate(object objDownloadReport)
                {
                    return (DownloadReport)objDownloadReport;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="index"></param>
        /// <param name="numOfRow"></param>
        /// <returns></returns>
        public List<DownloadReport> GetItemsCollection(WahooData.DBO.ConditionDR condition, ref int allrows)
        {
            try
            {
                List<object> items = base.GetItemsCollection(condition,ref allrows);
                if (items == null)
                    return null;

                return items.ConvertAll<DownloadReport>(delegate(object objDownloadReport)
                {
                    return (DownloadReport)objDownloadReport;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get DownloadReport collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// /// <param name="condition">file name is like with pattern searh</param>
        /// <returns>The DownloadReport collection match conditions.</returns>
        public List<DownloadReport> GetItemsCollection(List<DownloadReport> listReport, CMonitorCondition condition)
        {
            return listReport.FindAll(delegate(DownloadReport p) { return CompareItem(p, condition); });
        }

        private bool CompareItem(DownloadReport p, CMonitorCondition condition)
        {
            bool rs = false;
            //Validate text partten in file name
            if (condition.FileName!=null)
            {
                if (p.Filename.Contains(condition.FileName.ToLower()) || p.Filename.Contains(condition.FileName.ToUpper()))
                {
                    rs = true;
                }
            }
            if (!condition.ClientID.Equals(null))
            {
                if (p.IdClient.Equals(condition.ClientID))
                {
                    rs = true;
                }
            }
            if (!condition.DateTo.Equals(null) && !condition.DateFrom.Equals(null))
            {
                if (p.TimeDownloaded < condition.DateTo && p.TimeDownloaded > condition.DateFrom)
                {
                    rs = true;
                }
            }
            return rs;
        }

        /// <summary>
        /// Find all DownloadReport collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The DownloadReport collection match conditions.</returns>
        public List<DownloadReport> FindItemsCollection(DownloadReport condition)
        {
            try
            {
                List<object> items = base.FindItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<DownloadReport>(delegate(object objDownloadReport)
                {
                    return (DownloadReport)objDownloadReport;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class CMonitorCondition
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        private int _clientID;

        public int ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        private Nullable<DateTime> _dateFrom;

        public Nullable<DateTime> DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }
        private Nullable<DateTime> _dateTo;

        public Nullable<DateTime> DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }

        private Nullable<bool> _sentToPrint;

        public Nullable<bool> SentToPrint
        {
            get { return _sentToPrint; }
            set { _sentToPrint = value; }
        }
        private Nullable<bool> downloadSuccess;

        public Nullable<bool> DownloadSuccess
        {
            get { return downloadSuccess; }
            set { downloadSuccess = value; }
        }

    }
}
