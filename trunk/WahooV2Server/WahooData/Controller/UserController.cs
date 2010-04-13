using System;
using System.Collections.Generic;
using WahooData.DBO;
using WahooData.DBO.Base;

namespace WahooData.Controller
{
    /// <summary>
    /// The controller of User
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserController()
        {
        }
        /// <summary>
        /// Insert item to database.
        /// </summary>
        /// <returns>Return ID if add successful; otherwise return -1.</returns>    
        public int Add(User item)
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
        /// Get User object match condition contain in obj.
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>Return the User match conditions.</returns>
        public User GetItem(User condition)
        {
            return (User)base.GetItem(condition);
        }

        /// <summary>
        /// Get User collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The User collection match conditions.</returns>
        public List<User> GetItemsCollection(User condition)
        {
            try
            {
                List<object> items = base.GetItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<User>(delegate(object objUser)
                {
                    return (User)objUser;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find all User collection match condition contain in obj
        /// </summary>
        /// <param name="condition">The obj contain conditions to filter.</param>
        /// <returns>The User collection match conditions.</returns>
        public List<User> FindItemsCollection(User condition)
        {
            try
            {
                List<object> items = base.FindItemsCollection(condition);
                if (items == null)
                    return null;

                return items.ConvertAll<User>(delegate(object objUser)
                {
                    return (User)objUser;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
