using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WahooData.DBO;
using WahooData.Controller;

namespace WahooData.BusinessHandler
{
    public class WahooBusinessHandler
    {
        #region User
        /// <summary>
        /// Lay ra danh sach cac user
        /// </summary>
        /// <param name="_User">Thong tin ve user</param>
        /// <returns></returns>
        public static List<User> Get_ListUser(User _User)
        {
            UserController _UserController = new UserController();
            List<User> objUser = new List<User>();
            try
            {
                objUser = _UserController.GetItemsCollection(_User);
            }
            catch
            {
                objUser = new List<User>();
            }
            if (objUser == null)
            {
                objUser = new List<User>();
            }
            return objUser;
        }
        /// <summary>
        /// Lay ra user
        /// </summary>
        /// <param name="_User">Thong tin ve user</param>
        /// <returns></returns>
        public static User Get_User(User _User)
        {
            UserController _UserController = new UserController();
            User objUser = new User();
            try
            {
                objUser = _UserController.GetItem(_User);
            }
            catch
            {
                objUser = new User();
            }
            if (objUser == null)
            {
                objUser = new User();
            }
            return objUser;
        }
        /// <summary>
        /// Tao moi User
        /// </summary>
        /// <param name="_User">Thong tin ve User</param>
        /// <returns></returns>
        public static int Add_User(User _User)
        {
            int result = 0;
            if (_User == null)
            {
                _User = new User();
            }
            UserController _UserController = new UserController();
            try
            {
                result = _UserController.Add(_User);
            }
            catch
            {
                result = 0;
            }
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }

        #endregion User

        #region Channel
        /// <summary>
        /// Lay ra danh sach cac Channel
        /// </summary>
        /// <param name="_Channel">Thong tin ve Channel</param>
        /// <returns></returns>
        public static List<Channel> Get_ListChannel(Channel _Channel)
        {
            ChannelController _ChannelController = new ChannelController();
            List<Channel> objChannel = new List<Channel>();
            try
            {
                objChannel = _ChannelController.GetItemsCollection(_Channel);
            }
            catch
            {
                objChannel = new List<Channel>();
            }
            if (objChannel == null)
            {
                objChannel = new List<Channel>();
            }
            return objChannel;
        }
        /// <summary>
        /// Lay ra Channel
        /// </summary>
        /// <param name="_Channel">Thong tin ve Channel</param>
        /// <returns></returns>
        public static Channel Get_Channel(Channel _Channel)
        {
            ChannelController _ChannelController = new ChannelController();
            Channel objChannel = new Channel();
            try
            {
                objChannel = _ChannelController.GetItem(_Channel);
            }
            catch
            {
                objChannel = new Channel();
            }
            if (objChannel == null)
            {
                objChannel = new Channel();
            }
            return objChannel;
        }
        /// <summary>
        /// Tao moi Channel
        /// </summary>
        /// <param name="_Channel">Thong tin ve Channel</param>
        /// <returns></returns>
        public static int Add_Channel(Channel _Channel)
        {
            int result = 0;
            if (_Channel == null)
            {
                _Channel = new Channel();
            }
            ChannelController _ChannelController = new ChannelController();
            try
            {
                result = _ChannelController.Add(_Channel);
            }
            catch
            {
                result = 0;
            }
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Update all channel for status execute
        /// </summary>
        /// <param name="statusExecute"></param>
        /// <returns></returns>
        public static bool UpdateAllChannelStatusExecute(string statusExecute)
        {
            Boolean result = false;
            ChannelController _ChannelController = new ChannelController();
            try
            {
                result = _ChannelController.UpdateAllChannelStatusExecute(statusExecute);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// Update all channel for status execute
        /// </summary>
        /// <param name="statusExecute"></param>
        /// <returns></returns>
        public static bool UpdateAllChannelDeployed(Boolean isDeployed)
        {
            Boolean result = false;
            ChannelController _ChannelController = new ChannelController();
            try
            {
                result = _ChannelController.UpdateAllChannelDeployed(isDeployed);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        
        #endregion Channel

        #region Client
        /// <summary>
        /// Lay ra danh sach cac Client
        /// </summary>
        /// <param name="_Client">Thong tin ve Client</param>
        /// <returns></returns>
        public static List<Client> Get_ListClient(Client _Client)
        {
            ClientController _ClientController = new ClientController();
            List<Client> objClient = new List<Client>();
            try
            {
                objClient = _ClientController.GetItemsCollection(_Client);
            }
            catch
            {
                objClient = new List<Client>();
            }
            if (objClient == null)
            {
                objClient = new List<Client>();
            }
            return objClient;
        }
        /// <summary>
        /// Lay ra Client
        /// </summary>
        /// <param name="_Client">Thong tin ve Client</param>
        /// <returns></returns>
        public static Client Get_Client(Client _Client)
        {
            ClientController _ClientController = new ClientController();
            Client objClient = new Client();
            try
            {
                objClient = _ClientController.GetItem(_Client);
            }
            catch
            {
                objClient = new Client();
            }
            if (objClient == null)
            {
                objClient = new Client();
            }
            return objClient;
        }
        /// <summary>
        /// Tao moi Client
        /// </summary>
        /// <param name="_Client">Thong tin ve Client</param>
        /// <returns></returns>
        public static int Add_Client(Client _Client)
        {
            int result = 0;
            if (_Client == null)
            {
                _Client = new Client();
            }
            ClientController _ClientController = new ClientController();
            try
            {
                result = _ClientController.Add(_Client);
            }
            catch
            {
                result = 0;
            }
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }

        #endregion Client

        #region DownloadReport
        /// <summary>
        /// Lay ra danh sach cac DownloadReport
        /// </summary>
        /// <param name="_DownloadReport">Thong tin ve DownloadReport</param>
        /// <returns></returns>
        public static List<DownloadReport> Get_ListDownloadReport(DownloadReport _DownloadReport)
        {
            DownloadReportController _DownloadReportController = new DownloadReportController();
            List<DownloadReport> objDownloadReport = new List<DownloadReport>();
            try
            {
                objDownloadReport = _DownloadReportController.GetItemsCollection(_DownloadReport);
            }
            catch
            {
                objDownloadReport = new List<DownloadReport>();
            }
            if (objDownloadReport == null)
            {
                objDownloadReport = new List<DownloadReport>();
            }
            return objDownloadReport;
        }
        /// <summary>
        /// Lay ra danh sach cac DownloadReport co phan trang
        /// </summary>
        /// <param name="_DownloadReport">Thong tin ve DownloadReport</param>
        /// <param name="startIndex">lay tu vi tri nao</param>
        /// <param name="numOfRows">So record can lay</param>
        /// <returns></returns>
        public static List<DownloadReport> Get_ListDownloadReport(DownloadReport _DownloadReport,int startIndex, int numOfRows)
        {
            DownloadReportController _DownloadReportController = new DownloadReportController();
            List<DownloadReport> objDownloadReport = new List<DownloadReport>();
            try
            {
                objDownloadReport = _DownloadReportController.GetItemsCollection(_DownloadReport,startIndex,numOfRows);
            }
            catch
            {
                objDownloadReport = new List<DownloadReport>();
            }
            if (objDownloadReport == null)
            {
                objDownloadReport = new List<DownloadReport>();
            }
            return objDownloadReport;
        }

        /// <summary>
        /// Lay ra danh sach cac DownloadReport co phan trang
        /// </summary>
        /// <param name="_DownloadReport">Thong tin ve DownloadReport</param>
        /// <param name="startIndex">lay tu vi tri nao</param>
        /// <param name="numOfRows">So record can lay</param>
        /// <returns></returns>
        public static List<DownloadReport> Get_ListDownloadReport(WahooData.DBO.ConditionDR condition,ref int allrows)
        {
            DownloadReportController _DownloadReportController = new DownloadReportController();
            List<DownloadReport> objDownloadReport = new List<DownloadReport>();
            try
            {
                objDownloadReport = _DownloadReportController.GetItemsCollection(condition,ref allrows);
            }
            catch
            {
                objDownloadReport = new List<DownloadReport>();
            }
            if (objDownloadReport == null)
            {
                objDownloadReport = new List<DownloadReport>();
            }
            return objDownloadReport;
        }
        /// <summary>
        /// Lay ra danh sach cac DownloadReport
        /// </summary>
        /// <param name="_DownloadReport">Thong tin ve DownloadReport</param>
        /// <returns></returns>
        public static List<DownloadReport> Get_ListDownloadReport(List<DownloadReport> listReport, CMonitorCondition condition)
        {
            DownloadReportController _DownloadReportController = new DownloadReportController();
            List<DownloadReport> objDownloadReport = new List<DownloadReport>();
            try
            {
                objDownloadReport = _DownloadReportController.GetItemsCollection(listReport, condition);
            }
            catch
            {
                objDownloadReport = new List<DownloadReport>();
            }
            if (objDownloadReport == null)
            {
                objDownloadReport = new List<DownloadReport>();
            }
            return objDownloadReport;
        }
        /// <summary>
        /// Lay ra DownloadReport
        /// </summary>
        /// <param name="_DownloadReport">Thong tin ve DownloadReport</param>
        /// <returns></returns>
        public static DownloadReport Get_DownloadReport(DownloadReport _DownloadReport)
        {
            DownloadReportController _DownloadReportController = new DownloadReportController();
            DownloadReport objDownloadReport = new DownloadReport();
            try
            {
                objDownloadReport = _DownloadReportController.GetItem(_DownloadReport);
            }
            catch
            {
                objDownloadReport = new DownloadReport();
            }
            if (objDownloadReport == null)
            {
                objDownloadReport = new DownloadReport();
            }
            return objDownloadReport;
        }
        /// <summary>
        /// Tao moi DownloadReport
        /// </summary>
        /// <param name="_DownloadReport">Thong tin ve DownloadReport</param>
        /// <returns></returns>
        public static int Add_DownloadReport(DownloadReport _DownloadReport)
        {
            int result = 0;
            if (_DownloadReport == null)
            {
                _DownloadReport = new DownloadReport();
            }
            DownloadReportController _DownloadReportController = new DownloadReportController();
            try
            {
                result = _DownloadReportController.Add(_DownloadReport);
            }
            catch
            {
                result = 0;
            }
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }

        #endregion DownloadReport

        #region HistoryOfChannel
        /// <summary>
        /// Lay ra danh sach cac HistoryOfChannel
        /// </summary>
        /// <param name="_HistoryOfChannel">Thong tin ve HistoryOfChannel</param>
        /// <returns></returns>
        public static List<HistoryOfChannel> Get_ListHistoryOfChannel(HistoryOfChannel _HistoryOfChannel)
        {
            HistoryOfChannelController _HistoryOfChannelController = new HistoryOfChannelController();
            List<HistoryOfChannel> objHistoryOfChannel = new List<HistoryOfChannel>();
            try
            {
                objHistoryOfChannel = _HistoryOfChannelController.GetItemsCollection(_HistoryOfChannel);
            }
            catch
            {
                objHistoryOfChannel = new List<HistoryOfChannel>();
            }
            if (objHistoryOfChannel == null)
            {
                objHistoryOfChannel = new List<HistoryOfChannel>();
            }
            return objHistoryOfChannel;
        }
        /// <summary>
        /// Lay ra HistoryOfChannel
        /// </summary>
        /// <param name="_HistoryOfChannel">Thong tin ve HistoryOfChannel</param>
        /// <returns></returns>
        public static HistoryOfChannel Get_HistoryOfChannel(HistoryOfChannel _HistoryOfChannel)
        {
            HistoryOfChannelController _HistoryOfChannelController = new HistoryOfChannelController();
            HistoryOfChannel objHistoryOfChannel = new HistoryOfChannel();
            try
            {
                objHistoryOfChannel = _HistoryOfChannelController.GetItem(_HistoryOfChannel);
            }
            catch
            {
                objHistoryOfChannel = new HistoryOfChannel();
            }
            if (objHistoryOfChannel == null)
            {
                objHistoryOfChannel = new HistoryOfChannel();
            }
            return objHistoryOfChannel;
        }
        /// <summary>
        /// Tao moi HistoryOfChannel
        /// </summary>
        /// <param name="_HistoryOfChannel">Thong tin ve HistoryOfChannel</param>
        /// <returns></returns>
        public static int Add_HistoryOfChannel(HistoryOfChannel _HistoryOfChannel)
        {
            int result = 0;
            if (_HistoryOfChannel == null)
            {
                _HistoryOfChannel = new HistoryOfChannel();
            }
            HistoryOfChannelController _HistoryOfChannelController = new HistoryOfChannelController();
            try
            {
                result = _HistoryOfChannelController.Add(_HistoryOfChannel);
            }
            catch
            {
                result = 0;
            }
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Delete HistoryChannel of Channel
        /// </summary>
        /// <param name="isDeployed"></param>
        /// <returns></returns>
        public static bool DeleteHistoryOfChannel(int idChannel)
        {
            Boolean result = false;
            HistoryOfChannelController _ChannelController = new HistoryOfChannelController();
            try
            {
                result = _ChannelController.DeleteHistoryOfChannel(idChannel);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        #endregion HistoryOfChannel
    }
}
