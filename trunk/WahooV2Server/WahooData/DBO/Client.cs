using System;
using System.Data;
using System.Collections.Generic;
using WahooData.DBO.Base;

namespace WahooData.DBO
{
    [TableAttribute("Client")]
    public class Client : BaseDBO
    {
        #region Fields

        private int? _Id;
        private string _Name;
        private string _Address1;
        private string _Address2;
        private string _City;
        private string _State;
        private string _Zip;
        private string _Phone;
        private string _Mail;
        private string _Description;
        private DateTime? _DateCreated;
        private DateTime? _DateUpdated;
        private string _ClientCode;
        private string _ContactName;
        private string _LicenseKey;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Client()
        {
        }

        /// <summary>
        /// Constructor with Id
        /// </summary>
        /// <param name="Id">The Id</param>
        public Client(int? Id)
        {
            this.Id = Id;
        }

        /// <summary>
        /// Constructor with all parameters
        /// </summary>
        /// <param name="Id">Sets int? value for Id</param>
        /// <param name="Name">Sets string value for Name</param>
        /// <param name="Address1">Sets string value for Address1</param>
        /// <param name="Address2">Sets string value for Address2</param>
        /// <param name="City">Sets string value for City</param>
        /// <param name="State">Sets string value for State</param>
        /// <param name="Zip">Sets string value for Zip</param>
        /// <param name="Phone">Sets string value for Phone</param>
        /// <param name="Mail">Sets string value for Mail</param>
        /// <param name="Description">Sets string value for Description</param>
        /// <param name="DateCreated">Sets DateTime? value for DateCreated</param>
        /// <param name="DateUpdated">Sets DateTime? value for DateUpdated</param>
        /// <param name="ClientCode">Sets string value for ClientCode</param>
        /// <param name="ContactName">Sets string value for ContactName</param>
        /// <param name="LicenseKey">Sets string value for LicenseKey</param>
        public Client(int? id, string name, string address1, string address2, string city, string state, string zip, string phone, string mail, string description, DateTime? dateCreated, DateTime? dateUpdated, string clientCode, string contactName, string licenseKey)
        {
            this.Id = id;
            this.Name = name;
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Phone = phone;
            this.Mail = mail;
            this.Description = description;
            this.DateCreated = dateCreated;
            this.DateUpdated = dateUpdated;
            this.ClientCode = clientCode;
            this.ContactName = contactName;
            this.LicenseKey = licenseKey;
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
        /// Gets or sets string value for Name
        /// </summary>
        [ColumnAttribute("Name", SqlDbType.NVarChar, 100, false)]
        public string Name
        {
            set
            {
                this._Name = value;
            }
            get
            {
                return this._Name;
            }
        }

        /// <summary>
        /// Gets or sets string value for Address1
        /// </summary>
        [ColumnAttribute("Address1", SqlDbType.NVarChar, 500, false)]
        public string Address1
        {
            set
            {
                this._Address1 = value;
            }
            get
            {
                return this._Address1;
            }
        }

        /// <summary>
        /// Gets or sets string value for Address2
        /// </summary>
        [ColumnAttribute("Address2", SqlDbType.NVarChar, 500, false)]
        public string Address2
        {
            set
            {
                this._Address2 = value;
            }
            get
            {
                return this._Address2;
            }
        }

        /// <summary>
        /// Gets or sets string value for City
        /// </summary>
        [ColumnAttribute("City", SqlDbType.NVarChar, 50, false)]
        public string City
        {
            set
            {
                this._City = value;
            }
            get
            {
                return this._City;
            }
        }

        /// <summary>
        /// Gets or sets string value for State
        /// </summary>
        [ColumnAttribute("State", SqlDbType.NVarChar, 50, false)]
        public string State
        {
            set
            {
                this._State = value;
            }
            get
            {
                return this._State;
            }
        }

        /// <summary>
        /// Gets or sets string value for Zip
        /// </summary>
        [ColumnAttribute("Zip", SqlDbType.NVarChar, 50, false)]
        public string Zip
        {
            set
            {
                this._Zip = value;
            }
            get
            {
                return this._Zip;
            }
        }

        /// <summary>
        /// Gets or sets string value for Phone
        /// </summary>
        [ColumnAttribute("Phone", SqlDbType.NVarChar, 20, false)]
        public string Phone
        {
            set
            {
                this._Phone = value;
            }
            get
            {
                return this._Phone;
            }
        }

        /// <summary>
        /// Gets or sets string value for Mail
        /// </summary>
        [ColumnAttribute("Mail", SqlDbType.NVarChar, 50, false)]
        public string Mail
        {
            set
            {
                this._Mail = value;
            }
            get
            {
                return this._Mail;
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
        /// Gets or sets string value for ClientCode
        /// </summary>
        [ColumnAttribute("ClientCode", SqlDbType.NVarChar, 10, false)]
        public string ClientCode
        {
            set
            {
                this._ClientCode = value;
            }
            get
            {
                return this._ClientCode;
            }
        }

        /// <summary>
        /// Gets or sets string value for ContactName
        /// </summary>
        [ColumnAttribute("ContactName", SqlDbType.NVarChar, 200, false)]
        public string ContactName
        {
            set
            {
                this._ContactName = value;
            }
            get
            {
                return this._ContactName;
            }
        }

        /// <summary>
        /// Gets or sets string value for LicenseKey
        /// </summary>
        [ColumnAttribute("LicenseKey", SqlDbType.NVarChar, 100, false)]
        public string LicenseKey
        {
            set
            {
                this._LicenseKey = value;
            }
            get
            {
                return this._LicenseKey;
            }
        }


        /// <summary>
        /// Get a list Channel of current Client object base on Id
        /// </summary>
        public List<Channel> Channel
        {
            get
            {
                if (this.Id == null)
                    return null;
                Channel channelFilter = new Channel();
                channelFilter.IdClient = this.Id;
                return this.DataContext.ChannelController.GetItemsCollection(channelFilter);
            }
        }

        /// <summary>
        /// Get a list DownloadReport of current Client object base on Id
        /// </summary>
        public List<DownloadReport> DownloadReport
        {
            get
            {
                if (this.Id == null)
                    return null;
                DownloadReport downloadReportFilter = new DownloadReport();
                downloadReportFilter.IdClient = this.Id;
                return this.DataContext.DownloadReportController.GetItemsCollection(downloadReportFilter);
            }
        }

        #endregion
    }
}
