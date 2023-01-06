using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;

namespace FiltersAndVMDDemo
{
    public partial class MainFrm : Form
    {
        #region Main
        public MainFrm()
        {
            InitializeComponent();
            Initialize();
            Init();
        }
        #endregion

        #region Template
        #region Initialize
        //Initialize.
        private void Initialize()
        {
            this.Text = GetAssemblyInfo.AssemblyTitle;
            this.Icon = global::FiltersAndVMDDemo.Properties.Resources.program_icon;
            trayNotifyIcon.Icon = global::FiltersAndVMDDemo.Properties.Resources.program_icon;
            //Load Settings from Registry.
            this.Location = Settings.Location;
            this.Size = Settings.Size;
            this.Visible = Settings.Visible;
            this.TopMost = Settings.AlwaysOnTop;
            //Apply these settings.
            SetVisible();
            SetAlwaysOnTop();
            SetRunAtStartup();
        }
        #endregion

        #region Menu Events
        //When clicked on Hide or Show.
        private void hideOrShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeVisible();
        }
        //When clicked on Run At Startup.
        private void runAtStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRunAtStartup();
        }
        //When clicked on Always On Top.
        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAlwaysOnTop();
        }
        private void ExitProg()
        {
            if (mDevice != null)
            {
                mDevice.StopServer();
            }
            DeInit();
            Application.Exit();
        }
        //When clicked on Help Topics.
        private void helpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(CommonPathes.ProgramFilesPath + "\\FiltersAndVMDDemoHelp.pdf");
        }
        //When clicked on Visit Website.
        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.soft-collection.com");
        }
        //When clicked on About.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.TopMost = true;
            about.ShowDialog();
        }
        private void importVideoFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openVideoFileDialog.Title = "Open Video File";
                string VideoFormat = "Video files |*.avi; *.mkv; *.mov; *.mp4; *.mpg; *.wmv";
                openVideoFileDialog.Filter = VideoFormat;
                openVideoFileDialog.AddExtension = true;
                openVideoFileDialog.CheckFileExists = false;
                DialogResult dialogResult = openVideoFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    //ffmpeg -i 20170703_181518_R.mp4 -s 640x480 -an -vcodec libx264 -crf 23 20170703_181518_R_Small.h264
                    string inFile = openVideoFileDialog.FileName;
                    string outFile = Application.StartupPath + @"\" + Path.GetFileNameWithoutExtension(openVideoFileDialog.FileName) + ".264";
                    StartApp("ffmpeg.exe", "-i \"" + inFile + "\" -s 640x480 -an -vcodec libx264 -crf 23 \"" + outFile + "\"");
                }
            }
            catch { }
        }
        //When clicked on Exit.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitProg();
        }
        private void trayNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) ChangeVisible();
        }
        #endregion

        #region Set Settings and Update Menu Items
        //Changes Visible state.
        private void ChangeVisible()
        {
            this.Visible = !this.Visible;
            SetVisible();
        }
        //Apply current Visible value.
        private void SetVisible()
        {
            Settings.Visible = this.Visible;
            if (this.Visible)
            {
                hideOrShowToolStripMenuItem.Text = "Hide";
                trayNotifyIcon.Text = "Hide " + GetAssemblyInfo.AssemblyProduct;

                this.Opacity = 1;
            }
            else
            {
                hideOrShowToolStripMenuItem.Text = "Show";
                trayNotifyIcon.Text = "Show " + GetAssemblyInfo.AssemblyProduct;
                this.Opacity = 0;

            }
        }
        //Changes Run At Startup state.
        private void ChangeRunAtStartup()
        {
            runAtStartupToolStripMenuItem.Checked = !runAtStartupToolStripMenuItem.Checked;
            Settings.RunAtStartup = runAtStartupToolStripMenuItem.Checked;
        }
        //Apply current Run At Startup value.
        private void SetRunAtStartup()
        {
            runAtStartupToolStripMenuItem.Checked = Settings.RunAtStartup;
        }
        //Changes Always On Top state.
        private void ChangeAlwaysOnTop()
        {
            this.TopMost = !this.TopMost;
            SetAlwaysOnTop();
        }
        //Apply current Always On Top value.
        private void SetAlwaysOnTop()
        {
            Settings.AlwaysOnTop = this.TopMost;
            alwaysOnTopToolStripMenuItem.Checked = this.TopMost;
        }
        #endregion

        #region Main Form Events
        private void MainFrm_Move(object sender, EventArgs e)
        {
            Settings.Location = this.Location;
        }
        private void MainFrm_Resize(object sender, EventArgs e)
        {
            Settings.Size = this.Size;
        }
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitProg();
        }
        #endregion

        #region WinProc
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE)
                    {
                        try
                        {
                            ChangeVisible();
                            return;
                        }
                        catch
                        {
                        }
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion
        #endregion

        #region FiltersAndVMDDemo

        #region Enums
        public enum eGUIStates
        {
            NotSetYet = 0,
            SourceTypeRTSPCameraSelected = 1,
            SourceTypeWebCameraSelected = 2,
            SourceTypeSimulatorSelected = 3,
            SourceTypeVideoFileSelected = 4,
            URLSelected = 5,
            NotConnected = 6,
            Connecting = 7,
            Connected = 8,
            UnableToConnect = 9,
        }
        #endregion

        #region Variables
        private clsDevice mDevice = null;
        private Common.eConnectionStates mConnectionState = Common.eConnectionStates.NotSetYet;
        private Common.eConnectionStates mLastConnectionState = Common.eConnectionStates.NotConnected; //Must be different from mConnectionState.
        private eGUIStates mGUIState = eGUIStates.NotSetYet;
        private eGUIStates mLastGUIState = eGUIStates.NotConnected; //Must be different from mGUIState.
        #endregion

        #region Initialize
        private void Init()
        {
            mDevice = new clsDevice();
            //----------------------------------------------------------------------------------------------
            caCalibration.SetDevice(mDevice);
            mDevice.Set_Draw_Windows_TargetWindow(caCalibration.CalibrationWindowHandle);
            UpdateControls();
            //----------------------------------------------------------------------------------------------
            timer.Start();
            //----------------------------------------------------------------------------------------------
        }
        private void DeInit()
        {
            if (mDevice != null)
            {
                mDevice.Dispose();
            }
        }
        #endregion

        #region Main Form Events
        private void tscbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tscbSource.SelectedIndex)
            {
                case 0: //RTSP Camera.
                    {
                        tscbURL.Items.Clear();
                        List<string> tempList = new List<string>();
                        if (!Directory.Exists(CommonPathes.ProgramDataPath))
                        {
                            Directory.CreateDirectory(CommonPathes.ProgramDataPath);
                        }
                        if (!File.Exists(CommonPathes.ProgramDataPath + @"\IPCameras.lst"))
                        {
                            FileStream fs = File.Create(CommonPathes.ProgramDataPath + @"\IPCameras.lst");
                            fs.Close();
                        }
                        using (StreamReader sr = new StreamReader(CommonPathes.ProgramDataPath + @"\IPCameras.lst"))
                        {
                            while (sr.Peek() >= 0)
                            {
                                string tempString = sr.ReadLine();
                                if (!string.IsNullOrEmpty(tempString))
                                {
                                    tscbURL.Items.Add(tempString);
                                }
                            }
                            sr.Close();
                        }
                        mGUIState = eGUIStates.SourceTypeRTSPCameraSelected;
                    }
                    break;
                case 1: //Web Camera.
                    {
                        tscbURL.Items.Clear();
                        tscbURL.Items.Add("0");
                        tscbURL.Items.Add("1");
                        tscbURL.Items.Add("2");
                        mGUIState = eGUIStates.SourceTypeWebCameraSelected;
                    }
                    break;
                case 2: //Simulator.
                    {
                        tscbURL.Items.Clear();
                        string[] fileEntries = Directory.GetFiles(CommonPathes.ProgramFilesPath);
                        foreach (string fileName in fileEntries)
                        {
                            if ((Path.GetExtension(fileName) == ".264") ||
                                (Path.GetExtension(fileName) == ".mp4") ||
                                (Path.GetExtension(fileName) == ".mpg") ||
                                (Path.GetExtension(fileName) == ".avi"))
                            {
                                tscbURL.Items.Add(@"rtsp://127.0.0.1/" + Path.GetFileName(fileName));
                            }
                        }
                        mGUIState = eGUIStates.SourceTypeSimulatorSelected;
                    }
                    break;
                case 3: //Video File.
                    {
                        tscbURL.Items.Clear();
                        if (!string.IsNullOrEmpty(openVideoFileDialog.FileName))
                        {
                            tscbURL.Items.Add(openVideoFileDialog.FileName);
                        }
                        mGUIState = eGUIStates.SourceTypeVideoFileSelected;
                    }
                    break;
            }
        }
        private void tscbURL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mDevice != null)
            {
                bool isWebCam = false;
                if (tscbSource.SelectedIndex == 1) isWebCam = true;
                mDevice.Set_Connection_URL((string)tscbURL.SelectedItem, isWebCam);
                mGUIState = eGUIStates.URLSelected;
            }
        }
        private void tsbOpenVideoFile_Click(object sender, EventArgs e)
        {
            try
            {
                openVideoFileDialog.Title = "Open Video File";
                string VideoFormat = "Video files |*.avi; *.mkv; *.mov; *.mp4; *.mpg; *.wmv";
                openVideoFileDialog.Filter = VideoFormat;
                openVideoFileDialog.AddExtension = true;
                openVideoFileDialog.CheckFileExists = false;
                DialogResult dialogResult = openVideoFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    tscbURL.Items.Clear();
                    tscbURL.Items.Add(openVideoFileDialog.FileName);
                    tscbURL.SelectedIndex = 0;
                }
            }
            catch { }
        }
        private void tsbEditCameraList_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(CommonPathes.ProgramDataPath))
            {
                Directory.CreateDirectory(CommonPathes.ProgramDataPath);
            }
            if (!File.Exists(CommonPathes.ProgramDataPath + @"\IPCameras.lst"))
            {
                FileStream fs = File.Create(CommonPathes.ProgramDataPath + @"\IPCameras.lst");
                fs.Close();
            }
            StartApp("Notepad", CommonPathes.ProgramDataPath + @"\IPCameras.lst");
            mGUIState = eGUIStates.NotSetYet;
        }
        private void tsbConnectDisconnect_Click(object sender, EventArgs e)
        {
            switch (mGUIState)
            {
                case eGUIStates.NotSetYet:
                    //Button is Disabled.
                    break;
                case eGUIStates.SourceTypeRTSPCameraSelected:
                    //Button is Disabled.
                    break;
                case eGUIStates.SourceTypeWebCameraSelected:
                    //Button is Disabled.
                    break;
                case eGUIStates.SourceTypeSimulatorSelected:
                    //Button is Disabled.
                    break;
                case eGUIStates.SourceTypeVideoFileSelected:
                    //Button is Disabled.
                    break;
                case eGUIStates.URLSelected:
                    if (mDevice != null)
                    {
                        if (tscbSource.SelectedIndex == 2) //Simulator.
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.ConnectStartServer);
                        }
                        else
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.Connect);
                        }
                    }
                    break;
                case eGUIStates.NotConnected:
                    if (mDevice != null)
                    {
                        if (tscbSource.SelectedIndex == 2) //Simulator.
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.ConnectStartServer);
                        }
                        else
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.Connect);
                        }
                    }
                    break;
                case eGUIStates.Connecting:
                    //Button is Disabled.
                    break;
                case eGUIStates.Connected:
                    if (mDevice != null)
                    {
                        if (tscbSource.SelectedIndex == 2) //Simulator.
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.DisconnectStopServer);
                        }
                        else
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.Disconnect);
                        }
                    }
                    break;
                case eGUIStates.UnableToConnect:
                    if (mDevice != null)
                    {
                        if (tscbSource.SelectedIndex == 2) //Simulator.
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.ConnectStartServer);
                        }
                        else
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.Connect);
                        }
                    }
                    break;
            }
        }
        private void tsbOpenVideoFile_MouseEnter(object sender, EventArgs e)
        {
            toolStrip.Focus();
        }
        private void tsbEditCameraList_MouseEnter(object sender, EventArgs e)
        {
            toolStrip.Focus();
        }
        private void tsbConnectDisconnect_MouseEnter(object sender, EventArgs e)
        {
            toolStrip.Focus();
        }
        private void tsbSettings_MouseEnter(object sender, EventArgs e)
        {
            toolStrip.Focus();
        }
        private void tbAverageBufferSizeInFrames_Scroll(object sender, EventArgs e)
        {
            txtAverageBufferSizeInFrames.Text = tbAverageBufferSizeInFrames.Value.ToString();
            if (mDevice != null)
            {
                mDevice.VMD_AverageBufferSizeInFrames = tbAverageBufferSizeInFrames.Value;
            }
        }
        private void tbResizeSquare_Scroll(object sender, EventArgs e)
        {
            txtResizeSquare.Text = tbResizeSquare.Value.ToString();
            if (mDevice != null)
            {
                mDevice.VMD_ResizeSquare = tbResizeSquare.Value;
            }
        }
        private void tbTolerance_Scroll(object sender, EventArgs e)
        {
            txtTolerance.Text = tbTolerance.Value.ToString();
            if (mDevice != null)
            {
                mDevice.VMD_Tolerance = tbTolerance.Value;
            }
        }
        private void tbMedianSquare_Scroll(object sender, EventArgs e)
        {
            txtMedianSquare.Text = tbMedianSquare.Value.ToString();
            if (mDevice != null)
            {
                mDevice.VMD_MedianSquare = tbMedianSquare.Value;
            }
        }
        private void tbMinimalDistanceBetweenTwoObjects_Scroll(object sender, EventArgs e)
        {
            txtMinimalDistanceBetweenTwoObjects.Text = tbMinimalDistanceBetweenTwoObjects.Value.ToString();
            if (mDevice != null)
            {
                mDevice.VMD_MinimalDistanceBetweenTwoObjects = tbMinimalDistanceBetweenTwoObjects.Value;
            }
        }
        private void tbMaximalAmountOfObjectsToFind_Scroll(object sender, EventArgs e)
        {
            txtMaximalAmountOfObjectsToFind.Text = tbMaximalAmountOfObjectsToFind.Value.ToString();
            if (mDevice != null)
            {
                mDevice.VMD_MaximalAmountOfObjectsToFind = tbMaximalAmountOfObjectsToFind.Value;
            }
        }
        private void chbShowAcceptedObjects_CheckedChanged(object sender, EventArgs e)
        {
            if (mDevice != null)
            {
                mDevice.Draw_ShowAcceptedObjects = chbShowAcceptedObjects.Checked;
            }
        }
        private void chbShowAcceptedObjectsLimitSquares_CheckedChanged(object sender, EventArgs e)
        {
            if (mDevice != null)
            {
                mDevice.Draw_ShowAcceptedObjectsLimitSquares = chbShowAcceptedObjectsLimitSquares.Checked;
            }
        }
        private void cbWhatToShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mDevice != null)
            {
                if ((clsDeviceWrap.eWhatToShowTypes)cbWhatToShowType.SelectedIndex == (clsDeviceWrap.eWhatToShowTypes.ShowFilterFrame - 1))
                {
                    cbFilter.Enabled = true;
                    cbFilter.SelectedIndex = (int)mDevice.VMD_FilterType;
                }
                else
                {
                    cbFilter.SelectedIndex = (-1);
                    cbFilter.Enabled = false;
                }
                mDevice.VMD_WhatToShowType = (clsDeviceWrap.eWhatToShowTypes)cbWhatToShowType.SelectedIndex + 1;
            }
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mDevice != null)
            {
                if (cbFilter.SelectedIndex != (-1))
                {
                    mDevice.VMD_FilterType = (clsDeviceWrap.eFilterTypes)cbFilter.SelectedIndex;
                }
            }
        }
        private void bDefaults_Click(object sender, EventArgs e)
        {
            ApplyDefaults();
            UpdateControls();
        }
        private void caCalibration_OnDoubleSquareDataChanged(clsGraphicsDoubleSquare.DoubleSquareData doubleSquareData)
        {
            txtMinimalVMDObject.Text = (doubleSquareData.InnerDiagonal * Math.Sqrt(2)).ToString("F3");
            txtMaximalVMDObject.Text = (doubleSquareData.OuterDiagonal * Math.Sqrt(2)).ToString("F3");
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (mDevice != null)
            {
                mConnectionState = mDevice.GetConnectionState();
            }
            //------------------------------------------------------------
            if (mLastConnectionState != mConnectionState)
            {
                OnConnectionStateChanged(mConnectionState);
                mLastConnectionState = mConnectionState;
            }
            //------------------------------------------------------------
            if (mLastGUIState != mGUIState)
            {
                OnGUIStateChanged(mGUIState);
                mLastGUIState = mGUIState;
            }
            //------------------------------------------------------------
            caCalibration.OnTimer();
        }
        #endregion

        #region Methods
        private void OnConnectionStateChanged(Common.eConnectionStates connectionState)
        {
            switch (connectionState)
            {
                case Common.eConnectionStates.NotSetYet:
                    mGUIState = eGUIStates.NotSetYet;
                    break;
                case Common.eConnectionStates.NotConnected:
                    mGUIState = eGUIStates.NotConnected;
                    break;
                case Common.eConnectionStates.Connecting:
                    mGUIState = eGUIStates.Connecting;
                    break;
                case Common.eConnectionStates.Connected:
                    mGUIState = eGUIStates.Connected;
                    break;
                case Common.eConnectionStates.UnableToConnect:
                    mGUIState = eGUIStates.UnableToConnect;
                    break;
            }
        }
        private void OnGUIStateChanged(eGUIStates guiState)
        {
            switch (guiState)
            {
                case eGUIStates.NotConnected:
                    //Stop Server after simulator ends.
                    if (mDevice != null)
                    {
                        if (tscbSource.SelectedIndex == 2) //Simulator.
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.DisconnectStopServer);
                        }
                        else
                        {
                            mDevice.EnqueueCommand(clsDevice.DeviceCommand.eCommandTypes.Disconnect);
                        }
                    }
                    break;
            }
            SetGUIState(guiState);
        }
        private void SetGUIState(eGUIStates guiState)
        {
            switch (guiState)
            {
                case eGUIStates.NotSetYet:
                    tscbSource.Enabled = true;
                    tscbSource.SelectedIndex = (-1);
                    tscbURL.Enabled = false;
                    tscbURL.SelectedIndex = (-1);
                    tsbOpenVideoFile.Enabled = false;
                    tsbEditCameraList.Enabled = false;
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connect";
                    tsbConnectDisconnect.Enabled = false;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.gray;
                    tsbStatus.Text = "Not Connected";
                    break;
                case eGUIStates.SourceTypeRTSPCameraSelected:
                    tscbSource.Enabled = true;
                    tscbURL.Enabled = true;
                    tscbURL.SelectedIndex = (-1);
                    tsbOpenVideoFile.Enabled = false;
                    tsbEditCameraList.Enabled = true;
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connect";
                    tsbConnectDisconnect.Enabled = false;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.gray;
                    tsbStatus.Text = "Not Connected";
                    break;
                case eGUIStates.SourceTypeWebCameraSelected:
                    tscbSource.Enabled = true;
                    tscbURL.Enabled = true;
                    tscbURL.SelectedIndex = (-1);
                    tsbOpenVideoFile.Enabled = false;
                    tsbEditCameraList.Enabled = false;
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connect";
                    tsbConnectDisconnect.Enabled = false;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.gray;
                    tsbStatus.Text = "Not Connected";
                    break;
                case eGUIStates.SourceTypeSimulatorSelected:
                    tscbSource.Enabled = true;
                    tscbURL.Enabled = true;
                    tscbURL.SelectedIndex = (-1);
                    tsbOpenVideoFile.Enabled = false;
                    tsbEditCameraList.Enabled = false;
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connect";
                    tsbConnectDisconnect.Enabled = false;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.gray;
                    tsbStatus.Text = "Not Connected";
                    break;
                case eGUIStates.SourceTypeVideoFileSelected:
                    tscbSource.Enabled = true;
                    tscbURL.Enabled = true;
                    tscbURL.SelectedIndex = (-1);
                    tsbOpenVideoFile.Enabled = true;
                    tsbEditCameraList.Enabled = false;
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connect";
                    tsbConnectDisconnect.Enabled = false;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.gray;
                    tsbStatus.Text = "Not Connected";
                    break;
                case eGUIStates.URLSelected:
                    tscbSource.Enabled = true;
                    tscbURL.Enabled = true;
                    tsbOpenVideoFile.Enabled = (tscbSource.SelectedIndex == 3); //Video File.
                    tsbEditCameraList.Enabled = (tscbSource.SelectedIndex == 0); //RTSP Camera.
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connect";
                    tsbConnectDisconnect.Enabled = true;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.gray;
                    tsbStatus.Text = "Not Connected";
                    break;
                case eGUIStates.NotConnected:
                    tscbSource.Enabled = true;
                    tscbURL.Enabled = true;
                    tsbOpenVideoFile.Enabled = (tscbSource.SelectedIndex == 3); //Video File.
                    tsbEditCameraList.Enabled = (tscbSource.SelectedIndex == 0); //RTSP Camera.
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connect";
                    tsbConnectDisconnect.Enabled = true;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.gray;
                    tsbStatus.Text = "Not Connected";
                    break;
                case eGUIStates.Connecting:
                    tscbSource.Enabled = true;
                    tscbURL.Enabled = true;
                    tsbOpenVideoFile.Enabled = (tscbSource.SelectedIndex == 3); //Video File.
                    tsbEditCameraList.Enabled = (tscbSource.SelectedIndex == 0); //RTSP Camera.
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connecting";
                    tsbConnectDisconnect.Enabled = false;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.blue;
                    tsbStatus.Text = "Connecting";
                    break;
                case eGUIStates.Connected:
                    tscbSource.Enabled = false;
                    tscbURL.Enabled = false;
                    tsbOpenVideoFile.Enabled = false;
                    tsbEditCameraList.Enabled = false;
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.stop;
                    tsbConnectDisconnect.Text = "Disconnect";
                    tsbConnectDisconnect.Enabled = true;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.green;
                    tsbStatus.Text = "Connected";
                    break;
                case eGUIStates.UnableToConnect:
                    tscbSource.Enabled = true;
                    tscbURL.Enabled = true;
                    tsbOpenVideoFile.Enabled = (tscbSource.SelectedIndex == 3); //Video File.
                    tsbEditCameraList.Enabled = (tscbSource.SelectedIndex == 0); //RTSP Camera.
                    tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
                    tsbConnectDisconnect.Text = "Connect";
                    tsbConnectDisconnect.Enabled = true;
                    tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.red;
                    tsbStatus.Text = "Unable To Connect";
                    break;
            }
        }
        public static void StartApp(string fileName, string parameters)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = parameters;
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(fileName);
            process.Start();
        }
        private void UpdateControls()
        {
            caCalibration.UpdateControls();
            if (mDevice != null)
            {
                tbAverageBufferSizeInFrames.Value = mDevice.VMD_AverageBufferSizeInFrames;
                tbResizeSquare.Value = mDevice.VMD_ResizeSquare;
                tbTolerance.Value = mDevice.VMD_Tolerance;
                tbMedianSquare.Value = mDevice.VMD_MedianSquare;
                tbMinimalDistanceBetweenTwoObjects.Value = mDevice.VMD_MinimalDistanceBetweenTwoObjects;
                tbMaximalAmountOfObjectsToFind.Value = mDevice.VMD_MaximalAmountOfObjectsToFind;
                cbWhatToShowType.SelectedIndex = (int)mDevice.VMD_WhatToShowType - 1;
                txtMinimalVMDObject.Text = (mDevice.Draw_DoubleSquare_InnerSquareDiagonal * Math.Sqrt(2)).ToString("F3");
                txtMaximalVMDObject.Text = (mDevice.Draw_DoubleSquare_OuterSquareDiagonal * Math.Sqrt(2)).ToString("F3");
                chbShowAcceptedObjects.Checked = mDevice.Draw_ShowAcceptedObjects;
                chbShowAcceptedObjectsLimitSquares.Checked = mDevice.Draw_ShowAcceptedObjectsLimitSquares;
                //----------------------------------------------------------------------------------------------
                txtAverageBufferSizeInFrames.Text = tbAverageBufferSizeInFrames.Value.ToString();
                txtResizeSquare.Text = tbResizeSquare.Value.ToString();
                txtTolerance.Text = tbTolerance.Value.ToString();
                txtMedianSquare.Text = tbMedianSquare.Value.ToString();
                txtMinimalDistanceBetweenTwoObjects.Text = tbMinimalDistanceBetweenTwoObjects.Value.ToString();
                txtMaximalAmountOfObjectsToFind.Text = tbMaximalAmountOfObjectsToFind.Value.ToString();
                //----------------------------------------------------------------------------------------------
            }
        }
        private void ApplyDefaults()
        {
            caCalibration.ApplyDefaults();
            if (mDevice != null)
            {
                mDevice.VMD_AverageBufferSizeInFrames = 10;
                mDevice.VMD_ResizeSquare = Settings.VMD_ResizeSquare = 2;
                mDevice.VMD_Tolerance = Settings.VMD_Tolerance = 30;
                mDevice.VMD_MedianSquare = Settings.VMD_MedianSquare = 2;
                mDevice.VMD_MinimalDistanceBetweenTwoObjects = 10;
                mDevice.VMD_MaximalAmountOfObjectsToFind = 2;
                mDevice.VMD_WhatToShowType = clsDeviceWrap.eWhatToShowTypes.ShowRGBFrame;
                mDevice.VMD_FilterType = clsDeviceWrap.eFilterTypes.Filter_Blur_01;
                mDevice.Draw_ShowAcceptedObjects = true;
                mDevice.Draw_ShowAcceptedObjectsLimitSquares = true;
            }
        }
        #endregion

        #endregion
    }
}
