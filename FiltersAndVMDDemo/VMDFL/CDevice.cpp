#include "stdafx.h"
#include "CDevice.h"
#include "../Common/CExceptionReport.h"

CDevice::CDevice()
{
	try
	{
		mCriticalSection = NULL;
		//----------------------------------------
		mFiltersAndVMDDemoInfo = NULL;
		//----------------------------------------
		mRGBPicture = NULL;
		mRGBPictureWidth = 0;
		mRGBPictureHeight = 0;
		//----------------------------------------
		mFFMpegRtsp = NULL;
		mBuffer = NULL;
		mFFDecodeVideo = NULL;
		mFFDecodeAudio = NULL;
		mFFSampleConversion = NULL;
		mWavePlaying = NULL;
		mFFColorConversion = NULL;
		mFilter = NULL;
		mGDIDrawTarget = NULL;
		mInstantMotionAccepted = NULL;
		mInstantMotionAcceptedAveragePoint = NULL;
		mAverageBuffer = NULL;
		mLastResizeSquare = 0;
		mAverageBufferMustBeReallocated = FALSE;
		//========================================
		mCriticalSection = new CRITICAL_SECTION;
		InitializeCriticalSection(mCriticalSection);
		//----------------------------------------
		mFiltersAndVMDDemoInfo = new CFFCommon::FiltersAndVMDDemoInfo;
		memset(mFiltersAndVMDDemoInfo, 0, sizeof(CFFCommon::FiltersAndVMDDemoInfo));
		//----------------------------------------
		mRGBPicture = new BYTE[1920 * 1080 * 3];
		//----------------------------------------
		mGDIDrawTarget = new CGDIDraw();
		mFilter = new CFilter();
		mInstantMotionAccepted = new RECTANGLEF[5000];
		mInstantMotionAcceptedAveragePoint = new POINTF[5000];
		mAverageBuffer = new CVMDAverageBuffer;
		mFFColorConversion = new CFFColorConversion();
		mFFDecodeVideo = new CFFDecodeVideo();
		mFFDecodeAudio = new CFFDecodeAudio();
		mFFSampleConversion = new CFFSampleConversion();
		mBuffer = new CBuffer(OnFrameReceivedFromBufferStatic, this);
		mFFMpegRtsp = new CFFMpegRtsp(OnFrameReceivedFromRTSPStatic, this);
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::CDeviceManager", "Exception in CDeviceManager Constructor");
	}
}
CDevice::~CDevice()
{
	try
	{
		if (mFFMpegRtsp != NULL)
		{
			delete mFFMpegRtsp;
			mFFMpegRtsp = NULL;
		}
		if (mBuffer != NULL)
		{
			delete mBuffer;
			mBuffer = NULL;
		}
		if (mWavePlaying != NULL)
		{
			delete mWavePlaying;
			mWavePlaying = NULL;
		}
		if (mFFSampleConversion != NULL)
		{
			delete mFFSampleConversion;
			mFFSampleConversion = NULL;
		}
		if (mFFDecodeAudio != NULL)
		{
			delete mFFDecodeAudio;
			mFFDecodeAudio = NULL;
		}
		if (mFFDecodeVideo != NULL)
		{
			delete mFFDecodeVideo;
			mFFDecodeVideo = NULL;
		}
		if (mFFColorConversion != NULL)
		{
			delete mFFColorConversion;
			mFFColorConversion = NULL;
		}
		if (mInstantMotionAccepted != NULL)
		{
			delete[] mInstantMotionAccepted;
			mInstantMotionAccepted = NULL;
		}
		if (mInstantMotionAcceptedAveragePoint != NULL)
		{
			delete[] mInstantMotionAcceptedAveragePoint;
			mInstantMotionAcceptedAveragePoint = NULL;
		}
		if (mAverageBuffer != NULL)
		{
			delete mAverageBuffer;
			mAverageBuffer = NULL;
		}
		if (mFilter != NULL)
		{
			delete mFilter;
			mFilter = NULL;
		}
		if (mGDIDrawTarget != NULL)
		{
			delete mGDIDrawTarget;
			mGDIDrawTarget = NULL;
		}
		if (mRGBPicture != NULL)
		{
			delete[] mRGBPicture;
			mRGBPicture = NULL;
		}
		if (mFiltersAndVMDDemoInfo != NULL)
		{
			delete mFiltersAndVMDDemoInfo;
			mFiltersAndVMDDemoInfo = NULL;
		}
		//----------------------------------------
		if (mCriticalSection != NULL)
		{
		  	DeleteCriticalSection(mCriticalSection);
			mCriticalSection = NULL;
		}
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::~CDeviceManager", "Exception in CDeviceManager Destructor");
	}
}
void CDevice::Connect()
{
	try
	{
		mAverageBufferMustBeReallocated = TRUE;
		if (mFFColorConversion != NULL) mFFColorConversion->ReallocateResources();
		if (mFFDecodeVideo != NULL) mFFDecodeVideo->ReallocateResources();
		if (mFFDecodeAudio != NULL) mFFDecodeAudio->ReallocateResources();
		if (mFFSampleConversion != NULL) mFFSampleConversion->ReallocateResources();
		if (mFFMpegRtsp != NULL) mFFMpegRtsp->Connect(mFiltersAndVMDDemoInfo->Connection.URL, mFiltersAndVMDDemoInfo->Connection.IsWebCam);
	}
	catch (...)
	{

	}
}
void CDevice::Disconnect()
{
	try
	{
		if (mFFMpegRtsp != NULL) mFFMpegRtsp->Disconnect();
	}
	catch (...)
	{

	}
}
CFFCommon::eConnectionStates CDevice::GetConnectionState()
{
	CFFCommon::eConnectionStates retVal;
	try
	{
		if (mFFMpegRtsp != NULL) retVal = mFFMpegRtsp->GetConnectionState();
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::OnFrameReceived", "Exception in CDeviceManager::GetConnectionState");
	}
	return retVal;
}
void CDevice::RGBPictureLock()
{
	try
	{
		EnterCriticalSection(mCriticalSection);
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::OnFrameReceived", "Exception in CDeviceManager::GetConnectionState");
	}
}
void CDevice::RGBPictureUnlock()
{
	try
	{
		LeaveCriticalSection(mCriticalSection);
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::OnFrameReceived", "Exception in CDeviceManager::GetConnectionState");
	}
}
void CDevice::GetRGBPictureSize(int* width, int* height)
{
	try
	{
		*width =  mRGBPictureWidth;
		*height = mRGBPictureHeight;
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::OnFrameReceived", "Exception in CDeviceManager::GetConnectionState");
	}
}
void CDevice::GetRGBPictureData(BYTE* data)
{
	try
	{
		memcpy(data, mRGBPicture, mRGBPictureWidth * mRGBPictureHeight * 3);
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::OnFrameReceived", "Exception in CDeviceManager::GetConnectionState");
	}
}
void CDevice::SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, int val)
{
	switch (filtersAndVMDDemoInfoDataType)
	{
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_AverageBufferSizeInFrames:
			mFiltersAndVMDDemoInfo->VMD.AverageBufferSizeInFrames = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_ResizeSquare:
			mFiltersAndVMDDemoInfo->VMD.ResizeSquare = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_Tolerance:
			mFiltersAndVMDDemoInfo->VMD.Tolerance = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_MedianSquare:
			mFiltersAndVMDDemoInfo->VMD.MedianSquare = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_MinimalDistanceBetweenTwoObjects:
			mFiltersAndVMDDemoInfo->VMD.MinimalDistanceBetweenTwoObjects = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_MaximalAmountOfObjectsToFind:
			mFiltersAndVMDDemoInfo->VMD.MaximalAmountOfObjectsToFind = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_WhatToShowType:
			mFiltersAndVMDDemoInfo->VMD.WhatToShowType = (CFFCommon::eWhatToShowTypes)val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_FilterType:
			mFiltersAndVMDDemoInfo->VMD.FilterType = (CFFCommon::eFilterTypes)val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::Draw_ShowAcceptedObjects:
			mFiltersAndVMDDemoInfo->Draw.ShowAcceptedObjects = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::Draw_ShowAcceptedObjectsLimitSquares:
			mFiltersAndVMDDemoInfo->Draw.ShowAcceptedObjectsLimitSquares = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::Connection_IsWebCam:
			mFiltersAndVMDDemoInfo->Connection.IsWebCam = val;
			break;
	}
}
void CDevice::SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, float val)
{
	switch (filtersAndVMDDemoInfoDataType)
	{
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_AcceptedObjectLimit_MinWidth:
			mFiltersAndVMDDemoInfo->VMD.AcceptedObjectLimit.MinWidth = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_AcceptedObjectLimit_MinHeight:
			mFiltersAndVMDDemoInfo->VMD.AcceptedObjectLimit.MinHeight = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_AcceptedObjectLimit_MaxWidth:
			mFiltersAndVMDDemoInfo->VMD.AcceptedObjectLimit.MaxWidth = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::VMD_AcceptedObjectLimit_MaxHeight:
			mFiltersAndVMDDemoInfo->VMD.AcceptedObjectLimit.MaxHeight = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::Draw_DoubleSquare_InnerSquareDiagonal:
			mFiltersAndVMDDemoInfo->Draw.DoubleSquare_InnerSquareDiagonal = val;
			break;
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::Draw_DoubleSquare_OuterSquareDiagonal:
			mFiltersAndVMDDemoInfo->Draw.DoubleSquare_OuterSquareDiagonal = val;
			break;
	}
}
void CDevice::SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF val)
{
	switch (filtersAndVMDDemoInfoDataType)
	{
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::Draw_DoubleSquare_CenterLocation:
			mFiltersAndVMDDemoInfo->Draw.DoubleSquare_CenterLocation = val;
			break;
	}
}
void CDevice::SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, POINTF* val)
{
	switch (filtersAndVMDDemoInfoDataType)
	{
		default:
			break;
	}
}
void CDevice::SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, LPTSTR val)
{
	switch (filtersAndVMDDemoInfoDataType)
	{
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::Connection_URL:
			_tcscpy(mFiltersAndVMDDemoInfo->Connection.URL, val);
			break;
	}
}
void CDevice::SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, HWND val)
{
	switch (filtersAndVMDDemoInfoDataType)
	{
		case CFFCommon::eFiltersAndVMDDemoInfoDataTypes::Draw_Windows_TargetWindow:
			mFiltersAndVMDDemoInfo->Draw.Windows.TargetWindow = val;
			break;
	}
}
void CDevice::SetFiltersAndVMDDemoInfo(CFFCommon::eFiltersAndVMDDemoInfoDataTypes filtersAndVMDDemoInfoDataType, COLORREF val)
{
	switch (filtersAndVMDDemoInfoDataType)
	{
		default:
			break;
	}
}
void CDevice::OnFrameReceivedFromRTSPStatic(void* user, CFFCommon::RTSPFrameData rtspFrame)
{
	CDevice* device = (CDevice*)user;
	if (device != NULL)
	{
		device->OnFrameReceivedFromRTSP(rtspFrame);
	}
}
void CDevice::OnFrameReceivedFromRTSP(CFFCommon::RTSPFrameData rtspFrame)
{
	try
	{
		if (mBuffer != NULL)
		{
			mBuffer->Enqueue(rtspFrame);
		}
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::OnFrameReceived", "Exception in CDeviceManager::OnFrameReceived");
	}
}
void CDevice::OnFrameReceivedFromBufferStatic(void* user, CFFCommon::RTSPFrameData rtspFrame)
{
	CDevice* device = (CDevice*)user;
	if (device != NULL)
	{
		device->OnFrameReceivedFromBuffer(rtspFrame);
	}
}
void CDevice::OnFrameReceivedFromBuffer(CFFCommon::RTSPFrameData rtspFrame)
{
	try
	{
		if (rtspFrame.MediaType == AVMEDIA_TYPE_AUDIO)
		{
			CFFCommon::DecodeAudioData decodeAudioData;
			CFFCommon::SampleConversionData sampleConversionData;
			//------------------------
			int res = 0;
			int res1 = 0;
			if (mFFMpegRtsp != NULL)
			{
				if (mFFDecodeAudio != NULL)
				{
					CFFCommon::DecodeAudioParams dap;
					dap.CodecID = rtspFrame.CodecID;
					dap.RTSPFrame = rtspFrame;
					dap.RTSPFrame.MediaType = AVMEDIA_TYPE_AUDIO;
					res = mFFDecodeAudio->DecodeAudio(dap, &decodeAudioData);
					if (res > 0)
					{
						if (mFFSampleConversion != NULL)
						{
							CFFCommon::SampleConversionParams scp;
							scp.Source.ChannelLayout = decodeAudioData.ChannelLayout;
							scp.Source.SampleRate = decodeAudioData.SampleRate;
							scp.Source.SampleFormatsID = decodeAudioData.SampleFmt;
							scp.Target.ChannelLayout = decodeAudioData.ChannelLayout;
							scp.Target.SampleRate = decodeAudioData.SampleRate;
							scp.Target.SampleFormatsID = AV_SAMPLE_FMT_S16;
							scp.DecodedAudio = decodeAudioData;
							res1 = mFFSampleConversion->PerformSampleConversion(scp, &sampleConversionData);
							if (res1 > 0)
							{
								if (sampleConversionData.ParamsChanged)
								{
									mWavePlaying = new CWavePlaying(10, 10000, sampleConversionData.SamplesPerSec, sampleConversionData.BitsPerSample, sampleConversionData.Channels);
									mWavePlaying->Open();
								}
								mWavePlaying->Play((char*)*sampleConversionData.Data, 0, (ULONG)sampleConversionData.LineSize[0] / (sampleConversionData.BitsPerSample / 8));
							}
						}
					}
				}
			}
		}
		if (rtspFrame.MediaType == AVMEDIA_TYPE_VIDEO)
		{
			CFFCommon::DecodeVideoData decodeVideoData;
			CFFCommon::ColorConversionData colorConversionData;
			//------------------------
			int res = 0;
			int res1 = 0;
			if (mFFMpegRtsp != NULL)
			{
				if (mFFDecodeVideo != NULL)
				{
					CFFCommon::DecodeVideoParams dp;
					dp.CodecID = rtspFrame.CodecID;
					dp.RTSPFrame = rtspFrame;
					dp.RTSPFrame.MediaType = AVMEDIA_TYPE_VIDEO;
					res = mFFDecodeVideo->DecodeVideo(dp, &decodeVideoData);
					if (res > 0)
					{
						if (mFFColorConversion != NULL)
						{
							CFFCommon::ColorConversionParams ccp;
							ccp.SourcePixelFormatsID = decodeVideoData.TargetPixelFormatsID;
							ccp.TargetPixelFormatsID = AV_PIX_FMT_BGR24;
							ccp.DecodedVideo = decodeVideoData;
							double widthHeightRatio = (double)decodeVideoData.Width / (double)decodeVideoData.Height;
							ccp.ResizedHeight = min(decodeVideoData.Height, 480);
							ccp.ResizedWidth = (int)((double)ccp.ResizedHeight * widthHeightRatio);
							res1 = mFFColorConversion->PerformColorConversion(ccp, &colorConversionData);
							if (res1 > 0)
							{
								CVMDFrame* vmdFrame = NULL;
								CVMDFrame* averageFrame = NULL;
								CVMDFrame* differenceFrame = NULL;
								CVMDFrame* toleranceFrame = NULL;
								CVMDFrame* medianFrame = NULL;
								CVMDFrame* borderFrame = NULL;
								CVMDFrame* filteredFrame = NULL;
								//--------------------------------------------------------------------------------------------------
								mAverageBuffer->SetDesiredCount(mFiltersAndVMDDemoInfo->VMD.AverageBufferSizeInFrames);
								vmdFrame = new CVMDFrame(VMD_RGB_COLOR_TYPE, colorConversionData.Width, colorConversionData.Height, *colorConversionData.Data, mFiltersAndVMDDemoInfo->VMD.ResizeSquare);
								if (vmdFrame != NULL)
								{
									if (colorConversionData.ParamsChanged) mAverageBufferMustBeReallocated = TRUE;
									if (mLastResizeSquare != mFiltersAndVMDDemoInfo->VMD.ResizeSquare)
									{
										mAverageBufferMustBeReallocated = TRUE;
										mLastResizeSquare = mFiltersAndVMDDemoInfo->VMD.ResizeSquare;
									}
									if (mAverageBufferMustBeReallocated)
									{
										mAverageBufferMustBeReallocated = FALSE;
										if (mAverageBuffer != NULL)
										{
											delete mAverageBuffer;
											mAverageBuffer = NULL;
										}
										mAverageBuffer = new CVMDAverageBuffer;
										mAverageBuffer->SetDesiredCount(mFiltersAndVMDDemoInfo->VMD.AverageBufferSizeInFrames);
									}
									averageFrame = mAverageBuffer->Add(vmdFrame);
									if (averageFrame != NULL)
									{
										differenceFrame = vmdFrame->DifferenceFrame(averageFrame);
										if (differenceFrame != NULL)
										{
											toleranceFrame = differenceFrame->ToleranceFrame(mFiltersAndVMDDemoInfo->VMD.Tolerance);
											if (toleranceFrame != NULL)
											{
												medianFrame = toleranceFrame->MedianFrame(mFiltersAndVMDDemoInfo->VMD.MedianSquare);
												if (medianFrame != NULL)
												{
													borderFrame = medianFrame->BorderFrame();
													if (borderFrame != NULL)
													{
														//--------------------------------------------------------------------------------------------------
														FILTERINFO* fi = NULL;
														switch (mFiltersAndVMDDemoInfo->VMD.FilterType)
														{
														case CFFCommon::eFilterTypes::Filter_Blur_01:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_BLUR_01;
															break;
														case CFFCommon::eFilterTypes::Filter_Blur_02:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_BLUR_02;
															break;
														case CFFCommon::eFilterTypes::Filter_Blur_03:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_BLUR_03;
															break;
														case CFFCommon::eFilterTypes::Filter_Motion_Blur:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_MOTION_BLUR;
															break;
														case CFFCommon::eFilterTypes::Filter_Edges_01:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EDGES_01;
															break;
														case CFFCommon::eFilterTypes::Filter_Edges_02:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EDGES_02;
															break;
														case CFFCommon::eFilterTypes::Filter_Edges_03:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EDGES_03;
															break;
														case CFFCommon::eFilterTypes::Filter_Edges_04:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EDGES_04;
															break;
														case CFFCommon::eFilterTypes::Filter_Edges_Prewitt:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EDGES_PREWITT;
															break;
														case CFFCommon::eFilterTypes::Filter_Edges_Sobel:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EDGES_SOBEL;
															break;
														case CFFCommon::eFilterTypes::Filter_Edges_Laplacian:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EDGES_LAPLACIAN;
															break;
														case CFFCommon::eFilterTypes::Filter_Shapen_01:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_SHAPEN_01;
															break;
														case CFFCommon::eFilterTypes::Filter_Shapen_02:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_SHAPEN_02;
															break;
														case CFFCommon::eFilterTypes::Filter_Shapen_03:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_SHAPEN_03;
															break;
														case CFFCommon::eFilterTypes::Filter_Emboss_01:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EMBOSS_01;
															break;
														case CFFCommon::eFilterTypes::Filter_Emboss_02:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_EMBOSS_02;
															break;
														case CFFCommon::eFilterTypes::Filter_Mean:
															fi = (FILTERINFO*)&CVMDFrame::FILTER_MEAN;
															break;
														}
														filteredFrame = vmdFrame->FilteredFrame(fi);
														if (filteredFrame != NULL)
														{
															//--------------------------------------------------------------------------------------------------
															int instantMotionAcceptedCount;
															medianFrame->EnumerateMovingObjects(mFiltersAndVMDDemoInfo->VMD.MinimalDistanceBetweenTwoObjects, mFiltersAndVMDDemoInfo->VMD.AcceptedObjectLimit.MinWidth, mFiltersAndVMDDemoInfo->VMD.AcceptedObjectLimit.MinHeight, mFiltersAndVMDDemoInfo->VMD.AcceptedObjectLimit.MaxWidth, mFiltersAndVMDDemoInfo->VMD.AcceptedObjectLimit.MaxHeight, mFiltersAndVMDDemoInfo->VMD.MaximalAmountOfObjectsToFind, mInstantMotionAccepted, mInstantMotionAcceptedAveragePoint, &instantMotionAcceptedCount);
															//--------------------------------------------------------------------------------------------------
															EnterCriticalSection(mCriticalSection);
															//--------------------------------------
															switch (mFiltersAndVMDDemoInfo->VMD.WhatToShowType)
															{
															case CFFCommon::eWhatToShowTypes::ShowNotSetYet:
																break;
															case CFFCommon::eWhatToShowTypes::ShowRGBFrame:
																mRGBPictureWidth = colorConversionData.Width;
																mRGBPictureHeight = colorConversionData.Height;
																memcpy(mRGBPicture, *colorConversionData.Data, colorConversionData.Width * colorConversionData.Height * 3);
																break;
															case CFFCommon::eWhatToShowTypes::ShowVMDFrame:
																vmdFrame->GetDimensions(&mRGBPictureWidth, &mRGBPictureHeight);
																vmdFrame->GetData(mRGBPicture);
																break;
															case CFFCommon::eWhatToShowTypes::ShowAverageFrame:
																averageFrame->GetDimensions(&mRGBPictureWidth, &mRGBPictureHeight);
																averageFrame->GetData(mRGBPicture);
																break;
															case CFFCommon::eWhatToShowTypes::ShowDifferenceFrame:
																differenceFrame->GetDimensions(&mRGBPictureWidth, &mRGBPictureHeight);
																differenceFrame->GetData(mRGBPicture);
																break;
															case CFFCommon::eWhatToShowTypes::ShowToleranceFrame:
																toleranceFrame->GetDimensions(&mRGBPictureWidth, &mRGBPictureHeight);
																toleranceFrame->GetData(mRGBPicture);
																break;
															case CFFCommon::eWhatToShowTypes::ShowMedianFrame:
																medianFrame->GetDimensions(&mRGBPictureWidth, &mRGBPictureHeight);
																medianFrame->GetData(mRGBPicture);
																break;
															case CFFCommon::eWhatToShowTypes::ShowBorderFrame:
																borderFrame->GetDimensions(&mRGBPictureWidth, &mRGBPictureHeight);
																borderFrame->GetData(mRGBPicture);
																break;
															case CFFCommon::eWhatToShowTypes::ShowFilterFrame:
																filteredFrame->GetDimensions(&mRGBPictureWidth, &mRGBPictureHeight);
																filteredFrame->GetData(mRGBPicture);
																break;
															}
															//--------------------------------------
															LeaveCriticalSection(mCriticalSection);
															//--------------------------------------------------------------------------------------------------
															if (mGDIDrawTarget != NULL)
															{
																if (mFiltersAndVMDDemoInfo->Draw.Windows.TargetWindow != NULL)
																{
																	CFFCommon::GDIDrawParams gdp;
																	//--------------------------------------------------------------------------------------------------
																	gdp.ColorConversionWidth = mRGBPictureWidth;
																	gdp.ColorConversionHeight = mRGBPictureHeight;
																	//--------------------------------------------------------------------------------------------------
																	gdp.Data = mRGBPicture;
																	gdp.FiltersAndVMDDemoInfo = mFiltersAndVMDDemoInfo;
																	//--------------------------------------------------------------------------------------------------
																	gdp.InstantMotionAccepted = mInstantMotionAccepted;
																	gdp.InstantMotionAcceptedAveragePoint = mInstantMotionAcceptedAveragePoint;
																	gdp.InstantMotionAcceptedCount = instantMotionAcceptedCount;
																	//--------------------------------------------------------------------------------------------------
																	if (mFiltersAndVMDDemoInfo->VMD.WhatToShowType != CFFCommon::eWhatToShowTypes::ShowNotSetYet) mGDIDrawTarget->DrawAll(gdp);
																}
															}
															//--------------------------------------------------------------------------------------------------
															delete filteredFrame;
															filteredFrame = NULL;
														}
														delete borderFrame;
														borderFrame = NULL;
													}
													delete medianFrame;
													medianFrame = NULL;
												}
												delete toleranceFrame;
												toleranceFrame = NULL;
											}
											delete differenceFrame;
											differenceFrame = NULL;
										}
										delete averageFrame;
										averageFrame = NULL;
									}
									delete vmdFrame;
									vmdFrame = NULL;
								}
							}
						}
					}
				}
			}
		}
	}
	catch (...)
	{
		CExceptionReport::WriteExceptionReportToFile("CDeviceManager::OnFrameReceived", "Exception in CDeviceManager::OnFrameReceived");
	}
}
