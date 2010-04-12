using System;
using System.Collections.Generic;
using WahooData.DBO.Base;
using WahooData.DBO;

namespace WahooData.Controller
{
	/// <summary>
    /// The controller of Channel
    /// </summary>
    public class ChannelController : BaseController
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChannelController()
        {
        }
        /// <summary>
        /// Insert item to database.
        /// </summary>
        /// <returns>Return ID if add successful; otherwise return -1.</returns>    
        public int Add(Channel item)
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
        /// Get Channel object match condition contain in obj.
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>Return the Channel match conditions.</returns>
        public Channel GetItem(Channel condition)
        {
            return (Channel)base.GetItem(condition);
        }

        /// <summary>
        /// Get Channel collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The Channel collection match conditions.</returns>
        public List<Channel> GetItemsCollection(Channel condition)
        {
            try
            {
                List<object> items = base.GetItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<Channel>(delegate(object objChannel)
                {
                    return (Channel)objChannel;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find all Channel collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The Channel collection match conditions.</returns>
        public List<Channel> FindItemsCollection(Channel condition)
        {
            try
            {
                List<object> items = base.FindItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<Channel>(delegate(object objChannel)
                {
                    return (Channel)objChannel;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
