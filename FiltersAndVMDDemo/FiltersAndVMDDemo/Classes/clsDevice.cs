using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiltersAndVMDDemo
{
    public class clsDevice : IDisposable
    {
        #region Inner Classes
        public class DeviceCommand
        {
            #region Enums
            public enum eCommandTypes
            {
                CreateNew,
                Dispose,
                Connect,
                Disconnect,
                ConnectStartServer,
                DisconnectStopServer,
                SetFiltersAndVMDDemoInfo
            }
            #endregion

            #region Variables
            public eCommandTypes CommandType;
            public clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes FiltersAndVMDDemoInfoDataType;
            public int valInt;
            public float valFloat;
            public System.Drawing.PointF valPointF;
            public System.Drawing.PointF[] valPointFArray;
            public string valString;
            public IntPtr valIntPtr;
            public System.Drawing.Color valColor;
            #endregion
        }
        #endregion

        #region Delegates
        #endregion

        #region Events
        #endregion

        #region Enums
        #endregion

        #region Variables
        private IntPtr mHandle = IntPtr.Zero;
        private bool mDisposed = false;
        //-------------------------------------
        private Bitmap mRGBPicture = null;
        //-------------------------------------
        private Queue<DeviceCommand> mDeviceCommandQueue = null;
        private object mDeviceCommandQueueLock = new object();
        private Task mDeviceCommandQueueTask = null;
        private bool mDeviceCommandQueueTaskQuit = false;
        #endregion

        #region Properties
        public int VMD_AverageBufferSizeInFrames
        {
            get
            {
                return Settings.VMD_AverageBufferSizeInFrames;
            }
            set
            {
                Settings.VMD_AverageBufferSizeInFrames = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AverageBufferSizeInFrames, value);
                }
                catch { }
                //----------------------------
            }
        }
        public int VMD_ResizeSquare
        {
            get
            {
                return Settings.VMD_ResizeSquare;
            }
            set
            {
                Settings.VMD_ResizeSquare = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_ResizeSquare, value);
                }
                catch { }
                //----------------------------
            }
        }
        public int VMD_Tolerance
        {
            get
            {
                return Settings.VMD_Tolerance;
            }
            set
            {
                Settings.VMD_Tolerance = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_Tolerance, value);
                }
                catch { }
                //----------------------------
            }
        }
        public int VMD_MedianSquare
        {
            get
            {
                return Settings.VMD_MedianSquare;
            }
            set
            {
                Settings.VMD_MedianSquare = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_MedianSquare, value);
                }
                catch { }
                //----------------------------
            }
        }
        public int VMD_MinimalDistanceBetweenTwoObjects
        {
            get
            {
                return Settings.VMD_MinimalDistanceBetweenTwoObjects;
            }
            set
            {
                Settings.VMD_MinimalDistanceBetweenTwoObjects = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_MinimalDistanceBetweenTwoObjects, value);
                }
                catch { }
                //----------------------------
            }
        }
        public int VMD_MaximalAmountOfObjectsToFind
        {
            get
            {
                return Settings.VMD_MaximalAmountOfObjectsToFind;
            }
            set
            {
                Settings.VMD_MaximalAmountOfObjectsToFind = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_MaximalAmountOfObjectsToFind, value);
                }
                catch { }
                //----------------------------
            }
        }
        public clsDeviceWrap.eWhatToShowTypes VMD_WhatToShowType
        {
            get
            {
                return Settings.VMD_WhatToShowType;
            }
            set
            {
                Settings.VMD_WhatToShowType = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_WhatToShowType, (int)value);
                }
                catch { }
                //----------------------------
            }
        }
        public clsDeviceWrap.eFilterTypes VMD_FilterType
        {
            get
            {
                return Settings.VMD_FilterType;
            }
            set
            {
                Settings.VMD_FilterType = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_FilterType, (int)value);
                }
                catch { }
                //----------------------------
            }
        }
        //-----------------------------------------------------------------------
        public bool Draw_ShowAcceptedObjects
        {
            get
            {
                return Settings.Draw_ShowAcceptedObjects;
            }
            set
            {
                Settings.Draw_ShowAcceptedObjects = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_ShowAcceptedObjects, (value) ? 1 : 0);
                }
                catch { }
                //----------------------------
            }
        }
        public bool Draw_ShowAcceptedObjectsLimitSquares
        {
            get
            {
                return Settings.Draw_ShowAcceptedObjectsLimitSquares;
            }
            set
            {
                Settings.Draw_ShowAcceptedObjectsLimitSquares = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_ShowAcceptedObjectsLimitSquares, (value) ? 1 : 0);
                }
                catch { }
                //----------------------------
            }
        }
        //-----------------------------------------------------------------------
        public PointF Draw_DoubleSquare_CenterLocation
        {
            get
            {
                return Settings.Draw_DoubleSquare_CenterLocation;
            }
            set
            {
                Settings.Draw_DoubleSquare_CenterLocation = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_CenterLocation, value);
                }
                catch { }
                //----------------------------
            }
        }
        public float Draw_DoubleSquare_InnerSquareDiagonal
        {
            get
            {
                return Settings.Draw_DoubleSquare_InnerSquareDiagonal;
            }
            set
            {
                Settings.Draw_DoubleSquare_InnerSquareDiagonal = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_InnerSquareDiagonal, value);
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AcceptedObjectLimit_MinWidth, value);
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AcceptedObjectLimit_MinHeight, value);
                }
                catch { }
                //----------------------------
            }
        }
        public float Draw_DoubleSquare_OuterSquareDiagonal
        {
            get
            {
                return Settings.Draw_DoubleSquare_OuterSquareDiagonal;
            }
            set
            {
                Settings.Draw_DoubleSquare_OuterSquareDiagonal = value;
                //----------------------------
                try
                {
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_OuterSquareDiagonal, value);
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AcceptedObjectLimit_MaxWidth, value);
                    EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AcceptedObjectLimit_MaxHeight, value);
                }
                catch { }
                //----------------------------
            }
        }
        //-----------------------------------------------------------------------
        public void Set_Connection_URL(string url, bool isWebCam)
        {
            try
            {
                EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Connection_URL, url);
                EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Connection_IsWebCam, (isWebCam) ? 1 : 0);
            }
            catch { }
        }
        public void Set_Draw_Windows_TargetWindow(IntPtr hWnd)
        {
            try
            {
                EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_Windows_TargetWindow, hWnd);
            }
            catch { }
        }
        public void Set_Draw_DoubleSquare(PointF center, float innerDiagonal, float outerDiagonal)
        {
            try
            {
                EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_CenterLocation, center);
                EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_InnerSquareDiagonal, innerDiagonal);
                EnqueueCommand(DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_OuterSquareDiagonal, outerDiagonal);
            }
            catch { }
        }
        #endregion

        #region New / Dispose
        public clsDevice()
        {
            try
            {
                mDeviceCommandQueue = new Queue<DeviceCommand>();
                if (mDeviceCommandQueueTask == null)
                {
                    mDeviceCommandQueueTask = new Task(() =>
                    {
                        while (!mDeviceCommandQueueTaskQuit)
                        {
                            DeviceCommand cmd = null;
                            lock (mDeviceCommandQueueLock)
                            {
                                if (mDeviceCommandQueue.Count > 0)
                                {
                                    cmd = mDeviceCommandQueue.Dequeue();
                                }
                            }
                            if (cmd != null)
                            {
                                switch (cmd.CommandType)
                                {
                                    case DeviceCommand.eCommandTypes.CreateNew:
                                        {
                                            CreateDevice();
                                        }
                                        break;
                                    case DeviceCommand.eCommandTypes.Dispose:
                                        {
                                            DisposeDevice();
                                        }
                                        break;
                                    case DeviceCommand.eCommandTypes.Connect:
                                        {
                                            Connect();
                                        }
                                        break;
                                    case DeviceCommand.eCommandTypes.Disconnect:
                                        {
                                            Disconnect();
                                        }
                                        break;
                                    case DeviceCommand.eCommandTypes.ConnectStartServer:
                                        {
                                            ConnectStartServer();
                                        }
                                        break;
                                    case DeviceCommand.eCommandTypes.DisconnectStopServer:
                                        {
                                            DisconnectStopServer();
                                        }
                                        break;
                                    case DeviceCommand.eCommandTypes.SetFiltersAndVMDDemoInfo:
                                        {
                                            switch (cmd.FiltersAndVMDDemoInfoDataType)
                                            {
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AverageBufferSizeInFrames:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_ResizeSquare:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_Tolerance:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_MedianSquare:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_MinimalDistanceBetweenTwoObjects:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_MaximalAmountOfObjectsToFind:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_WhatToShowType:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_FilterType:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AcceptedObjectLimit_MinWidth:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valFloat);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AcceptedObjectLimit_MinHeight:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valFloat);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AcceptedObjectLimit_MaxWidth:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valFloat);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.VMD_AcceptedObjectLimit_MaxHeight:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valFloat);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_Windows_TargetWindow:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valIntPtr);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_CenterLocation:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valPointF);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_InnerSquareDiagonal:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valFloat);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_DoubleSquare_OuterSquareDiagonal:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valFloat);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_ShowAcceptedObjects:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Draw_ShowAcceptedObjectsLimitSquares:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Connection_URL:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valString);
                                                    }
                                                    break;
                                                case clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes.Connection_IsWebCam:
                                                    {
                                                        SetFiltersAndVMDDemoInfo(cmd.FiltersAndVMDDemoInfoDataType, cmd.valInt);
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    });
                    mDeviceCommandQueueTask.Start();
                }
                //----------------------------------------
                EnqueueCommand(DeviceCommand.eCommandTypes.CreateNew);
                //----------------------------------------
                //Update All The Properties On The DLL.
                VMD_AverageBufferSizeInFrames = VMD_AverageBufferSizeInFrames;
                VMD_ResizeSquare = Settings.VMD_ResizeSquare = VMD_ResizeSquare = Settings.VMD_ResizeSquare;
                VMD_Tolerance = Settings.VMD_Tolerance = VMD_Tolerance = Settings.VMD_Tolerance;
                VMD_MedianSquare = Settings.VMD_MedianSquare = VMD_MedianSquare = Settings.VMD_MedianSquare;
                VMD_MinimalDistanceBetweenTwoObjects = VMD_MinimalDistanceBetweenTwoObjects;
                VMD_MaximalAmountOfObjectsToFind = VMD_MaximalAmountOfObjectsToFind;
                VMD_WhatToShowType = VMD_WhatToShowType;
                VMD_FilterType = VMD_FilterType;
                //----------------------------------------
                Draw_DoubleSquare_CenterLocation = Draw_DoubleSquare_CenterLocation;
                Draw_DoubleSquare_InnerSquareDiagonal = Draw_DoubleSquare_InnerSquareDiagonal;
                Draw_DoubleSquare_OuterSquareDiagonal = Draw_DoubleSquare_OuterSquareDiagonal;
                Draw_ShowAcceptedObjects = Draw_ShowAcceptedObjects;
                Draw_ShowAcceptedObjectsLimitSquares = Draw_ShowAcceptedObjectsLimitSquares;
            }
            catch
            {
            }
        }
        ~clsDevice()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch
            {
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!this.mDisposed)
                {
                    if (disposing)
                    {
                    }
                    //-------------------------------------------------------
                    EnqueueCommand(DeviceCommand.eCommandTypes.Dispose);
                    //-------------------------------------------------------
                    mDeviceCommandQueueTaskQuit = true;
                    if (mDeviceCommandQueueTask != null)
                    {
                        mDeviceCommandQueueTask = null;
                    }
                    //-------------------------------------------------------
                    mDisposed = true;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Methods
        private void CreateDevice()
        {
            try
            {
                mHandle = clsDeviceWrap.DeviceCreateNew();
            }
            catch
            {
            }
        }
        private void DisposeDevice()
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceDispose(mHandle);
                    mHandle = IntPtr.Zero;
                }
            }
            catch
            {
            }
        }
        private void Connect()
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceConnect(mHandle);
                }
            }
            catch
            {
            }
        }
        private void Disconnect()
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceDisconnect(mHandle);
                }
            }
            catch
            {
            }
        }
        private void ConnectStartServer()
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    StartServer();
                    System.Threading.Thread.Sleep(2000);
                    clsDeviceWrap.DeviceConnect(mHandle);
                }
            }
            catch
            {
            }
        }
        private void DisconnectStopServer()
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceDisconnect(mHandle);
                    System.Threading.Thread.Sleep(2000);
                    StopServer();
                }
            }
            catch
            {
            }
        }
        private void StartServer()
        {
            try
            {
                Process[] temp = Process.GetProcessesByName("mediaServer_H264_HD");
                if (temp != null)
                {
                    if (temp.Length == 0)
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = CommonPathes.ProgramFilesPath + @"\mediaServer_H264_HD.exe";
                        process.StartInfo.Arguments = "";
                        process.StartInfo.WorkingDirectory = Path.GetDirectoryName(process.StartInfo.FileName);
                        process.Start();
                    }
                }
            }
            catch
            {
            }
        }
        public void StopServer()
        {
            try
            {
                Process[] temp = Process.GetProcessesByName("mediaServer_H264_HD");
                if (temp != null)
                {
                    foreach (Process process in temp)
                    {
                        process.Kill();
                    }
                }
            }
            catch
            {
            }
        }
        private void SetFiltersAndVMDDemoInfo(clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, int val)
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceSetFiltersAndVMDDemoInfo1(mHandle, filtersAndVMDDemoInfoDataType, val);
                }
            }
            catch
            {
            }
        }
        private void SetFiltersAndVMDDemoInfo(clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, float val)
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceSetFiltersAndVMDDemoInfo2(mHandle, filtersAndVMDDemoInfoDataType, val);
                }
            }
            catch
            {
            }
        }
        private void SetFiltersAndVMDDemoInfo(clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, System.Drawing.PointF val)
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceSetFiltersAndVMDDemoInfo3(mHandle, filtersAndVMDDemoInfoDataType, val);
                }
            }
            catch
            {
            }
        }
        private void SetFiltersAndVMDDemoInfo(clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, System.Drawing.PointF[] val)
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceSetFiltersAndVMDDemoInfo4(mHandle, filtersAndVMDDemoInfoDataType, val);
                }
            }
            catch
            {
            }
        }
        private void SetFiltersAndVMDDemoInfo(clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, string val)
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    if (val != null)
                    {
                        clsDeviceWrap.DeviceSetFiltersAndVMDDemoInfo5(mHandle, filtersAndVMDDemoInfoDataType, val);
                    }
                }
            }
            catch
            {
            }
        }
        private void SetFiltersAndVMDDemoInfo(clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, IntPtr val)
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    clsDeviceWrap.DeviceSetFiltersAndVMDDemoInfo6(mHandle, filtersAndVMDDemoInfoDataType, val);
                }
            }
            catch
            {
            }
        }
        private void SetFiltersAndVMDDemoInfo(clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, System.Drawing.Color val)
        {
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    byte r = val.R;
                    byte g = val.G;
                    byte b = val.B;
                    uint colorref = (uint)(b << 16) + (uint)(g << 8) + (uint)(r);
                    clsDeviceWrap.DeviceSetFiltersAndVMDDemoInfo7(mHandle, filtersAndVMDDemoInfoDataType, colorref);
                }
            }
            catch
            {
            }
        }
        public void EnqueueCommand(DeviceCommand.eCommandTypes commandType)
        {
            DeviceCommand cmd = new DeviceCommand();
            cmd.CommandType = commandType;
            lock (mDeviceCommandQueueLock)
            {
                mDeviceCommandQueue.Enqueue(cmd);
            }
        }
        private void EnqueueCommand(DeviceCommand.eCommandTypes commandType, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, int valInt)
        {
            DeviceCommand cmd = new DeviceCommand();
            cmd.CommandType = commandType;
            cmd.FiltersAndVMDDemoInfoDataType = filtersAndVMDDemoInfoDataType;
            cmd.valInt = valInt;
            lock (mDeviceCommandQueueLock)
            {
                mDeviceCommandQueue.Enqueue(cmd);
            }
        }
        private void EnqueueCommand(DeviceCommand.eCommandTypes commandType, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, float valFloat)
        {
            DeviceCommand cmd = new DeviceCommand();
            cmd.CommandType = commandType;
            cmd.FiltersAndVMDDemoInfoDataType = filtersAndVMDDemoInfoDataType;
            cmd.valFloat = valFloat;
            lock (mDeviceCommandQueueLock)
            {
                mDeviceCommandQueue.Enqueue(cmd);
            }
        }
        private void EnqueueCommand(DeviceCommand.eCommandTypes commandType, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, System.Drawing.PointF valPointF)
        {
            DeviceCommand cmd = new DeviceCommand();
            cmd.CommandType = commandType;
            cmd.FiltersAndVMDDemoInfoDataType = filtersAndVMDDemoInfoDataType;
            cmd.valPointF = valPointF;
            lock (mDeviceCommandQueueLock)
            {
                mDeviceCommandQueue.Enqueue(cmd);
            }
        }
        private void EnqueueCommand(DeviceCommand.eCommandTypes commandType, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, System.Drawing.PointF[] valPointFArray)
        {
            DeviceCommand cmd = new DeviceCommand();
            cmd.CommandType = commandType;
            cmd.FiltersAndVMDDemoInfoDataType = filtersAndVMDDemoInfoDataType;
            cmd.valPointFArray = valPointFArray;
            lock (mDeviceCommandQueueLock)
            {
                mDeviceCommandQueue.Enqueue(cmd);
            }
        }
        private void EnqueueCommand(DeviceCommand.eCommandTypes commandType, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, string valString)
        {
            DeviceCommand cmd = new DeviceCommand();
            cmd.CommandType = commandType;
            cmd.FiltersAndVMDDemoInfoDataType = filtersAndVMDDemoInfoDataType;
            cmd.valString = valString;
            lock (mDeviceCommandQueueLock)
            {
                mDeviceCommandQueue.Enqueue(cmd);
            }
        }
        private void EnqueueCommand(DeviceCommand.eCommandTypes commandType, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, IntPtr valIntPtr)
        {
            DeviceCommand cmd = new DeviceCommand();
            cmd.CommandType = commandType;
            cmd.FiltersAndVMDDemoInfoDataType = filtersAndVMDDemoInfoDataType;
            cmd.valIntPtr = valIntPtr;
            lock (mDeviceCommandQueueLock)
            {
                mDeviceCommandQueue.Enqueue(cmd);
            }
        }
        private void EnqueueCommand(DeviceCommand.eCommandTypes commandType, clsDeviceWrap.eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, System.Drawing.Color valColor)
        {
            DeviceCommand cmd = new DeviceCommand();
            cmd.CommandType = commandType;
            cmd.FiltersAndVMDDemoInfoDataType = filtersAndVMDDemoInfoDataType;
            cmd.valColor = valColor;
            lock (mDeviceCommandQueueLock)
            {
                mDeviceCommandQueue.Enqueue(cmd);
            }
        }
        public Common.eConnectionStates GetConnectionState()
        {
            Common.eConnectionStates retVal = Common.eConnectionStates.NotSetYet;
            try
            {
                if (!mHandle.Equals(IntPtr.Zero))
                {
                    retVal = clsDeviceWrap.DeviceGetConnectionState(mHandle);
                }
            }
            catch
            {
            }
            return retVal;
        }
        public Bitmap GetRGBPicture(bool update)
        {
            try
            {
                if (update)
                {
                    if (!mHandle.Equals(IntPtr.Zero))
                    {
                        clsDeviceWrap.DeviceRGBPictureLock(mHandle);
                        try
                        {
                            int width = 0;
                            int height = 0;
                            clsDeviceWrap.DeviceGetRGBPictureSize(mHandle, ref width, ref height);
                            if ((width > 0) && (height > 0))
                            {
                                mRGBPicture = new Bitmap(width, height);
                                BitmapData data = mRGBPicture.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                                clsDeviceWrap.DeviceGetRGBPictureData(mHandle, data.Scan0);
                                mRGBPicture.UnlockBits(data);
                            }
                        }
                        catch
                        {
                        }
                        clsDeviceWrap.DeviceRGBPictureUnlock(mHandle);
                    }
                }
            }
            catch
            {
            }
            return mRGBPicture;
        }
        #endregion
    }
}