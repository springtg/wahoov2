using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WahooData.DBO.Base
{
    public abstract class BaseDBO
    {
        public BaseDBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private DataContext _DataContext;
        /// <summary>
        /// Lazy load DataObjectContext
        /// </summary>
        protected DataContext DataContext
        {
            get
            {
                if (this._DataContext == null)
                    this._DataContext = new DataContext();
                return this._DataContext;
            }
        }

        /// <summary>
        /// This method call delete method in DataAccessLayer 
        /// using this to pass values.
        /// </summary>
        /// <returns>Status (true: successful,  false: unsuccessful ) </returns>             
        public bool Delete()
        {
            try
            {
                return DataAccessLayer.Delete(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method call update method in DataAccessLayer 
        /// using this to pass values.
        /// </summary>
        /// <returns>Status (true: successful,  false: unsuccessful ) </returns>        
        public bool Update()
        {
            try
            {
                return DataAccessLayer.Update(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
