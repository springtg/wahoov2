using System;
using System.Data;
using System.Collections.Generic;
using WahooData.DBO.Base;

namespace WahooData.DBO
{
    [TableAttribute("Channel")]
    public class Channel : BaseDBO
    {
        #region Fields

        private int? _Id;
        private int? _IdClient;
        private DateTime? _DateCreated;
        private DateTime? _DateUpdated;
        private string _ChannelName;
        private bool? _Active;
        private string _Description;
        private string _FilePath;
        private string _StatusExecute;
        private int? _Sent;
        private int? _Error;
        private string _ServerFolder;
        private bool? _StoreFile;
        private bool? _IsDeployed;
        private string _WsdlUrl;
        private bool? _IsConnected;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Channel()
        {
        }

        /// <summary>
        /// Constructor with Id
        /// </summary>
        /// <param name="Id">The Id</param>
        public Channel(int? Id)
        {
            this.Id = Id;
        }

        /// <summary>
        /// Constructor with all parameters
        /// </summary>
        /// <param name="Id">Sets int? value for Id</param>
        /// <param name="IdClient">Sets int? value for IdClient</param>
        /// <param name="DateCreated">Sets DateTime? value for DateCreated</param>
        /// <param name="DateUpdated">Sets DateTime? value for DateUpdated</param>
        /// <param name="ChannelName">Sets string value for ChannelName</param>
        /// <param name="Active">Sets bool? value for Active</param>
        /// <param name="Description">Sets string value for Description</param>
        /// <param name="FilePath">Sets string value for FilePath</param>
        /// <param name="StatusExecute">Sets string value for StatusExecute</param>
        /// <param name="Sent">Sets int? value for Sent</param>
        /// <param name="Error">Sets int? value for Error</param>
        /// <param name="ServerFolder">Sets string value for ServerFolder</param>
        /// <param name="StoreFile">Sets bool? value for StoreFile</param>
        /// <param name="IsDeployed">Sets bool? value for IsDeployed</param>
        /// <param name="WsdlUrl">Sets string value for WsdlUrl</param>
        /// <param name="IsConnected">Sets bool? value for IsConnected</param>
        public Channel(int? id, int? idClient, DateTime? dateCreated, DateTime? dateUpdated, string channelName, bool? active, string description, string filePath, string statusExecute, int? sent, int? error, string serverFolder, bool? storeFile, bool? isDeployed, string wsdlUrl, bool? isConnected)
        {
            this.Id = id;
            this.IdClient = idClient;
            this.DateCreated = dateCreated;
            this.DateUpdated = dateUpdated;
            this.ChannelName = channelName;
            this.Active = active;
            this.Description = description;
            this.FilePath = filePath;
            this.StatusExecute = statusExecute;
            this.Sent = sent;
            this.Error = error;
            this.ServerFolder = serverFolder;
            this.StoreFile = storeFile;
            this.IsDeployed = isDeployed;
            this.WsdlUrl = wsdlUrl;
            this.IsConnected = isConnected;
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
        /// Gets or sets int? value for IdClient
        /// </summary>
        [ColumnAttribute("IdClient", SqlDbType.Int, 4, false)]
        public int? IdClient
        {
            set
            {
                this._IdClient = value;
            }
            get
            {
                return this._IdClient;
            }
        }

        /// <summary>
        /// Gets or sets DateTime? value for DateCreated
        /// </summary>
        [ColumnAttribute("DateCreated", SqlDbType.DateTime, 8, false)]
        public DateTime? DateCreated
        {
            set
            {
                this._DateCreated = value;
            }
            get
            {
                return this._DateCreated;
            }
        }

        /// <summary>
        /// Gets or sets DateTime? value for DateUpdated
        /// </summary>
        [ColumnAttribute("DateUpdated", SqlDbType.DateTime, 8, false)]
        public DateTime? DateUpdated
        {
            set
            {
                this._DateUpdated = value;
            }
            get
            {
                return this._DateUpdated;
            }
        }

        /// <summary>
        /// Gets or sets string value for ChannelName
        /// </summary>
        [ColumnAttribute("ChannelName", SqlDbType.NVarChar, 100, false)]
        public string ChannelName
        {
            set
            {
                this._ChannelName = value;
            }
            get
            {
                return this._ChannelName;
            }
        }

        /// <summary>
        /// Gets or sets bool? value for Active
        /// </summary>
        [ColumnAttribute("Active", SqlDbType.Bit, 1, false)]
        public bool? Active
        {
            set
            {
                this._Active = value;
            }
            get
            {
                return this._Active;
            }
        }

        /// <summary>
        /// Gets or sets string value for Description
        /// </summary>
        [ColumnAttribute("Description", SqlDbType.NVarChar, 500, false)]
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
        /// Gets or sets string value for FilePath
        /// </summary>
        [ColumnAttribute("FilePath", SqlDbType.NVarChar, 200, false)]
        public string FilePath
        {
            set
            {
                this._FilePath = value;
            }
            get
            {
                return this._FilePath;
            }
        }

        /// <summary>
        /// Gets or sets string value for StatusExecute
        /// </summary>
        [ColumnAttribute("StatusExecute", SqlDbType.NVarChar, 50, false)]
        public string StatusExecute
        {
            set
            {
                this._StatusExecute = value;
            }
            get
            {
                return this._StatusExecute;
            }
        }

        /// <summary>
        /// Gets or sets int? value for Sent
        /// </summary>
        [ColumnAttribute("Sent", SqlDbType.Int, 4, false)]
        public int? Sent
        {
            set
            {
                this._Sent = value;
            }
            get
            {
                return this._Sent;
            }
        }

        /// <summary>
        /// Gets or sets int? value for Error
        /// </summary>
        [ColumnAttribute("Error", SqlDbType.Int, 4, false)]
        public int? Error
        {
            set
            {
                this._Error = value;
            }
            get
            {
                return this._Error;
            }
        }

        /// <summary>
        /// Gets or sets string value for ServerFolder
        /// </summary>
        [ColumnAttribute("ServerFolder", SqlDbType.NVarChar, 100, false)]
        public string ServerFolder
        {
            set
            {
                this._ServerFolder = value;
            }
            get
            {
                return this._ServerFolder;
            }
        }

        /// <summary>
        /// Gets or sets bool? value for StoreFile
        /// </summary>
        [ColumnAttribute("StoreFile", SqlDbType.Bit, 1, false)]
        public bool? StoreFile
        {
            set
            {
                this._StoreFile = value;
            }
            get
            {
                return this._StoreFile;
            }
        }

        /// <summary>
        /// Gets or sets bool? value for IsDeployed
        /// </summary>
        [ColumnAttribute("IsDeployed", SqlDbType.Bit, 1, false)]
        public bool? IsDeployed
        {
            set
            {
                this._IsDeployed = value;
            }
            get
            {
                return this._IsDeployed;
            }
        }

        /// <summary>
        /// Gets or sets string value for WsdlUrl
        /// </summary>
        [ColumnAttribute("WsdlUrl", SqlDbType.NVarChar, 200, false)]
        public string WsdlUrl
        {
            set
            {
                this._WsdlUrl = value;
            }
            get
            {
                return this._WsdlUrl;
            }
        }

        /// <summary>
        /// Gets or sets bool? value for IsConnected
        /// </summary>
        [ColumnAttribute("IsConnected", SqlDbType.Bit, 1, false)]
        public bool? IsConnected
        {
            set
            {
                this._IsConnected = value;
            }
            get
            {
                return this._IsConnected;
            }
        }


        /// <summary>
        /// Get a list HistoryOfChannel of current Channel object base on Id
        /// </summary>
        public List<HistoryOfChannel> HistoryOfChannel
        {
            get
            {
                if (this.Id == null)
                    return null;
                HistoryOfChannel historyOfChannelFilter = new HistoryOfChannel();
                historyOfChannelFilter.IdChannel = this.Id;
                return this.DataContext.HistoryOfChannelController.GetItemsCollection(historyOfChannelFilter);
            }
        }

        /// <summary>
        /// Get a Client of current Channel object base on IdClient
        /// </summary>
        public Client Client
        {
            get
            {
                if (this.IdClient == null)
                    return null;

                Client clientFilter = new Client(this.IdClient.Value);
                return this.DataContext.ClientController.GetItem(clientFilter);
            }
        }

        #endregion
    }
}
