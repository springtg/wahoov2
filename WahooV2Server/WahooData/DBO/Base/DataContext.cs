using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WahooData.Controller;

namespace WahooData.DBO.Base
{
    public class DataContext
    {
        private ClientController _clientController;
        /// <summary>
        /// Return ClientController
        /// </summary>
        public ClientController ClientController
        {
            get
            {
                if (_clientController == null)
                    _clientController = new ClientController();
                return _clientController;
            }
        }

        private ChannelController _channelController;
        /// <summary>
        /// Return ChannelController
        /// </summary>
        public ChannelController ChannelController
        {
            get
            {
                if (_channelController == null)
                    _channelController = new ChannelController();
                return _channelController;
            }
        }

        private DownloadReportController _downloadReportController;
        /// <summary>
        /// Return DownloadReportController
        /// </summary>
        public DownloadReportController DownloadReportController
        {
            get
            {
                if (_downloadReportController == null)
                    _downloadReportController = new DownloadReportController();
                return _downloadReportController;
            }
        }

        private HistoryOfChannelController _historyOfChannelController;
        /// <summary>
        /// Return HistoryOfChannelController
        /// </summary>
        public HistoryOfChannelController HistoryOfChannelController
        {
            get
            {
                if (_historyOfChannelController == null)
                    _historyOfChannelController = new HistoryOfChannelController();
                return _historyOfChannelController;
            }
        }

        private UserController _userController;
        /// <summary>
        /// Return UserController
        /// </summary>
        public UserController UserController
        {
            get
            {
                if (_userController == null)
                    _userController = new UserController();
                return _userController;
            }
        }


        /// <summary>
        /// Default constructor
        /// </summary>
        public DataContext()
        {
        }
    }
}
