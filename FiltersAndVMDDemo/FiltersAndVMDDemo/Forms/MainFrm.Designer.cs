namespace FiltersAndVMDDemo
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.popUpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideOrShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAtStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importVideoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbSource = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tscbURL = new System.Windows.Forms.ToolStripComboBox();
            this.tsbEditCameraList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbConnectDisconnect = new System.Windows.Forms.ToolStripButton();
            this.tsbStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtMinimalVMDObject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chbShowAcceptedObjectsLimitSquares = new System.Windows.Forms.CheckBox();
            this.txtMaximalVMDObject = new System.Windows.Forms.TextBox();
            this.chbShowAcceptedObjects = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bDefaults = new System.Windows.Forms.Button();
            this.txtMaximalAmountOfObjectsToFind = new System.Windows.Forms.TextBox();
            this.txtMinimalDistanceBetweenTwoObjects = new System.Windows.Forms.TextBox();
            this.txtMedianSquare = new System.Windows.Forms.TextBox();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.txtResizeSquare = new System.Windows.Forms.TextBox();
            this.txtAverageBufferSizeInFrames = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbWhatToShowType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMaximalAmountOfObjectsToFind = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMinimalDistanceBetweenTwoObjects = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMedianSquare = new System.Windows.Forms.TrackBar();
            this.tbTolerance = new System.Windows.Forms.TrackBar();
            this.tbResizeSquare = new System.Windows.Forms.TrackBar();
            this.tbAverageBufferSizeInFrames = new System.Windows.Forms.TrackBar();
            this.openVideoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tsbOpenVideoFile = new System.Windows.Forms.ToolStripButton();
            this.caCalibration = new FiltersAndVMDDemo.ucCalibration();
            this.popUpMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaximalAmountOfObjectsToFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinimalDistanceBetweenTwoObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMedianSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbResizeSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAverageBufferSizeInFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // popUpMenu
            // 
            this.popUpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.hideOrShowToolStripMenuItem,
            this.runAtStartupToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.popUpMenu.Name = "popUpMenu";
            this.popUpMenu.Size = new System.Drawing.Size(152, 120);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // hideOrShowToolStripMenuItem
            // 
            this.hideOrShowToolStripMenuItem.Name = "hideOrShowToolStripMenuItem";
            this.hideOrShowToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.hideOrShowToolStripMenuItem.Click += new System.EventHandler(this.hideOrShowToolStripMenuItem_Click);
            // 
            // runAtStartupToolStripMenuItem
            // 
            this.runAtStartupToolStripMenuItem.Name = "runAtStartupToolStripMenuItem";
            this.runAtStartupToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.runAtStartupToolStripMenuItem.Text = "Run at Startup";
            this.runAtStartupToolStripMenuItem.Click += new System.EventHandler(this.runAtStartupToolStripMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // trayNotifyIcon
            // 
            this.trayNotifyIcon.ContextMenuStrip = this.popUpMenu;
            this.trayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayNotifyIcon.Icon")));
            this.trayNotifyIcon.Text = "Show/Hide Alpha Stopper";
            this.trayNotifyIcon.Visible = true;
            this.trayNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayNotifyIcon_MouseClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(907, 24);
            this.menuStrip.TabIndex = 26;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importVideoFileToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importVideoFileToolStripMenuItem
            // 
            this.importVideoFileToolStripMenuItem.Name = "importVideoFileToolStripMenuItem";
            this.importVideoFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.importVideoFileToolStripMenuItem.Text = "Import Video File";
            this.importVideoFileToolStripMenuItem.Click += new System.EventHandler(this.importVideoFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpTopicsToolStripMenuItem,
            this.visitWebsiteToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // helpTopicsToolStripMenuItem
            // 
            this.helpTopicsToolStripMenuItem.Name = "helpTopicsToolStripMenuItem";
            this.helpTopicsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.helpTopicsToolStripMenuItem.Text = "Help Topics";
            this.helpTopicsToolStripMenuItem.Click += new System.EventHandler(this.helpTopicsToolStripMenuItem_Click);
            // 
            // visitWebsiteToolStripMenuItem
            // 
            this.visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            this.visitWebsiteToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.visitWebsiteToolStripMenuItem.Text = "Visit Website";
            this.visitWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitWebsiteToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbSource,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tscbURL,
            this.tsbOpenVideoFile,
            this.tsbEditCameraList,
            this.toolStripSeparator3,
            this.tsbConnectDisconnect,
            this.tsbStatus,
            this.toolStripSeparator4});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(907, 30);
            this.toolStrip.TabIndex = 113;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(71, 27);
            this.toolStripLabel1.Text = "Source Type";
            // 
            // tscbSource
            // 
            this.tscbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbSource.Items.AddRange(new object[] {
            "RTSP Camera",
            "Web Camera",
            "Simulator",
            "Video File"});
            this.tscbSource.Name = "tscbSource";
            this.tscbSource.Size = new System.Drawing.Size(100, 30);
            this.tscbSource.ToolTipText = "Select Video Source";
            this.tscbSource.SelectedIndexChanged += new System.EventHandler(this.tscbSource_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(28, 27);
            this.toolStripLabel2.Text = "URL";
            // 
            // tscbURL
            // 
            this.tscbURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbURL.Name = "tscbURL";
            this.tscbURL.Size = new System.Drawing.Size(300, 30);
            this.tscbURL.ToolTipText = "Select Video URL";
            this.tscbURL.SelectedIndexChanged += new System.EventHandler(this.tscbURL_SelectedIndexChanged);
            // 
            // tsbEditCameraList
            // 
            this.tsbEditCameraList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditCameraList.Image = global::FiltersAndVMDDemo.Properties.Resources.camera;
            this.tsbEditCameraList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditCameraList.Name = "tsbEditCameraList";
            this.tsbEditCameraList.Size = new System.Drawing.Size(28, 27);
            this.tsbEditCameraList.Text = "Edit Camera List";
            this.tsbEditCameraList.Click += new System.EventHandler(this.tsbEditCameraList_Click);
            this.tsbEditCameraList.MouseEnter += new System.EventHandler(this.tsbEditCameraList_MouseEnter);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // tsbConnectDisconnect
            // 
            this.tsbConnectDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbConnectDisconnect.Image = global::FiltersAndVMDDemo.Properties.Resources.play;
            this.tsbConnectDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnectDisconnect.Name = "tsbConnectDisconnect";
            this.tsbConnectDisconnect.Size = new System.Drawing.Size(28, 27);
            this.tsbConnectDisconnect.Click += new System.EventHandler(this.tsbConnectDisconnect_Click);
            this.tsbConnectDisconnect.MouseEnter += new System.EventHandler(this.tsbConnectDisconnect_MouseEnter);
            // 
            // tsbStatus
            // 
            this.tsbStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStatus.Image = global::FiltersAndVMDDemo.Properties.Resources.gray;
            this.tsbStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStatus.Name = "tsbStatus";
            this.tsbStatus.Size = new System.Drawing.Size(28, 27);
            this.tsbStatus.Text = "Show Status";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // txtMinimalVMDObject
            // 
            this.txtMinimalVMDObject.BackColor = System.Drawing.Color.White;
            this.txtMinimalVMDObject.Location = new System.Drawing.Point(108, 340);
            this.txtMinimalVMDObject.Name = "txtMinimalVMDObject";
            this.txtMinimalVMDObject.ReadOnly = true;
            this.txtMinimalVMDObject.Size = new System.Drawing.Size(65, 20);
            this.txtMinimalVMDObject.TabIndex = 140;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 142;
            this.label7.Text = "Minimal VMD Object";
            // 
            // chbShowAcceptedObjectsLimitSquares
            // 
            this.chbShowAcceptedObjectsLimitSquares.AutoSize = true;
            this.chbShowAcceptedObjectsLimitSquares.Location = new System.Drawing.Point(8, 397);
            this.chbShowAcceptedObjectsLimitSquares.Name = "chbShowAcceptedObjectsLimitSquares";
            this.chbShowAcceptedObjectsLimitSquares.Size = new System.Drawing.Size(185, 17);
            this.chbShowAcceptedObjectsLimitSquares.TabIndex = 139;
            this.chbShowAcceptedObjectsLimitSquares.Text = "Show VMD Objects Limit Squares";
            this.chbShowAcceptedObjectsLimitSquares.UseVisualStyleBackColor = true;
            this.chbShowAcceptedObjectsLimitSquares.CheckedChanged += new System.EventHandler(this.chbShowAcceptedObjectsLimitSquares_CheckedChanged);
            // 
            // txtMaximalVMDObject
            // 
            this.txtMaximalVMDObject.BackColor = System.Drawing.Color.White;
            this.txtMaximalVMDObject.Location = new System.Drawing.Point(308, 341);
            this.txtMaximalVMDObject.Name = "txtMaximalVMDObject";
            this.txtMaximalVMDObject.ReadOnly = true;
            this.txtMaximalVMDObject.Size = new System.Drawing.Size(65, 20);
            this.txtMaximalVMDObject.TabIndex = 141;
            // 
            // chbShowAcceptedObjects
            // 
            this.chbShowAcceptedObjects.AutoSize = true;
            this.chbShowAcceptedObjects.Location = new System.Drawing.Point(8, 376);
            this.chbShowAcceptedObjects.Name = "chbShowAcceptedObjects";
            this.chbShowAcceptedObjects.Size = new System.Drawing.Size(119, 17);
            this.chbShowAcceptedObjects.TabIndex = 138;
            this.chbShowAcceptedObjects.Text = "Show VMD Objects";
            this.chbShowAcceptedObjects.UseVisualStyleBackColor = true;
            this.chbShowAcceptedObjects.CheckedChanged += new System.EventHandler(this.chbShowAcceptedObjects_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(133, 425);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 137;
            this.label15.Text = "Filter";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Blur_01",
            "Blur_02 ",
            "Blur_03 ",
            "Motion_Blur",
            "Edges_01",
            "Edges_02",
            "Edges_03",
            "Edges_04",
            "Edges_Prewitt",
            "Edges_Sobel",
            "Edges_Laplacian",
            "Shapen_01",
            "Shapen_02",
            "Shapen_03",
            "Emboss_01",
            "Emboss_02",
            "Mean"});
            this.cbFilter.Location = new System.Drawing.Point(134, 441);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(120, 21);
            this.cbFilter.TabIndex = 136;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 143;
            this.label8.Text = "Maximal VMD Object";
            // 
            // bDefaults
            // 
            this.bDefaults.Location = new System.Drawing.Point(259, 440);
            this.bDefaults.Name = "bDefaults";
            this.bDefaults.Size = new System.Drawing.Size(113, 23);
            this.bDefaults.TabIndex = 135;
            this.bDefaults.Text = "Restore Defaults";
            this.bDefaults.UseVisualStyleBackColor = true;
            this.bDefaults.Click += new System.EventHandler(this.bDefaults_Click);
            // 
            // txtMaximalAmountOfObjectsToFind
            // 
            this.txtMaximalAmountOfObjectsToFind.BackColor = System.Drawing.Color.White;
            this.txtMaximalAmountOfObjectsToFind.Location = new System.Drawing.Point(328, 297);
            this.txtMaximalAmountOfObjectsToFind.Name = "txtMaximalAmountOfObjectsToFind";
            this.txtMaximalAmountOfObjectsToFind.ReadOnly = true;
            this.txtMaximalAmountOfObjectsToFind.Size = new System.Drawing.Size(45, 20);
            this.txtMaximalAmountOfObjectsToFind.TabIndex = 133;
            // 
            // txtMinimalDistanceBetweenTwoObjects
            // 
            this.txtMinimalDistanceBetweenTwoObjects.BackColor = System.Drawing.Color.White;
            this.txtMinimalDistanceBetweenTwoObjects.Location = new System.Drawing.Point(328, 253);
            this.txtMinimalDistanceBetweenTwoObjects.Name = "txtMinimalDistanceBetweenTwoObjects";
            this.txtMinimalDistanceBetweenTwoObjects.ReadOnly = true;
            this.txtMinimalDistanceBetweenTwoObjects.Size = new System.Drawing.Size(45, 20);
            this.txtMinimalDistanceBetweenTwoObjects.TabIndex = 132;
            // 
            // txtMedianSquare
            // 
            this.txtMedianSquare.BackColor = System.Drawing.Color.White;
            this.txtMedianSquare.Location = new System.Drawing.Point(328, 209);
            this.txtMedianSquare.Name = "txtMedianSquare";
            this.txtMedianSquare.ReadOnly = true;
            this.txtMedianSquare.Size = new System.Drawing.Size(45, 20);
            this.txtMedianSquare.TabIndex = 131;
            // 
            // txtTolerance
            // 
            this.txtTolerance.BackColor = System.Drawing.Color.White;
            this.txtTolerance.Location = new System.Drawing.Point(328, 165);
            this.txtTolerance.Name = "txtTolerance";
            this.txtTolerance.ReadOnly = true;
            this.txtTolerance.Size = new System.Drawing.Size(45, 20);
            this.txtTolerance.TabIndex = 130;
            // 
            // txtResizeSquare
            // 
            this.txtResizeSquare.BackColor = System.Drawing.Color.White;
            this.txtResizeSquare.Location = new System.Drawing.Point(328, 121);
            this.txtResizeSquare.Name = "txtResizeSquare";
            this.txtResizeSquare.ReadOnly = true;
            this.txtResizeSquare.Size = new System.Drawing.Size(45, 20);
            this.txtResizeSquare.TabIndex = 129;
            // 
            // txtAverageBufferSizeInFrames
            // 
            this.txtAverageBufferSizeInFrames.BackColor = System.Drawing.Color.White;
            this.txtAverageBufferSizeInFrames.Location = new System.Drawing.Point(328, 77);
            this.txtAverageBufferSizeInFrames.Name = "txtAverageBufferSizeInFrames";
            this.txtAverageBufferSizeInFrames.ReadOnly = true;
            this.txtAverageBufferSizeInFrames.Size = new System.Drawing.Size(45, 20);
            this.txtAverageBufferSizeInFrames.TabIndex = 128;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 425);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 127;
            this.label13.Text = "Frame Type";
            // 
            // cbWhatToShowType
            // 
            this.cbWhatToShowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhatToShowType.FormattingEnabled = true;
            this.cbWhatToShowType.Items.AddRange(new object[] {
            "RGB Frame",
            "VMD Frame",
            "Average Frame",
            "Difference Frame",
            "Tolerance Frame",
            "Median Frame",
            "Border Frame",
            "Filter Frame"});
            this.cbWhatToShowType.Location = new System.Drawing.Point(8, 441);
            this.cbWhatToShowType.Name = "cbWhatToShowType";
            this.cbWhatToShowType.Size = new System.Drawing.Size(120, 21);
            this.cbWhatToShowType.TabIndex = 126;
            this.cbWhatToShowType.SelectedIndexChanged += new System.EventHandler(this.cbWhatToShowType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 13);
            this.label6.TabIndex = 125;
            this.label6.Text = "Maximal Amount Of Objects To Find";
            // 
            // tbMaximalAmountOfObjectsToFind
            // 
            this.tbMaximalAmountOfObjectsToFind.AutoSize = false;
            this.tbMaximalAmountOfObjectsToFind.Location = new System.Drawing.Point(-1, 297);
            this.tbMaximalAmountOfObjectsToFind.Maximum = 200;
            this.tbMaximalAmountOfObjectsToFind.Minimum = 1;
            this.tbMaximalAmountOfObjectsToFind.Name = "tbMaximalAmountOfObjectsToFind";
            this.tbMaximalAmountOfObjectsToFind.Size = new System.Drawing.Size(323, 25);
            this.tbMaximalAmountOfObjectsToFind.TabIndex = 124;
            this.tbMaximalAmountOfObjectsToFind.TickFrequency = 10;
            this.tbMaximalAmountOfObjectsToFind.Value = 1;
            this.tbMaximalAmountOfObjectsToFind.Scroll += new System.EventHandler(this.tbMaximalAmountOfObjectsToFind_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 13);
            this.label5.TabIndex = 123;
            this.label5.Text = "Minimal Distance Between Two Objects";
            // 
            // tbMinimalDistanceBetweenTwoObjects
            // 
            this.tbMinimalDistanceBetweenTwoObjects.AutoSize = false;
            this.tbMinimalDistanceBetweenTwoObjects.Location = new System.Drawing.Point(-1, 253);
            this.tbMinimalDistanceBetweenTwoObjects.Maximum = 200;
            this.tbMinimalDistanceBetweenTwoObjects.Minimum = 1;
            this.tbMinimalDistanceBetweenTwoObjects.Name = "tbMinimalDistanceBetweenTwoObjects";
            this.tbMinimalDistanceBetweenTwoObjects.Size = new System.Drawing.Size(323, 25);
            this.tbMinimalDistanceBetweenTwoObjects.TabIndex = 122;
            this.tbMinimalDistanceBetweenTwoObjects.TickFrequency = 10;
            this.tbMinimalDistanceBetweenTwoObjects.Value = 1;
            this.tbMinimalDistanceBetweenTwoObjects.Scroll += new System.EventHandler(this.tbMinimalDistanceBetweenTwoObjects_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "Median Square";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 120;
            this.label3.Text = "Tolerance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 119;
            this.label2.Text = "Resize Square";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Average Buffer Size In Frames";
            // 
            // tbMedianSquare
            // 
            this.tbMedianSquare.AutoSize = false;
            this.tbMedianSquare.Location = new System.Drawing.Point(-1, 209);
            this.tbMedianSquare.Maximum = 20;
            this.tbMedianSquare.Minimum = 1;
            this.tbMedianSquare.Name = "tbMedianSquare";
            this.tbMedianSquare.Size = new System.Drawing.Size(323, 25);
            this.tbMedianSquare.TabIndex = 117;
            this.tbMedianSquare.Value = 1;
            this.tbMedianSquare.Scroll += new System.EventHandler(this.tbMedianSquare_Scroll);
            // 
            // tbTolerance
            // 
            this.tbTolerance.AutoSize = false;
            this.tbTolerance.Location = new System.Drawing.Point(-1, 165);
            this.tbTolerance.Maximum = 255;
            this.tbTolerance.Minimum = 1;
            this.tbTolerance.Name = "tbTolerance";
            this.tbTolerance.Size = new System.Drawing.Size(323, 25);
            this.tbTolerance.TabIndex = 116;
            this.tbTolerance.TickFrequency = 10;
            this.tbTolerance.Value = 1;
            this.tbTolerance.Scroll += new System.EventHandler(this.tbTolerance_Scroll);
            // 
            // tbResizeSquare
            // 
            this.tbResizeSquare.AutoSize = false;
            this.tbResizeSquare.Location = new System.Drawing.Point(-1, 121);
            this.tbResizeSquare.Maximum = 20;
            this.tbResizeSquare.Minimum = 1;
            this.tbResizeSquare.Name = "tbResizeSquare";
            this.tbResizeSquare.Size = new System.Drawing.Size(323, 25);
            this.tbResizeSquare.TabIndex = 115;
            this.tbResizeSquare.Value = 1;
            this.tbResizeSquare.Scroll += new System.EventHandler(this.tbResizeSquare_Scroll);
            // 
            // tbAverageBufferSizeInFrames
            // 
            this.tbAverageBufferSizeInFrames.AutoSize = false;
            this.tbAverageBufferSizeInFrames.Location = new System.Drawing.Point(-1, 77);
            this.tbAverageBufferSizeInFrames.Maximum = 100;
            this.tbAverageBufferSizeInFrames.Minimum = 1;
            this.tbAverageBufferSizeInFrames.Name = "tbAverageBufferSizeInFrames";
            this.tbAverageBufferSizeInFrames.Size = new System.Drawing.Size(323, 25);
            this.tbAverageBufferSizeInFrames.TabIndex = 114;
            this.tbAverageBufferSizeInFrames.Value = 1;
            this.tbAverageBufferSizeInFrames.Scroll += new System.EventHandler(this.tbAverageBufferSizeInFrames_Scroll);
            // 
            // tsbOpenVideoFile
            // 
            this.tsbOpenVideoFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenVideoFile.Image = global::FiltersAndVMDDemo.Properties.Resources.open_video;
            this.tsbOpenVideoFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenVideoFile.Name = "tsbOpenVideoFile";
            this.tsbOpenVideoFile.Size = new System.Drawing.Size(28, 27);
            this.tsbOpenVideoFile.Text = "Open Video File";
            this.tsbOpenVideoFile.Click += new System.EventHandler(this.tsbOpenVideoFile_Click);
            this.tsbOpenVideoFile.MouseEnter += new System.EventHandler(this.tsbOpenVideoFile_MouseEnter);
            // 
            // caCalibration
            // 
            this.caCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.caCalibration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.caCalibration.Location = new System.Drawing.Point(379, 57);
            this.caCalibration.Name = "caCalibration";
            this.caCalibration.Size = new System.Drawing.Size(523, 405);
            this.caCalibration.TabIndex = 134;
            this.caCalibration.OnDoubleSquareDataChanged += new FiltersAndVMDDemo.ucCalibration.dOnDoubleSquareDataChanged(this.caCalibration_OnDoubleSquareDataChanged);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 467);
            this.Controls.Add(this.txtMinimalVMDObject);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chbShowAcceptedObjectsLimitSquares);
            this.Controls.Add(this.txtMaximalVMDObject);
            this.Controls.Add(this.chbShowAcceptedObjects);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.caCalibration);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bDefaults);
            this.Controls.Add(this.txtMaximalAmountOfObjectsToFind);
            this.Controls.Add(this.txtMinimalDistanceBetweenTwoObjects);
            this.Controls.Add(this.txtMedianSquare);
            this.Controls.Add(this.txtTolerance);
            this.Controls.Add(this.txtResizeSquare);
            this.Controls.Add(this.txtAverageBufferSizeInFrames);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbWhatToShowType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbMaximalAmountOfObjectsToFind);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMinimalDistanceBetweenTwoObjects);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMedianSquare);
            this.Controls.Add(this.tbTolerance);
            this.Controls.Add(this.tbResizeSquare);
            this.Controls.Add(this.tbAverageBufferSizeInFrames);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(923, 506);
            this.Name = "MainFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Move += new System.EventHandler(this.MainFrm_Move);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.popUpMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaximalAmountOfObjectsToFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinimalDistanceBetweenTwoObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMedianSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbResizeSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAverageBufferSizeInFrames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip popUpMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem hideOrShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runAtStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayNotifyIcon;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem helpTopicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox tscbSource;
        private System.Windows.Forms.ToolStripComboBox tscbURL;
        private System.Windows.Forms.ToolStripButton tsbConnectDisconnect;
        private System.Windows.Forms.ToolStripButton tsbStatus;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbEditCameraList;
        private System.Windows.Forms.TextBox txtMinimalVMDObject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbShowAcceptedObjectsLimitSquares;
        private System.Windows.Forms.TextBox txtMaximalVMDObject;
        private System.Windows.Forms.CheckBox chbShowAcceptedObjects;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbFilter;
        private ucCalibration caCalibration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bDefaults;
        private System.Windows.Forms.TextBox txtMaximalAmountOfObjectsToFind;
        private System.Windows.Forms.TextBox txtMinimalDistanceBetweenTwoObjects;
        private System.Windows.Forms.TextBox txtMedianSquare;
        private System.Windows.Forms.TextBox txtTolerance;
        private System.Windows.Forms.TextBox txtResizeSquare;
        private System.Windows.Forms.TextBox txtAverageBufferSizeInFrames;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbWhatToShowType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbMaximalAmountOfObjectsToFind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbMinimalDistanceBetweenTwoObjects;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbMedianSquare;
        private System.Windows.Forms.TrackBar tbTolerance;
        private System.Windows.Forms.TrackBar tbResizeSquare;
        private System.Windows.Forms.TrackBar tbAverageBufferSizeInFrames;
        private System.Windows.Forms.OpenFileDialog openVideoFileDialog;
        private System.Windows.Forms.ToolStripMenuItem importVideoFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbOpenVideoFile;
    }
}

