#include "stdafx.h"
#include "CGDIDraw.h"
#include <tchar.h>

CGDIDraw::CGDIDraw()
{
	mCriticalSectionPool = new CCriticalSectionPool(eCriticalSections::CSSize);
	//-------------------------------------------------------
	m_HDC = NULL;
	m_MemoryDC = NULL;
	m_MemoryDC_Data_Ptr = NULL;
	m_bi = NULL;
	m_MemoryBitmap = NULL;
	mLastTargetWindow = NULL;
	mLastWidth = 0;
	mLastHeight = 0;
	mResourcesMustBeReallocated = FALSE;
}

CGDIDraw::~CGDIDraw()
{
	mCriticalSectionPool->Enter(eCriticalSections::GDIDraw);
	DeallocateResources();
	mCriticalSectionPool->Leave(eCriticalSections::GDIDraw);
	//--------------------------------------------------------------
	if (mCriticalSectionPool != NULL)
	{
		delete mCriticalSectionPool;
		mCriticalSectionPool = NULL;
	}
}

BOOL CGDIDraw::AllocateResources(CFFCommon::GDIDrawParams gdiDrawParams)
{
	try
	{
		if (gdiDrawParams.FiltersAndVMDDemoInfo->Draw.Windows.TargetWindow == NULL) return (FALSE);
		m_HDC = GetDC(gdiDrawParams.FiltersAndVMDDemoInfo->Draw.Windows.TargetWindow);
		if (m_HDC == NULL) return (FALSE);
		m_MemoryDC = CreateCompatibleDC(m_HDC);
		if (m_MemoryDC == NULL) return (FALSE);
		//--------------------------------------------------------
		m_bi = new BITMAPINFO;
		ZeroMemory(m_bi, sizeof(BITMAPINFO));
		m_bi->bmiHeader.biBitCount = 24;
		m_bi->bmiHeader.biCompression = BI_RGB;
		m_bi->bmiHeader.biPlanes = 1;
		m_bi->bmiHeader.biSize = 40;
		m_bi->bmiHeader.biWidth = gdiDrawParams.ColorConversionWidth;
		m_bi->bmiHeader.biHeight = -gdiDrawParams.ColorConversionHeight;
		m_bi->bmiHeader.biSizeImage = gdiDrawParams.ColorConversionWidth * gdiDrawParams.ColorConversionHeight * (m_bi->bmiHeader.biBitCount / 8);
		//--------------------------------------------------------
		m_MemoryBitmap = CreateDIBSection(m_MemoryDC, m_bi, DIB_RGB_COLORS, &m_MemoryDC_Data_Ptr, NULL, 0);
		SelectObject(m_MemoryDC, m_MemoryBitmap);
		//--------------------------------------------------------
		m_Pen_InstantMotionAccepted = CreatePen(PS_SOLID, 1, RGB(255, 255, 0));
		m_Pen_DoubleSquare = CreatePen(PS_SOLID, 2, RGB(255, 255, 0));
		m_Brush_DoubleSquare = CreateSolidBrush(RGB(255, 255, 0));
	}
	catch (...)
	{
		return (FALSE);
	}
	return (TRUE);
}

BOOL CGDIDraw::DeallocateResources()
{
	try
	{
		DeleteObject(m_Brush_DoubleSquare);
		DeleteObject(m_Pen_DoubleSquare);
		DeleteObject(m_Pen_InstantMotionAccepted);
		//--------------------------------------------------------
		if (m_bi != NULL)
		{
			delete m_bi;
			m_bi = NULL;
		}
		//--------------------------------------------------------
		ReleaseDC(mLastTargetWindow, m_MemoryDC);
		ReleaseDC(mLastTargetWindow, m_HDC);
	}
	catch (...)
	{
		return(FALSE);
	}
	return (TRUE);
}

void CGDIDraw::ReallocateResources()
{
	try
	{
		mResourcesMustBeReallocated = TRUE;
	}
	catch (...)
	{
	}
}

BOOL CGDIDraw::AreParamsChanged(CFFCommon::GDIDrawParams gdiDrawParams)
{
	BOOL retVal = FALSE;
	try
	{
		if (mResourcesMustBeReallocated)
		{
			mResourcesMustBeReallocated = FALSE;
			retVal = TRUE;
		}
		if ((mLastWidth != gdiDrawParams.ColorConversionWidth) ||
			(mLastHeight != gdiDrawParams.ColorConversionHeight) ||
			(mLastTargetWindow != gdiDrawParams.FiltersAndVMDDemoInfo->Draw.Windows.TargetWindow))
		{
			mLastWidth = gdiDrawParams.ColorConversionWidth;
			mLastHeight = gdiDrawParams.ColorConversionHeight;
			mLastTargetWindow = gdiDrawParams.FiltersAndVMDDemoInfo->Draw.Windows.TargetWindow;
			retVal = TRUE;
		}
	}
	catch (...)
	{
	}
	return (retVal);
}
//=======================================================================================================================
//=======================================================================================================================
//=======================================================================================================================
//http://mathworld.wolfram.com/Point-LineDistance2-Dimensional.html
BOOL CGDIDraw::IsPointOnTheLine(POINTF point, POINTF* line, float distance)
{
	double x0 = point.X;
	double y0 = point.Y;
	double x1 = line[0].X;
	double y1 = line[0].Y;
	double x2 = line[1].X;
	double y2 = line[1].Y;
	//-----------------------------------------
	double distanceFromLine = abs((x2 - x1) * (y1 - y0) - (x1 - x0) * (y2 - y1)) / sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)); //Formula (14).
	//-----------------------------------------
	return (distanceFromLine < distance);
}
float CGDIDraw::DistanceBetweenPoints(POINTF point1, POINTF point2)
{
	return (float)sqrt(pow((double)point2.X - (double)point1.X, 2) + pow((double)point2.Y - (double)point1.Y, 2));
}
BOOL CGDIDraw::IsPointOnThePoint(POINTF point, POINTF pointOfSquare, float distance)
{
	return (DistanceBetweenPoints(point, pointOfSquare) < distance);
}
void CGDIDraw::GetSquarePoints(POINTF center, float diagonal, POINTF* squarePoints)
{
	float sqrt2 = diagonal / (float)sqrt((double)2);
	squarePoints[0].X = center.X - sqrt2; 
	squarePoints[0].Y = center.Y - sqrt2;
	squarePoints[1].X = center.X + sqrt2; 
	squarePoints[1].Y = center.Y - sqrt2;
	squarePoints[2].X = center.X + sqrt2; 
	squarePoints[2].Y = center.Y + sqrt2;
	squarePoints[3].X = center.X - sqrt2; 
	squarePoints[3].Y = center.Y + sqrt2;
}
void CGDIDraw::GetCenterLines(POINTF center, float diagonal, POINTF* centerLines)
{
	centerLines[0].X = center.X - diagonal;
	centerLines[0].Y = center.Y;
	centerLines[1].X = center.X + diagonal;
	centerLines[1].Y = center.Y;
	centerLines[2].X = center.X;
	centerLines[2].Y = center.Y - diagonal;
	centerLines[3].X = center.X;
	centerLines[3].Y = center.Y + diagonal;
}
RECTANGLEF CGDIDraw::GetEllipseRectangleFromCenterAndRadius(POINTF center, float diagonal)
{
	POINTF tempRectPoints[4] = { 0, };
	GetSquarePoints(center, diagonal, tempRectPoints);
	RECTANGLEF tempRect = { 0, };
	tempRect.left = tempRectPoints[0].X;
	tempRect.top = tempRectPoints[0].Y;
	tempRect.right = tempRectPoints[2].X;
	tempRect.bottom = tempRectPoints[2].Y;
	return (tempRect);
}
//http://www.wikihow.com/Find-the-Angle-Between-Two-Vectors
double CGDIDraw::GetAngle(POINTF p0, POINTF center, POINTF p1)
{
	POINTF v = { p0.X - center.X, p0.Y - center.Y };
	POINTF u = { p1.X - center.X, p1.Y - center.Y };
	//------------------------------------------------------
	double IvI = sqrt((v.X * v.X) + (v.Y * v.Y));
	double IuI = sqrt((u.X * u.X) + (u.Y * u.Y));
	//------------------------------------------------------
	double dot_v_u = (v.X * u.X) + (v.Y * u.Y);
	return acos(dot_v_u / (IvI * IuI));
}
POINTF CGDIDraw::Translate_M1P1_0P1(POINTF pt) //Translate from [-1..1] to [0..1].
{
	return{ (pt.X + 1) / 2, (pt.Y + 1) / 2 };
}
POINTF CGDIDraw::Translate_0P1_M1P1(POINTF pt) //Translate from [0..1] to [-1..1].
{
	return{ (pt.X * 2) - 1, (pt.Y * 2) - 1 };
}
POINTF CGDIDraw::Translate_0P1_P10(POINTF pt) //Translate from [0..1] to [1..0].
{
	return{ 1 - pt.X, pt.Y };
}
void CGDIDraw::Translate_0P1_ToRealDimensions(POINTF* pt, int width, int height)
{
	pt->X *= (float)width;
	pt->Y *= (float)height;
}
void CGDIDraw::Translate_0P1_ToRealDimensions(RECTANGLEF* rc, int width, int height)
{
	rc->left *= (float)width;
	rc->top *= (float)height;
	rc->right *= (float)width;
	rc->bottom *= (float)height;
}
//=======================================================================================================================
//=======================================================================================================================
//=======================================================================================================================
VOID CGDIDraw::DrawImage(HWND hwnd, BYTE* data, int width, int height)
{
	try
	{
		RECT rect;
		GetWindowRect(hwnd, &rect);
		SetStretchBltMode(m_HDC, COLORONCOLOR);
		if (m_MemoryDC_Data_Ptr != 0)
		{
			memcpy(m_MemoryDC_Data_Ptr, data, m_bi->bmiHeader.biSizeImage);
		}
		StretchBlt(m_HDC, 0, 0, rect.right - rect.left, rect.bottom - rect.top, m_MemoryDC, 0, 0, width, height, SRCCOPY);
	}
	catch (...)
	{
	}
}

VOID CGDIDraw::DrawInstantMotionAccepted(HWND hwnd, RECTANGLEF* InstantMotionAccepted, int InstantMotionAcceptedCount)
{
	try
	{
		RECT rect;
		GetWindowRect(hwnd, &rect);
		if (InstantMotionAcceptedCount > 0)
		{
			if (InstantMotionAccepted != NULL)
			{
				HGDIOBJ tempObject = SelectObject(m_HDC, m_Pen_InstantMotionAccepted);
				for (int i = 0; i < InstantMotionAcceptedCount; i++)
				{
					POINTF tempPolygonF[5] =
					{
						InstantMotionAccepted[i].left,
						InstantMotionAccepted[i].top,
						InstantMotionAccepted[i].right,
						InstantMotionAccepted[i].top,
						InstantMotionAccepted[i].right,
						InstantMotionAccepted[i].bottom,
						InstantMotionAccepted[i].left,
						InstantMotionAccepted[i].bottom,
						InstantMotionAccepted[i].left,
						InstantMotionAccepted[i].top
					};
					POINT tempPolygon[5] = { 0, };
					for (int j = 0; j < 5; j++)
					{
						Translate_0P1_ToRealDimensions(&tempPolygonF[j], rect.right - rect.left, rect.bottom - rect.top);
						tempPolygon[j] = { tempPolygonF[j].X, tempPolygonF[j].Y };
					}
					Polyline(m_HDC, tempPolygon, 5);
				}
				SelectObject(m_HDC, tempObject);
			}
		}
	}
	catch (...)
	{
	}
}

VOID CGDIDraw::DrawDoubleSquare(HWND hwnd, POINTF centerLocation, float innerSquareDiagonal, float outerSquareDiagonal)
{
	try
	{
		RECT rect;
		GetWindowRect(hwnd, &rect);
		HGDIOBJ tempObject = SelectObject(m_HDC, m_Pen_DoubleSquare);
		//-----------------------------------------------------------------------
		POINTF tempInnerPointsF[5] = { 0, };
		POINTF tempOuterPointsF[5] = { 0, };
		POINT tempInnerPoints[5] = { 0, };
		POINT tempOuterPoints[5] = { 0, };
		RECTANGLEF tempInnerRectanglesF[4] = { 0, };
		RECTANGLEF tempOuterRectanglesF[4] = { 0, };
		POINTF tempCenterLinesF[4] = { 0, };
		POINT tempCenterLines[4] = { 0, };
		//-----------------------------------------------------------------------
		GetSquarePoints(centerLocation, innerSquareDiagonal, tempInnerPointsF);
		memcpy(&tempInnerPointsF[4], &tempInnerPointsF[0], sizeof(POINTF));
		GetSquarePoints(centerLocation, outerSquareDiagonal, tempOuterPointsF);
		memcpy(&tempOuterPointsF[4], &tempOuterPointsF[0], sizeof(POINTF));
		for (int i = 0; i < 4; i++)
		{
			tempInnerRectanglesF[i] = GetEllipseRectangleFromCenterAndRadius(tempInnerPointsF[i], 0.01f);
			tempOuterRectanglesF[i] = GetEllipseRectangleFromCenterAndRadius(tempOuterPointsF[i], 0.01f);
		}
		GetCenterLines(centerLocation, 0.01f, tempCenterLinesF);
		//-----------------------------------------------------------------------
		for (int i = 0; i < 5; i++)
		{
			Translate_0P1_ToRealDimensions(&tempInnerPointsF[i], rect.right - rect.left, rect.bottom - rect.top);
			tempInnerPoints[i] = { tempInnerPointsF[i].X, tempInnerPointsF[i].Y };
			Translate_0P1_ToRealDimensions(&tempOuterPointsF[i], rect.right - rect.left, rect.bottom - rect.top);
			tempOuterPoints[i] = { tempOuterPointsF[i].X, tempOuterPointsF[i].Y };
		}
		for (int i = 0; i < 4; i++)
		{
			Translate_0P1_ToRealDimensions(&tempInnerRectanglesF[i], rect.right - rect.left, rect.bottom - rect.top);
			Translate_0P1_ToRealDimensions(&tempOuterRectanglesF[i], rect.right - rect.left, rect.bottom - rect.top);
		}
		for (int i = 0; i < 4; i++)
		{
			Translate_0P1_ToRealDimensions(&tempCenterLinesF[i], rect.right - rect.left, rect.bottom - rect.top);
			tempCenterLines[i] = { tempCenterLinesF[i].X, tempCenterLinesF[i].Y };
		}
		//-----------------------------------------------------------------------
		Polyline(m_HDC, tempInnerPoints, 5);
		Polyline(m_HDC, tempOuterPoints, 5);
		for (int i = 0; i < 4; i++)
		{
			Ellipse(m_HDC, (int)tempInnerRectanglesF[i].left, (int)tempInnerRectanglesF[i].top, (int)tempInnerRectanglesF[i].right, (int)tempInnerRectanglesF[i].bottom);
			Ellipse(m_HDC, (int)tempOuterRectanglesF[i].left, (int)tempOuterRectanglesF[i].top, (int)tempOuterRectanglesF[i].right, (int)tempOuterRectanglesF[i].bottom);
		}
		Polyline(m_HDC, &tempCenterLines[0], 2);
		Polyline(m_HDC, &tempCenterLines[2], 2);
		//-----------------------------------------------------------------------
		SelectObject(m_HDC, tempObject);
	}
	catch (...)
	{
	}
}

BOOL CGDIDraw::DrawAll(CFFCommon::GDIDrawParams gdiDrawParams)
{
	BOOL retVal = TRUE;
	mCriticalSectionPool->Enter(eCriticalSections::GDIDraw);
	try
	{
		if (AreParamsChanged(gdiDrawParams))
		{
			DeallocateResources();
			AllocateResources(gdiDrawParams);
		}
		//-------------------------------------------------------
		DrawImage(gdiDrawParams.FiltersAndVMDDemoInfo->Draw.Windows.TargetWindow, gdiDrawParams.Data, gdiDrawParams.ColorConversionWidth, gdiDrawParams.ColorConversionHeight);
		if (gdiDrawParams.FiltersAndVMDDemoInfo->Draw.ShowAcceptedObjects)
		{
			DrawInstantMotionAccepted(gdiDrawParams.FiltersAndVMDDemoInfo->Draw.Windows.TargetWindow, gdiDrawParams.InstantMotionAccepted, gdiDrawParams.InstantMotionAcceptedCount);
		}
		if (gdiDrawParams.FiltersAndVMDDemoInfo->Draw.ShowAcceptedObjectsLimitSquares)
		{
			DrawDoubleSquare(gdiDrawParams.FiltersAndVMDDemoInfo->Draw.Windows.TargetWindow, gdiDrawParams.FiltersAndVMDDemoInfo->Draw.DoubleSquare_CenterLocation, gdiDrawParams.FiltersAndVMDDemoInfo->Draw.DoubleSquare_InnerSquareDiagonal, gdiDrawParams.FiltersAndVMDDemoInfo->Draw.DoubleSquare_OuterSquareDiagonal);
		}
		//-------------------------------------------------------
	}
	catch (...)
	{
		retVal = FALSE;
	}
	mCriticalSectionPool->Leave(eCriticalSections::GDIDraw);
	return (retVal);
}