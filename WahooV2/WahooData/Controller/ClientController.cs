using System;
using System.Collections.Generic;
using WahooData.DBO.Base;
using WahooData.DBO;

namespace WahooData.Controller
{
	/// <summary>
    /// The controller of Client
    /// </summary>
    public class ClientController : BaseController
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientController()
        {
        }

        /// <summary>
        /// Insert item to database.
        /// </summary>
        /// <returns>Return ID if add successful; otherwise return -1.</returns>    
        public int Add(Client item)
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
        /// Get Client object match condition contain in obj.
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>Return the Client match conditions.</returns>
        public Client GetItem(Client condition)
        {
            return (Client)base.GetItem(condition);
        }

        /// <summary>
        /// Get Client collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The Client collection match conditions.</returns>
        public List<Client> GetItemsCollection(Client condition)
        {
            try
            {
                List<object> items = base.GetItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<Client>(delegate(object objClient)
                {
                    return (Client)objClient;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find all Client collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The Client collection match conditions.</returns>
        public List<Client> FindItemsCollection(Client condition)
        {
            try
            {
                List<object> items = base.FindItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<Client>(delegate(object objClient)
                {
                    return (Client)objClient;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
