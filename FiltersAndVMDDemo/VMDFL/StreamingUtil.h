#include "CFFCommon.h"
#include "CFFMpegRtsp.h"
#include "CDevice.h"

extern "C"
{
	__declspec(dllexport) void* DeviceCreateNew();
	__declspec(dllexport) void DeviceDispose(void* handle);
	__declspec(dllexport) void DeviceConnect(void* handle);
	__declspec(dllexport) void DeviceDisconnect(void* handle);
	__declspec(dllexport) CFFCommon::eConnectionStates DeviceGetConnectionState(void* handle);
	__declspec(dllexport) void DeviceRGBPictureLock(void* handle);
	__declspec(dllexport) void DeviceRGBPictureUnlock(void* handle);
	__declspec(dllexport) void DeviceGetRGBPictureSize(void* handle, int* width, int* height);
	__declspec(dllexport) void DeviceGetRGBPictureData(void* handle, BYTE* data);
	//--------------------------------------------------------------------------------------------------------------------------------------------------
	__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo1(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, int val);
	__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo2(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, float val);
	__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo3(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF val);
	__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo4(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF* val);
	__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo5(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, LPTSTR val);
	__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo6(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, HWND val);
	__declspec(dllexport) void DeviceSetFiltersAndVMDDemoInfo7(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, COLORREF val);
}