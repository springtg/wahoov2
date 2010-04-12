using System;
using System.Data;
using System.Collections.Generic;
using WahooData.DBO.Base;

namespace WahooData.DBO
{
    [TableAttribute("HistoryOfChannel")]
    public class HistoryOfChannel : BaseDBO
    {
        #region Fields

        private int? _Id;
        private int? _IdChannel;
        private DateTime? _DateExecute;
        private string _Description;
        private string _Status;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public HistoryOfChannel()
        {
        }

        /// <summary>
        /// Constructor with Id
        /// </summary>
        /// <param name="Id">The Id</param>
        public HistoryOfChannel(int? Id)
        {
            this.Id = Id;
        }

        /// <summary>
        /// Constructor with all parameters
        /// </summary>
        /// <param name="Id">Sets int? value for Id</param>
        /// <param name="IdChannel">Sets int? value for IdChannel</param>
        /// <param name="DateExecute">Sets DateTime? value for DateExecute</param>
        /// <param name="Description">Sets string value for Description</param>
        /// <param name="Status">Sets string value for Status</param>
        public HistoryOfChannel(int? id, int? idChannel, DateTime? dateExecute, string description, string status)
        {
            this.Id = id;
            this.IdChannel = idChannel;
            this.DateExecute = dateExecute;
            this.Description = description;
            this.Status = status;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets int? value for Id
        /// </summary>
        [ColumnAttribute("Id", SqlDbType.Int, 4, true)]
        public int? Id
        {
            set
            {
                this._Id = value;
            }
            get
            {
                return this._Id;
            }
        }

        /// <summary>
        /// Gets or sets int? value for IdChannel
        /// </summary>
        [ColumnAttribute("IdChannel", SqlDbType.Int, 4, false)]
        public int? IdChannel
        {
            set
            {
                this._IdChannel = value;
            }
            get
            {
                return this._IdChannel;
            }
        }

        /// <summary>
        /// Gets or sets DateTime? value for DateExecute
        /// </summary>
        [ColumnAttribute("DateExecute", SqlDbType.DateTime, 8, false)]
        public DateTime? DateExecute
        {
            set
            {
                this._DateExecute = value;
            }
            get
            {
                return this._DateExecute;
            }
        }

        /// <summary>
        /// Gets or sets string value for Description
        /// </summary>
        [ColumnAttribute("Description", SqlDbType.NVarChar, 400, false)]
        public string Description
        {
            set
            {
                this._Description = value;
            }
            get
            {
                return this._Description;
            }
        }

        /// <summary>
        /// Gets or sets string value for Status
        /// </summary>
        [ColumnAttribute("Status", SqlDbType.NVarChar, 10, false)]
        public string Status
        {
            set
            {
                this._Status = value;
            }
            get
            {
                return this._Status;
            }
        }


        /// <summary>
        /// Get a Channel of current HistoryOfChannel object base on IdChannel
        /// </summary>
        public Channel Channel
        {
            get
            {
                if (this.IdChannel == null)
                    return null;

                Channel channelFilter = new Channel(this.IdChannel.Value);
                return this.DataContext.ChannelController.GetItem(channelFilter);
            }
        }

        #endregion
    }
}
