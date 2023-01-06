#include "stdafx.h"
#include "StreamingUtil.h"

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Audio Video In///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void* DeviceCreateNew()
{
	CDevice* cDevice = new CDevice();
	return ((void*)cDevice);
}
void DeviceDispose(void* handle)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	delete cDevice;
}
void DeviceConnect(void* handle)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->Connect();
}
void DeviceDisconnect(void* handle)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->Disconnect();
}
CFFCommon::eConnectionStates DeviceGetConnectionState(void* handle)
{
	if (handle == NULL) return(CFFCommon::eConnectionStates::NotSetYet);
	CDevice* cDevice = (CDevice*)handle;
	return (cDevice->GetConnectionState());
}
void DeviceRGBPictureLock(void* handle)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->RGBPictureLock();
}
void DeviceRGBPictureUnlock(void* handle)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->RGBPictureUnlock();
}
void DeviceGetRGBPictureSize(void* handle, int* width, int* height)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->GetRGBPictureSize(width, height);
}
void DeviceGetRGBPictureData(void* handle, BYTE* data)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->GetRGBPictureData(data);
}
//------------------------------------------------------------------------------------------------------------------------------
void DeviceSetFiltersAndVMDDemoInfo1(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, int val)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->SetFiltersAndVMDDemoInfo(filtersAndVMDDemoInfoDataType, val);
}
void DeviceSetFiltersAndVMDDemoInfo2(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, float val)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->SetFiltersAndVMDDemoInfo(filtersAndVMDDemoInfoDataType, val);
}
void DeviceSetFiltersAndVMDDemoInfo3(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF val)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->SetFiltersAndVMDDemoInfo(filtersAndVMDDemoInfoDataType, val);
}
void DeviceSetFiltersAndVMDDemoInfo4(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF* val)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->SetFiltersAndVMDDemoInfo(filtersAndVMDDemoInfoDataType, val);
}
void DeviceSetFiltersAndVMDDemoInfo5(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, LPTSTR val)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->SetFiltersAndVMDDemoInfo(filtersAndVMDDemoInfoDataType, val);
}
void DeviceSetFiltersAndVMDDemoInfo6(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, HWND val)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->SetFiltersAndVMDDemoInfo(filtersAndVMDDemoInfoDataType, val);
}
void DeviceSetFiltersAndVMDDemoInfo7(void* handle, CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, COLORREF val)
{
	if (handle == NULL) return;
	CDevice* cDevice = (CDevice*)handle;
	cDevice->SetFiltersAndVMDDemoInfo(filtersAndVMDDemoInfoDataType, val);
}