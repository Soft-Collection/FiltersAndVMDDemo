#ifndef __CGDIDRAW_H__
#define __CGDIDRAW_H__

//http://stackoverflow.com/questions/10715170/receiving-rtsp-stream-using-ffmpeg-library

#include "CFFCommon.h"

class CGDIDraw
{
private:
	enum eCriticalSections : int
	{
		GDIDraw = 0,
		CSSize = 1 //Must be last.
	};
private:
	HDC                   m_HDC;
	HDC                   m_MemoryDC;
	void*                 m_MemoryDC_Data_Ptr;
	BITMAPINFO*           m_bi;
	HBITMAP               m_MemoryBitmap;
	HPEN                  m_Pen_InstantMotionAccepted;
	HPEN                  m_Pen_DoubleSquare;
	HBRUSH                m_Brush_DoubleSquare;
	CCriticalSectionPool* mCriticalSectionPool;
	HWND                  mLastTargetWindow;
	int                   mLastWidth;
	int                   mLastHeight;
	BOOL                  mResourcesMustBeReallocated;
private:
	BOOL AllocateResources(CFFCommon::GDIDrawParams gdiDrawParams);
	BOOL DeallocateResources();
	BOOL AreParamsChanged(CFFCommon::GDIDrawParams gdiDrawParams);
public:
	CGDIDraw();
	~CGDIDraw();
	void ReallocateResources();
	VOID DrawImage(HWND hwnd, BYTE* data, int width, int height);
	VOID DrawInstantMotionAccepted(HWND hwnd, RECTANGLEF* InstantMotionAccepted, int InstantMotionAcceptedCount);
	VOID DrawDoubleSquare(HWND hwnd, POINTF centerLocation, float innerSquareDiagonal, float outerSquareDiagonal);
	BOOL DrawAll(CFFCommon::GDIDrawParams gdiDrawParams);
public:
	static BOOL IsPointOnTheLine(POINTF point, POINTF* line, float distance);
	static float DistanceBetweenPoints(POINTF point1, POINTF point2);
	static BOOL IsPointOnThePoint(POINTF point, POINTF pointOfSquare, float distance);
	static void GetSquarePoints(POINTF center, float diagonal, POINTF* squarePoints);
	static void GetCenterLines(POINTF center, float diagonal, POINTF* centerLines);
	static RECTANGLEF GetEllipseRectangleFromCenterAndRadius(POINTF center, float diagonal);
	static double GetAngle(POINTF p0, POINTF center, POINTF p1);
	static POINTF Translate_M1P1_0P1(POINTF pt); //Translate from [-1..1] to [0..1].
	static POINTF Translate_0P1_M1P1(POINTF pt); //Translate from [0..1] to [-1..1].
	static POINTF Translate_0P1_P10(POINTF pt); //Translate from [0..1] to [1..0].
	static void Translate_0P1_ToRealDimensions(POINTF* pt, int width, int height);
	static void Translate_0P1_ToRealDimensions(RECTANGLEF* rc, int width, int height);
};

#endif //__CGDIDRAW_H__