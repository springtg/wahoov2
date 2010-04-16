using System;
using System.Collections.Generic;
using WahooData.DBO.Base;
using WahooData.DBO;

namespace WahooData.Controller
{
	/// <summary>
    /// The controller of HistoryOfChannel
    /// </summary>
    public class HistoryOfChannelController : BaseController
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public HistoryOfChannelController()
        {
        }
        /// <summary>
        /// Insert item to database.
        /// </summary>
        /// <returns>Return ID if add successful; otherwise return -1.</returns>    
        public int Add(HistoryOfChannel item)
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
        /// Get HistoryOfChannel object match condition contain in obj.
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>Return the HistoryOfChannel match conditions.</returns>
        public HistoryOfChannel GetItem(HistoryOfChannel condition)
        {
            return (HistoryOfChannel)base.GetItem(condition);
        }

        /// <summary>
        /// Get HistoryOfChannel collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The HistoryOfChannel collection match conditions.</returns>
        public List<HistoryOfChannel> GetItemsCollection(HistoryOfChannel condition)
        {
            try
            {
                List<object> items = base.GetItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<HistoryOfChannel>(delegate(object objHistoryOfChannel)
                {
                    return (HistoryOfChannel)objHistoryOfChannel;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find all HistoryOfChannel collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The HistoryOfChannel collection match conditions.</returns>
        public List<HistoryOfChannel> FindItemsCollection(HistoryOfChannel condition)
        {
            try
            {
                List<object> items = base.FindItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<HistoryOfChannel>(delegate(object objHistoryOfChannel)
                {
                    return (HistoryOfChannel)objHistoryOfChannel;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Delete HistoryChannel of Channel
        /// </summary>
        /// <param name="isDeployed"></param>
        /// <returns></returns>
        public Boolean DeleteHistoryOfChannel(int idChannel)
        {
            return DataAccessLayer.DeleteHistoryOfChannel(idChannel);
        }
    }
}
