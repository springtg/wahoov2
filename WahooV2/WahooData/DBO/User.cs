using System;
using System.Data;
using System.Collections.Generic;
using WahooData.DBO.Base;

namespace WahooData.DBO
{
    [TableAttribute("User")]
    public class User : BaseDBO
    {
        #region Fields

        private int? _Id;
        private string _Username;
        private string _Password;
        private string _FirstName;
        private string _LastName;
        private string _Organization;
        private string _Email;
        private string _Phone;
        private string _Description;
        private DateTime? _Date_Created;
        private DateTime? _Date_Updated;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Constructor with Id
        /// </summary>
        /// <param name="Id">The Id</param>
        public User(int? Id)
        {
            this.Id = Id;
        }

        /// <summary>
        /// Constructor with all parameters
        /// </summary>
        /// <param name="Id">Sets int? value for Id</param>
        /// <param name="Username">Sets string value for Username</param>
        /// <param name="Password">Sets string value for Password</param>
        /// <param name="FirstName">Sets string value for FirstName</param>
        /// <param name="LastName">Sets string value for LastName</param>
        /// <param name="Organization">Sets string value for Organization</param>
        /// <param name="Email">Sets string value for Email</param>
        /// <param name="Phone">Sets string value for Phone</param>
        /// <param name="Description">Sets string value for Description</param>
        /// <param name="Date_Created">Sets DateTime? value for Date_Created</param>
        /// <param name="Date_Updated">Sets DateTime? value for Date_Updated</param>
        public User(int? id, string username, string password, string firstName, string lastName, string organization, string email, string phone, string description, DateTime? date_Created, DateTime? date_Updated)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Organization = organization;
            this.Email = email;
            this.Phone = phone;
            this.Description = description;
            this.Date_Created = date_Created;
            this.Date_Updated = date_Updated;
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
        /// Gets or sets string value for Username
        /// </summary>
        [ColumnAttribute("Username", SqlDbType.NVarChar, 100, false)]
        public string Username
        {
            set
            {
                this._Username = value;
            }
            get
            {
                return this._Username;
            }
        }

        /// <summary>
        /// Gets or sets string value for Password
        /// </summary>
        [ColumnAttribute("Password", SqlDbType.NVarChar, 100, false)]
        public string Password
        {
            set
            {
                this._Password = value;
            }
            get
            {
                return this._Password;
            }
        }

        /// <summary>
        /// Gets or sets string value for FirstName
        /// </summary>
        [ColumnAttribute("FirstName", SqlDbType.NVarChar, 100, false)]
        public string FirstName
        {
            set
            {
                this._FirstName = value;
            }
            get
            {
                return this._FirstName;
            }
        }

        /// <summary>
        /// Gets or sets string value for LastName
        /// </summary>
        [ColumnAttribute("LastName", SqlDbType.NVarChar, 100, false)]
        public string LastName
        {
            set
            {
                this._LastName = value;
            }
            get
            {
                return this._LastName;
            }
        }

        /// <summary>
        /// Gets or sets string value for Organization
        /// </summary>
        [ColumnAttribute("Organization", SqlDbType.NVarChar, 200, false)]
        public string Organization
        {
            set
            {
                this._Organization = value;
            }
            get
            {
                return this._Organization;
            }
        }

        /// <summary>
        /// Gets or sets string value for Email
        /// </summary>
        [ColumnAttribute("Email", SqlDbType.NVarChar, 100, false)]
        public string Email
        {
            set
            {
                this._Email = value;
            }
            get
            {
                return this._Email;
            }
        }

        /// <summary>
        /// Gets or sets string value for Phone
        /// </summary>
        [ColumnAttribute("Phone", SqlDbType.NVarChar, 50, false)]
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
        /// Gets or sets string value for Description
        /// </summary>
        [ColumnAttribute("Description", SqlDbType.NVarChar, 4000, false)]
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
        /// Gets or sets DateTime? value for Date_Created
        /// </summary>
        [ColumnAttribute("Date_Created", SqlDbType.DateTime, 8, false)]
        public DateTime? Date_Created
        {
            set
            {
                this._Date_Created = value;
            }
            get
            {
                return this._Date_Created;
            }
        }

        /// <summary>
        /// Gets or sets DateTime? value for Date_Updated
        /// </summary>
        [ColumnAttribute("Date_Updated", SqlDbType.DateTime, 8, false)]
        public DateTime? Date_Updated
        {
            set
            {
                this._Date_Updated = value;
            }
            get
            {
                return this._Date_Updated;
            }
        }


        #endregion
    }
}
