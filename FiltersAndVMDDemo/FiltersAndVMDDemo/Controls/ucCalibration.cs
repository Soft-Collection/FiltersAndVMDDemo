using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiltersAndVMDDemo
{
    public partial class ucCalibration : UserControl
    {
        #region Inner Classes
        #endregion

        #region Delegates
        public delegate void dOnDoubleSquareDataChanged(clsGraphicsDoubleSquare.DoubleSquareData doubleSquareData);
        #endregion

        #region Events
        public event dOnDoubleSquareDataChanged OnDoubleSquareDataChanged = null;
        #endregion

        #region Enums
        #endregion

        #region Variables
        private clsGraphicsDoubleSquare mDoubleSquare = null;
        private clsDevice mDevice = null;
        #endregion

        #region Properties
        public IntPtr CalibrationWindowHandle
        {
            get
            {
                return (pbCalibrationWindow.Handle);
            }
        }
        #endregion

        #region Constructor / Destructor
        public ucCalibration()
        {
            InitializeComponent();
            //-----------------------------------------------------
            mDoubleSquare = new clsGraphicsDoubleSquare();
            mDoubleSquare.OnCursorChanged += mDoubleSquare_OnCursorChanged;
            mDoubleSquare.OnRefreshNeeded += mDoubleSquare_OnRefreshNeeded;
            mDoubleSquare.OnDoubleSquareDataChanged += mDoubleSquare_OnDoubleSquareDataChanged;
            mDoubleSquare.OnDoubleSquareGraphicsChanged += mDoubleSquare_OnDoubleSquareGraphicsChanged;
            //-----------------------------------------------------
        }
        #endregion

        #region Methods
        public void SetDevice(clsDevice device)
        {
            mDevice = device;
        }
        public void UpdateControls()
        {
            if (mDevice != null)
            {
                clsGraphicsDoubleSquare.DoubleSquareData doubleSquareData = new clsGraphicsDoubleSquare.DoubleSquareData();
                doubleSquareData.Center = mDevice.Draw_DoubleSquare_CenterLocation;
                doubleSquareData.InnerDiagonal = mDevice.Draw_DoubleSquare_InnerSquareDiagonal;
                doubleSquareData.OuterDiagonal = mDevice.Draw_DoubleSquare_OuterSquareDiagonal;
                //----------------------------------------------------------------------------------------
                clsGraphicsDoubleSquare.DoubleSquareConfig doubleSquareConfig = new clsGraphicsDoubleSquare.DoubleSquareConfig();
                doubleSquareConfig.CenterDiagonal = 0.01f;
                doubleSquareConfig.LineThickness = 1;
                doubleSquareConfig.LineColor = Color.Yellow;
                doubleSquareConfig.CornerCircleRadiusDiagonal = 0.01f;
                doubleSquareConfig.CornerCircleBorderThickness = 1;
                doubleSquareConfig.CornerCircleBorderColor = Color.Yellow;
                doubleSquareConfig.CornerCircleFillColor = Color.Black;
                //----------------------------------------------------------------------------------------
                if (mDoubleSquare != null)
                {
                    mDoubleSquare.SetDoubleSquareData(doubleSquareData);
                }
                //----------------------------------------------------------------------------------------
            }
        }
        public void ApplyDefaults()
        {
            mDevice.Draw_DoubleSquare_CenterLocation = new PointF(0.5f, 0.5f);
            //----------------------------------------------------------------------------------------
            mDevice.Draw_DoubleSquare_InnerSquareDiagonal = 0.02f / (float)Math.Sqrt(2);
            mDevice.Draw_DoubleSquare_OuterSquareDiagonal = 0.05f / (float)Math.Sqrt(2);
        }
        public void OnTimer()
        {
            //------------------------------------------------------------
            InvalidateAndRefresh();
        }
        private void mDoubleSquare_OnRefreshNeeded()
        {
            InvalidateAndRefresh();
        }
        private void mDoubleSquare_OnCursorChanged(Cursor cursor)
        {
            Cursor = cursor;
        }
        void mDoubleSquare_OnDoubleSquareDataChanged(clsGraphicsDoubleSquare.DoubleSquareData doubleSquareData)
        {
            if (mDevice != null)
            {
                mDevice.Draw_DoubleSquare_CenterLocation = doubleSquareData.Center;
                mDevice.Draw_DoubleSquare_InnerSquareDiagonal = doubleSquareData.InnerDiagonal;
                mDevice.Draw_DoubleSquare_OuterSquareDiagonal = doubleSquareData.OuterDiagonal;
                if (OnDoubleSquareDataChanged != null)
                {
                    OnDoubleSquareDataChanged(doubleSquareData);
                }
            }
        }
        void mDoubleSquare_OnDoubleSquareGraphicsChanged(clsGraphicsDoubleSquare.DoubleSquareData doubleSquareData)
        {
            if (mDevice != null)
            {
                mDevice.Set_Draw_DoubleSquare(doubleSquareData.Center, doubleSquareData.InnerDiagonal, doubleSquareData.OuterDiagonal);
            }
        }
        private void pbCalibrationWindow_MouseDown(object sender, MouseEventArgs e)
        {
            mDoubleSquare.OnMouseDown((float)e.X / (float)pbCalibrationWindow.Width, (float)e.Y / (float)pbCalibrationWindow.Height);
        }
        private void pbCalibrationWindow_MouseUp(object sender, MouseEventArgs e)
        {
            mDoubleSquare.OnMouseUp((float)e.X / (float)pbCalibrationWindow.Width, (float)e.Y / (float)pbCalibrationWindow.Height);
        }
        private void pbCalibrationWindow_MouseMove(object sender, MouseEventArgs e)
        {
            mDoubleSquare.OnMouseMove((float)e.X / (float)pbCalibrationWindow.Width, (float)e.Y / (float)pbCalibrationWindow.Height);
        }
        private void pbCalibrationWindow_Paint(object sender, PaintEventArgs e)
        {
            if (mDevice != null)
            {
                Bitmap bmp = mDevice.GetRGBPicture(true);
                if (bmp != null)
                {
                    e.Graphics.DrawImage(bmp, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                    bmp.Dispose();
                    bmp = null;
                }
            }
            mDoubleSquare.OnPaint(e.Graphics, this.Width, this.Height);
        }
        private void ucCalibration_Resize(object sender, EventArgs e)
        {
            InvalidateAndRefresh();
        }
        private void InvalidateAndRefresh()
        {
            bool use = false;
            if (use)
            {
                pbCalibrationWindow.Invalidate();
                pbCalibrationWindow.Refresh();
            }
        }
        #endregion
    }
}
