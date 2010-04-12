using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WahooData.DBO.Base
{
    public class BaseDao
    {

        #region Private Members
        //Database connection string
        private string _conectionString;
        private string _userId;
        private string _ipAddress;
        #endregion

        #region Database Object

        private SqlDataAdapter _dbAdapter;
        private SqlConnection _dbConnection;
        private SqlCommand _dbCommand;
        private SqlTransaction _dbTransaction;

        #endregion

        #region public properties

        //Param Prefix
        public static string ParamPrefix = "@";

        /// <summary>
        /// Get Adapter 
        /// </summary>
        public SqlDataAdapter DbAdapter
        {
            get
            {
                //1. Open connection if current state<>Open
                if (this._dbConnection.State != ConnectionState.Open)
                {
                    this._dbConnection.Open();
                }
                //2.Return SqlAdapter
                return this._dbAdapter;
            }
        }

        /// <summary>
        /// Get Common Command
        /// </summary>
        public SqlCommand DbCommand
        {
            get
            {
                //1. Open connection if current state<>Open
                if (this._dbConnection.State != ConnectionState.Open)
                {
                    this._dbConnection.Open();
                }
                //2.Return SqlCommand
                return this._dbCommand;
            }
        }

        #endregion

       

        #region Constructor

        public BaseDao()
        {
        }

        /// <summary>
        /// Constructor of DAO Base Class
        /// </summary>
        /// <param name="connectionString">Database Connection string</param>
        /// <param name="action">Database interaction type</param>
        public BaseDao(string connectionString)
        {
            //1.Assign Connection string
            this._conectionString = connectionString;
            //2.Create database connection
            this._dbConnection = new SqlConnection(this._conectionString);
            //3.Create data adapter
            this._dbAdapter = new SqlDataAdapter();
            //4.Create insert command
            this._dbAdapter.InsertCommand = new SqlCommand();
            this._dbAdapter.InsertCommand.Connection = this._dbConnection;
            //5.Create update command
            this._dbAdapter.UpdateCommand = new SqlCommand();
            this._dbAdapter.UpdateCommand.Connection = this._dbConnection;
            //6.Create delete command
            this._dbAdapter.DeleteCommand = new SqlCommand();
            this._dbAdapter.DeleteCommand.Connection = this._dbConnection;
            //7.Create select command
            this._dbAdapter.SelectCommand = new SqlCommand();
            this._dbAdapter.SelectCommand.Connection = this._dbConnection;
            //8.Create common command
            this._dbCommand = new SqlCommand();
            this._dbCommand.Connection = this._dbConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="userId"></param>
        /// <param name="ipAddress"></param>
        public BaseDao(string connectionString, string userId, string ipAddress)
        {
            //1.Assign Connection string and log info
            this._conectionString = connectionString;
            this._userId = userId;
            this._ipAddress = ipAddress;
            //2.Create database connection
            this._dbConnection = new SqlConnection(this._conectionString);
            //3.Create data adapter
            this._dbAdapter = new SqlDataAdapter();
            //4.Create insert command
            this._dbAdapter.InsertCommand = new SqlCommand();
            this._dbAdapter.InsertCommand.Connection = this._dbConnection;
            //5.Create update command
            this._dbAdapter.UpdateCommand = new SqlCommand();
            this._dbAdapter.UpdateCommand.Connection = this._dbConnection;
            //6.Create delete command
            this._dbAdapter.DeleteCommand = new SqlCommand();
            this._dbAdapter.DeleteCommand.Connection = this._dbConnection;
            //7.Create select command
            this._dbAdapter.SelectCommand = new SqlCommand();
            this._dbAdapter.SelectCommand.Connection = this._dbConnection;
            //8.Create common command
            this._dbCommand = new SqlCommand();
            this._dbCommand.Connection = this._dbConnection;
        }

        #endregion

        /// <summary>
        /// Start Transaction
        /// </summary>
        /// <returns></returns>
        protected void BeginTransaction()
        {
            if (this._dbConnection.State != ConnectionState.Open)
            {
                this._dbConnection.Open();
            }
            this._dbTransaction = this._dbConnection.BeginTransaction();
            this._dbAdapter.InsertCommand.Transaction = this._dbTransaction;
            this._dbAdapter.DeleteCommand.Transaction = this._dbTransaction;
            this._dbAdapter.UpdateCommand.Transaction = this._dbTransaction;
        }


        protected void AssignTransaction(SqlCommand command)
        {
            if (this._dbConnection.State != ConnectionState.Open)
            {
                this._dbConnection.Open();
            }
            command.Transaction = this._dbTransaction;
        }

        /// <summary>
        /// Begin transaction for command or adapter
        /// </summary>
        /// <param name="is4Command"></param>
        protected void BeginTransaction(bool is4Command)
        {
            //1.Open connection
            if (this._dbConnection.State != ConnectionState.Open)
            {
                this._dbConnection.Open();
            }
            //2.Checking option
            if (is4Command)
            {
                //2.1. Begin transaction for command
                this._dbTransaction = this._dbConnection.BeginTransaction();
                this._dbCommand.Transaction = this._dbTransaction;
            }
            else
            {
                //2.2. Begin transaction for adapter
                this._dbTransaction = this._dbConnection.BeginTransaction();
                this._dbAdapter.InsertCommand.Transaction = this._dbTransaction;
                this._dbAdapter.DeleteCommand.Transaction = this._dbTransaction;
                this._dbAdapter.UpdateCommand.Transaction = this._dbTransaction;
            }
        }

        /// <summary>
        /// Commit if succeed
        /// </summary>
        /// <returns></returns>
        protected void CommitTransaction()
        {
            this._dbTransaction.Commit();
            this._dbConnection.Close();
        }

        /// <summary>
        /// Rollback if fail
        /// </summary>
        /// <returns></returns>
        protected void RollbackTransaction()
        {
            this._dbTransaction.Rollback();
            this._dbConnection.Close();
        }

        /// <summary>
        /// Release DAO resource
        /// </summary>
        public void Dispose()
        {
            //1.Dispose connection
            if (this._dbConnection != null)
            {
                if (this._dbConnection.State != System.Data.ConnectionState.Closed)
                {
                    this._dbConnection.Close();
                    this._dbConnection.Dispose();
                }
            }
            //2.Dispose transaction
            if (this._dbTransaction != null)
            {
                this._dbTransaction.Dispose();
            }
            //3.Dispose common command
            if (this._dbCommand != null)
            {
                this._dbCommand.Dispose();
            }
            //4.Dispose adapter
            if (this._dbAdapter != null)
            {
                this._dbAdapter.Dispose();
            }
        }
    }
}
