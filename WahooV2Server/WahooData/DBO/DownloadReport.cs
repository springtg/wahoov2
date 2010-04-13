using System;
using System.Data;
using System.Collections.Generic;
using WahooData.DBO.Base;

namespace WahooData.DBO
{
    [TableAttribute("DownloadReport")]
    public class DownloadReport : BaseDBO
    {
        #region Fields

        private int? _Id;
        private int? _IdClient;
        private string _Filename;
        private bool? _Success;
        private DateTime? _TimeDownloaded;
        private bool? _IsSentToPrint;
        private DateTime? _TimeSentToPrint;
        private string _IpAddress;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public DownloadReport()
        {
        }

        /// <summary>
        /// Constructor with Id
        /// </summary>
        /// <param name="Id">The Id</param>
        public DownloadReport(int? Id)
        {
            this.Id = Id;
        }

        /// <summary>
        /// Constructor with all parameters
        /// </summary>
        /// <param name="Id">Sets int? value for Id</param>
        /// <param name="IdClient">Sets int? value for IdClient</param>
        /// <param name="Filename">Sets string value for Filename</param>
        /// <param name="Success">Sets bool? value for Success</param>
        /// <param name="TimeDownloaded">Sets DateTime? value for TimeDownloaded</param>
        /// <param name="IsSentToPrint">Sets bool? value for IsSentToPrint</param>
        /// <param name="TimeSentToPrint">Sets DateTime? value for TimeSentToPrint</param>
        /// <param name="IpAddress">Sets string value for IpAddress</param>
        public DownloadReport(int? id, int? idClient, string filename, bool? success, DateTime? timeDownloaded, bool? isSentToPrint, DateTime? timeSentToPrint, string ipAddress)
        {
            this.Id = id;
            this.IdClient = idClient;
            this.Filename = filename;
            this.Success = success;
            this.TimeDownloaded = timeDownloaded;
            this.IsSentToPrint = isSentToPrint;
            this.TimeSentToPrint = timeSentToPrint;
            this.IpAddress = ipAddress;
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
        /// Gets or sets string value for Filename
        /// </summary>
        [ColumnAttribute("Filename", SqlDbType.NVarChar, 100, false)]
        public string Filename
        {
            set
            {
                this._Filename = value;
            }
            get
            {
                return this._Filename;
            }
        }

        /// <summary>
        /// Gets or sets bool? value for Success
        /// </summary>
        [ColumnAttribute("Success", SqlDbType.Bit, 1, false)]
        public bool? Success
        {
            set
            {
                this._Success = value;
            }
            get
            {
                return this._Success;
            }
        }

        public string Downloaded
        {
            get
            {
                if (_Success.Equals(true)) return WahooConfiguration.Message.GetMessageById("MONITOR_Text003");
                else return WahooConfiguration.Message.GetMessageById("MONITOR_Text002");
            }
        }

        public string SentToPrint
        {
            get
            {
                if (_IsSentToPrint.Equals(true)) return WahooConfiguration.Message.GetMessageById("MONITOR_Text003");
                else return WahooConfiguration.Message.GetMessageById("MONITOR_Text002");
            }
        }
        /// <summary>
        /// Gets or sets DateTime? value for TimeDownloaded
        /// </summary>
        [ColumnAttribute("TimeDownloaded", SqlDbType.DateTime, 8, false)]
        public DateTime? TimeDownloaded
        {
            set
            {
                this._TimeDownloaded = value;
            }
            get
            {
                return this._TimeDownloaded;
            }
        }

        /// <summary>
        /// Gets or sets bool? value for IsSentToPrint
        /// </summary>
        [ColumnAttribute("IsSentToPrint", SqlDbType.Bit, 1, false)]
        public bool? IsSentToPrint
        {
            set
            {
                this._IsSentToPrint = value;
            }
            get
            {
                return this._IsSentToPrint;
            }
        }

        /// <summary>
        /// Gets or sets DateTime? value for TimeSentToPrint
        /// </summary>
        [ColumnAttribute("TimeSentToPrint", SqlDbType.DateTime, 8, false)]
        public DateTime? TimeSentToPrint
        {
            set
            {
                this._TimeSentToPrint = value;
            }
            get
            {
                return this._TimeSentToPrint;
            }
        }

        /// <summary>
        /// Gets or sets string value for IpAddress
        /// </summary>
        [ColumnAttribute("IpAddress", SqlDbType.NVarChar, 20, false)]
        public string IpAddress
        {
            set
            {
                this._IpAddress = value;
            }
            get
            {
                return this._IpAddress;
            }
        }


        /// <summary>
        /// Get a Client of current DownloadReport object base on IdClient
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
