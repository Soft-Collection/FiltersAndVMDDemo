using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FiltersAndVMDDemo
{
    public class clsDeviceWrap
    {
        #region Constants
        private const string DllFileName = "VMDFL.dll";
        #endregion

        #region Enums
        public enum eWhatToShowTypes : int
        {
            ShowNotSetYet,
            ShowRGBFrame,
            ShowVMDFrame,
            ShowAverageFrame,
            ShowDifferenceFrame,
            ShowToleranceFrame,
            ShowMedianFrame,
            ShowBorderFrame,
            ShowFilterFrame
        };
        public enum eFilterTypes : int
        {
            Filter_Blur_01,
            Filter_Blur_02,
            Filter_Blur_03,
            Filter_Motion_Blur,
            Filter_Edges_01,
            Filter_Edges_02,
            Filter_Edges_03,
            Filter_Edges_04,
            Filter_Edges_Prewitt,
            Filter_Edges_Sobel,
            Filter_Edges_Laplacian,
            Filter_Shapen_01,
            Filter_Shapen_02,
            Filter_Shapen_03,
            Filter_Emboss_01,
            Filter_Emboss_02,
            Filter_Mean
        };
        public enum eFiltersAndVMDDemoInfoDataTypes : int
        {
            //-------------------------------------
            VMD_AverageBufferSizeInFrames,
            VMD_ResizeSquare,
            VMD_Tolerance,
            VMD_MedianSquare,
            VMD_MinimalDistanceBetweenTwoObjects,
            VMD_MaximalAmountOfObjectsToFind,
            VMD_WhatToShowType,
            VMD_FilterType,
            //-------------------
            VMD_AcceptedObjectLimit_MinWidth,
            VMD_AcceptedObjectLimit_MinHeight,
            VMD_AcceptedObjectLimit_MaxWidth,
            VMD_AcceptedObjectLimit_MaxHeight,
            //-------------------------------------
            Draw_Windows_TargetWindow,
            Draw_DoubleSquare_CenterLocation,
            Draw_DoubleSquare_InnerSquareDiagonal,
            Draw_DoubleSquare_OuterSquareDiagonal,
            Draw_ShowAcceptedObjects,
            Draw_ShowAcceptedObjectsLimitSquares,
            //-------------------------------------
            Connection_URL,
            Connection_IsWebCam
            //-------------------------------------
        };
        #endregion

        #region Structures
        #endregion

        #region External Functions
        //__declspec(dllexport) void* DeviceCreateNew();
        //__declspec(dllexport) void DeviceDispose(void* handle);
        //__declspec(dllexport) void DeviceConnect(void* handle);
        //__declspec(dllexport) void DeviceDisconnect(void* handle);
        //__declspec(dllexport) CFFCommon::eConnectionStates DeviceGetConnectionState(void* handle);
        //__declspec(dllexport) void DeviceRGBPictureLock(void* handle);
        //__declspec(dllexport) void DeviceRGBPictureUnlock(void* handle);
        //__declspec(dllexport) void DeviceGetRGBPictureSize(void* handle, int* width, int* height);
        //__declspec(dllexport) void DeviceGetRGBPictureData(void* handle, BYTE* data);
        //__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo1(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, int val);
        //__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo2(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, float val);
        //__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo3(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF val);
        //__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo4(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF* val);
        //__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo5(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, LPTSTR val);
        //__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo6(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, HWND val);
        //__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo7(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, COLORREF val);
        //================================================================================================
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DeviceCreateNew();
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceDispose(IntPtr handle);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceConnect(IntPtr handle);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceDisconnect(IntPtr handle);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Common.eConnectionStates DeviceGetConnectionState(IntPtr handle);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceRGBPictureLock(IntPtr handle);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceRGBPictureUnlock(IntPtr handle);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceGetRGBPictureSize(IntPtr handle, ref int width, ref int height);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceGetRGBPictureData(IntPtr handle, byte[] data);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceGetRGBPictureData(IntPtr handle, IntPtr data);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceSetFiltersAndVMDDemoInfo1(IntPtr handle, eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, int val);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceSetFiltersAndVMDDemoInfo2(IntPtr handle, eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, float val);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceSetFiltersAndVMDDemoInfo3(IntPtr handle, eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, PointF val);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceSetFiltersAndVMDDemoInfo4(IntPtr handle, eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, PointF[] val);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceSetFiltersAndVMDDemoInfo5(IntPtr handle, eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, string val);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceSetFiltersAndVMDDemoInfo6(IntPtr handle, eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, IntPtr val);
        //------------------------------------------------------------------------------------------------
        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeviceSetFiltersAndVMDDemoInfo7(IntPtr handle, eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, uint val);
        #endregion
    }
}