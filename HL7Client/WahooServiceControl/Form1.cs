using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using WahooServiceControl.ControlEx;
using Microsoft.Win32;
using System.Diagnostics;

namespace WahooServiceControl
{
    public partial class Form1 : Form
    {
        private string _mServiceName = "HL7ClientService";
        private string _mRegistryPath = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\HL7ClientService";
        private string _mHL7ClientApp = "HL7Client";
        private string _mHL7ClientAppPath = Application.StartupPath + @"\HL7Client.exe";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            System.ServiceProcess.ServiceController controller = new ServiceController(_mServiceName);
            controller.Start();
            WaitForStatus(controller, ServiceControllerStatus.Running, new TimeSpan(0, 1, 0));
            UpdateControls(controller);
        }
        private void WaitForStatus(ServiceController controller, ServiceControllerStatus status, TimeSpan timeOut)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = false;
            controller.WaitForStatus(status, timeOut);
            btnStop.Enabled = (controller.Status == status && controller.CanStop == true);
            btnStart.Enabled = controller.Status == status;
        }
        private void UpdateControls(ServiceController controller)
        {
            btnStop.Enabled = (controller.Status == ServiceControllerStatus.Running && controller.CanStop == true);
            btnStart.Enabled = controller.Status == ServiceControllerStatus.Stopped;
            statusBar1.Text = "Status: " + controller.Status.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            System.ServiceProcess.ServiceController controller = new ServiceController(_mServiceName);
            controller.Stop();
            WaitForStatus(controller, ServiceControllerStatus.Stopped, new TimeSpan(0, 1, 0));
            UpdateControls(controller);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceControllerEx controller = new ServiceControllerEx(_mServiceName);
                controller.StartupType = "Disabled";
                statusBar1.Text = "Status: Disabled";
                btnInstall.Enabled = true;
                btnStop.Enabled = false;
                btnStart.Enabled = false;
                btnUninstall.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceControllerEx controller = new ServiceControllerEx(_mServiceName);
                controller.StartupType = "Automatic";
                if (controller.Status == ServiceControllerStatus.Stopped)
                {
                    statusBar1.Text = "Status: Stoped";
                    btnStop.Enabled = false;
                    btnStart.Enabled = true;
                }
                else if (controller.Status == ServiceControllerStatus.Running)
                {
                    statusBar1.Text = "Status: Started";
                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
                }
                else
                {

                }
                btnInstall.Enabled = false;
                btnUninstall.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.ServiceProcess.ServiceController controller = new ServiceController(_mServiceName);
            string valueName = "Start";
            if (int.Parse(Registry.GetValue(this._mRegistryPath, valueName, 0).ToString()) == 2)
            {
                if (controller.Status == ServiceControllerStatus.Stopped)
                {
                    statusBar1.Text = "Status: Stoped";
                    btnStop.Enabled = false;
                    btnStart.Enabled = true;
                }
                else if (controller.Status == ServiceControllerStatus.Running)
                {
                    statusBar1.Text = "Status: Started";
                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
                }
                else
                {

                }
                btnInstall.Enabled = false;
                btnUninstall.Enabled = true;
            }
            else if (int.Parse(Registry.GetValue(this._mRegistryPath, valueName, 0).ToString()) == 4)
            {
                btnInstall.Enabled = true;
                btnStop.Enabled = false;
                btnStart.Enabled = false;
                btnUninstall.Enabled = false;
                statusBar1.Text = "Status: Disabled";
            }
            else
            {

            }
        }

        private void btnEngine_Click(object sender, EventArgs e)
        {
            try
            {
                string valueName = "Start";
                if (int.Parse(Registry.GetValue(this._mRegistryPath, valueName, 0).ToString()) != 4)
                {
                    Registry.SetValue(this._mRegistryPath, valueName, 4);
                }
                Process[] arrP = Process.GetProcessesByName(this._mHL7ClientApp);
                foreach (Process p in arrP)
                {
                    p.Kill();
                }
                Process proc = Process.Start(this._mHL7ClientAppPath);
                proc.Close();
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}