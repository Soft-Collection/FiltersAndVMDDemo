#ifndef __CDEVICE_H__
#define __CDEVICE_H__

#include "CFFCommon.h"
#include "CFFMpegRtsp.h"
#include "CBuffer.h"
#include "CFFDecodeVideo.h"
#include "CFFDecodeAudio.h"
#include "CFFSampleConversion.h"
#include "CWavePlaying.h"
#include "CFFColorConversion.h"
#include "CFilter.h"
#include "CGDIDraw.h"
#include "CVMDAverageBuffer.h"
#include "CVMDFrame.h"
#include <tchar.h>

class CDevice
{
private:
	LPCRITICAL_SECTION                mCriticalSection;
	//----------------------------------------
	CFFCommon::FiltersAndVMDDemoInfo* mFiltersAndVMDDemoInfo;
	//----------------------------------------
	BYTE*                             mRGBPicture;
	int                               mRGBPictureWidth;
	int                               mRGBPictureHeight;
	//----------------------------------------
	class  CFFMpegRtsp*               mFFMpegRtsp;
	class  CBuffer*                   mBuffer;
	class  CFFDecodeVideo*            mFFDecodeVideo;
	class  CFFDecodeAudio*            mFFDecodeAudio;
	class  CFFSampleConversion*       mFFSampleConversion;
	class  CWavePlaying*              mWavePlaying;
	class  CFFColorConversion*        mFFColorConversion;
	class  CFilter*                   mFilter;
	class  CGDIDraw*                  mGDIDrawTarget;
	//----------------------------------------
	RECTANGLEF*                       mInstantMotionAccepted;
	POINTF*                           mInstantMotionAcceptedAveragePoint;
	CVMDAverageBuffer*                mAverageBuffer;
	//----------------------------------------
	int                               mLastResizeSquare;
	//----------------------------------------
	BOOL                              mAverageBufferMustBeReallocated;
public:
	CDevice();
	~CDevice();
	void Connect();
	void Disconnect();
	CFFCommon::eConnectionStates GetConnectionState();
	void RGBPictureLock();
	void RGBPictureUnlock();
	void GetRGBPictureSize(int* width, int* height);
	void GetRGBPictureData(BYTE* data);
	//--------------------------------------------------------------------------------------------------
	void SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, int val);
	void SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, float val);
	void SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF val);
	void SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF* val);
	void SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, LPTSTR val);
	void SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, HWND val);
	void SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, COLORREF val);
	//--------------------------------------------------------------------------------------------------
private:
	static void OnFrameReceivedFromRTSPStatic(void* user, CFFCommon::RTSPFrameData rtspFrame);
	void        OnFrameReceivedFromRTSP(CFFCommon::RTSPFrameData rtspFrame);
	static void OnFrameReceivedFromBufferStatic(void* user, CFFCommon::RTSPFrameData rtspFrame);
	void        OnFrameReceivedFromBuffer(CFFCommon::RTSPFrameData rtspFrame);
};

#endif //__CDEVICE_H__