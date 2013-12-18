namespace SETPaint
{
    partial class SETPaint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SETPaint));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tools = new System.Windows.Forms.ToolBar();
            this.open = new System.Windows.Forms.ToolBarButton();
            this.save = new System.Windows.Forms.ToolBarButton();
            this.lineTool = new System.Windows.Forms.ToolBarButton();
            this.rectangle = new System.Windows.Forms.ToolBarButton();
            this.ellipse = new System.Windows.Forms.ToolBarButton();
            this.fillTool = new System.Windows.Forms.ToolBarButton();
            this.colorPicker = new System.Windows.Forms.ToolBarButton();
            this.fillColorPicker = new System.Windows.Forms.ToolBarButton();
            this.clear = new System.Windows.Forms.ToolBarButton();
            this.about = new System.Windows.Forms.ToolBarButton();
            this.undo = new System.Windows.Forms.ToolBarButton();
            this.colors = new System.Windows.Forms.ColorDialog();
            this.widthSelector = new System.Windows.Forms.NumericUpDown();
            this.penWidth = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.penColorBox = new System.Windows.Forms.PictureBox();
            this.penColorLabel = new System.Windows.Forms.Label();
            this.fillColorLabel = new System.Windows.Forms.Label();
            this.fillColorPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillColorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.canvas.Location = new System.Drawing.Point(0, 50);
            this.canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1173, 638);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Folder Open.png");
            this.imageList.Images.SetKeyName(1, "Save File.png");
            this.imageList.Images.SetKeyName(2, "line.png");
            this.imageList.Images.SetKeyName(3, "ellipse-xxl.png");
            this.imageList.Images.SetKeyName(4, "square-icon.png");
            this.imageList.Images.SetKeyName(5, "fill.png");
            this.imageList.Images.SetKeyName(6, "color-picker.jpg");
            this.imageList.Images.SetKeyName(7, "About.png");
            this.imageList.Images.SetKeyName(8, "Eraser-icon.png");
            this.imageList.Images.SetKeyName(9, "fill_color.png");
            this.imageList.Images.SetKeyName(10, "undo_256.png");
            // 
            // tools
            // 
            this.tools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tools.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.open,
            this.save,
            this.lineTool,
            this.rectangle,
            this.ellipse,
            this.fillTool,
            this.colorPicker,
            this.fillColorPicker,
            this.clear,
            this.about,
            this.undo});
            this.tools.ButtonSize = new System.Drawing.Size(100, 100);
            this.tools.DropDownArrows = true;
            this.tools.ImageList = this.imageList;
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tools.Name = "tools";
            this.tools.ShowToolTips = true;
            this.tools.Size = new System.Drawing.Size(1173, 47);
            this.tools.TabIndex = 1;
            this.tools.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tools_ButtonClick);
            // 
            // open
            // 
            this.open.ImageKey = "Folder Open.png";
            this.open.Name = "open";
            this.open.Text = "Open";
            this.open.ToolTipText = "Choose a file to open";
            // 
            // save
            // 
            this.save.ImageKey = "Save File.png";
            this.save.Name = "save";
            this.save.Text = "Save";
            this.save.ToolTipText = "Save your work";
            // 
            // lineTool
            // 
            this.lineTool.ImageKey = "line.png";
            this.lineTool.Name = "lineTool";
            this.lineTool.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.lineTool.Text = "Line";
            this.lineTool.ToolTipText = "Click to draw lines";
            // 
            // rectangle
            // 
            this.rectangle.ImageKey = "square-icon.png";
            this.rectangle.Name = "rectangle";
            this.rectangle.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.rectangle.Text = "Rectangle";
            this.rectangle.ToolTipText = "Click to draw rectangles";
            // 
            // ellipse
            // 
            this.ellipse.ImageKey = "ellipse-xxl.png";
            this.ellipse.Name = "ellipse";
            this.ellipse.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.ellipse.Text = "Ellipse";
            this.ellipse.ToolTipText = "Click to draw ellipses";
            // 
            // fillTool
            // 
            this.fillTool.ImageKey = "fill.png";
            this.fillTool.Name = "fillTool";
            this.fillTool.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.fillTool.Text = "Toggle Fill";
            this.fillTool.ToolTipText = "Toggle fill for rectangles and ellipses";
            // 
            // colorPicker
            // 
            this.colorPicker.ImageKey = "color-picker.jpg";
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Text = "Pen Color";
            this.colorPicker.ToolTipText = "Choose your pen color";
            // 
            // fillColorPicker
            // 
            this.fillColorPicker.ImageKey = "fill_color.png";
            this.fillColorPicker.Name = "fillColorPicker";
            this.fillColorPicker.Text = "Fill Color";
            this.fillColorPicker.ToolTipText = "Choose fill color";
            // 
            // clear
            // 
            this.clear.ImageKey = "Eraser-icon.png";
            this.clear.Name = "clear";
            this.clear.Text = "Clear";
            this.clear.ToolTipText = "Clear the screen";
            // 
            // about
            // 
            this.about.ImageKey = "About.png";
            this.about.Name = "about";
            this.about.Text = "About";
            this.about.ToolTipText = "App information";
            // 
            // undo
            // 
            this.undo.ImageKey = "undo_256.png";
            this.undo.Name = "undo";
            this.undo.Text = "Undo";
            this.undo.ToolTipText = "Take your chance";
            // 
            // widthSelector
            // 
            this.widthSelector.DecimalPlaces = 1;
            this.widthSelector.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.widthSelector.Location = new System.Drawing.Point(898, 15);
            this.widthSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.widthSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthSelector.Name = "widthSelector";
            this.widthSelector.Size = new System.Drawing.Size(69, 22);
            this.widthSelector.TabIndex = 2;
            this.widthSelector.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.widthSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthSelector.ValueChanged += new System.EventHandler(this.widthSelector_ValueChanged);
            // 
            // penWidth
            // 
            this.penWidth.AutoSize = true;
            this.penWidth.Location = new System.Drawing.Point(819, 17);
            this.penWidth.Name = "penWidth";
            this.penWidth.Size = new System.Drawing.Size(73, 17);
            this.penWidth.TabIndex = 3;
            this.penWidth.Text = "Pen Width";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 677);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusBar.Size = new System.Drawing.Size(1173, 22);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "statusBar";
            // 
            // positionTextBox
            // 
            this.positionTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.positionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.positionTextBox.Location = new System.Drawing.Point(48, 677);
            this.positionTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(160, 15);
            this.positionTextBox.TabIndex = 5;
            // 
            // penColorBox
            // 
            this.penColorBox.Location = new System.Drawing.Point(304, 677);
            this.penColorBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.penColorBox.Name = "penColorBox";
            this.penColorBox.Size = new System.Drawing.Size(19, 18);
            this.penColorBox.TabIndex = 6;
            this.penColorBox.TabStop = false;
            // 
            // penColorLabel
            // 
            this.penColorLabel.AutoSize = true;
            this.penColorLabel.Location = new System.Drawing.Point(229, 677);
            this.penColorLabel.Name = "penColorLabel";
            this.penColorLabel.Size = new System.Drawing.Size(70, 17);
            this.penColorLabel.TabIndex = 7;
            this.penColorLabel.Text = "Pen Color";
            // 
            // fillColorLabel
            // 
            this.fillColorLabel.AutoSize = true;
            this.fillColorLabel.Location = new System.Drawing.Point(339, 677);
            this.fillColorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fillColorLabel.Name = "fillColorLabel";
            this.fillColorLabel.Size = new System.Drawing.Size(62, 17);
            this.fillColorLabel.TabIndex = 8;
            this.fillColorLabel.Text = "Fill Color";
            // 
            // fillColorPictureBox
            // 
            this.fillColorPictureBox.Location = new System.Drawing.Point(404, 677);
            this.fillColorPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.fillColorPictureBox.Name = "fillColorPictureBox";
            this.fillColorPictureBox.Size = new System.Drawing.Size(17, 17);
            this.fillColorPictureBox.TabIndex = 9;
            this.fillColorPictureBox.TabStop = false;
            // 
            // SETPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1173, 699);
            this.Controls.Add(this.fillColorPictureBox);
            this.Controls.Add(this.fillColorLabel);
            this.Controls.Add(this.penColorLabel);
            this.Controls.Add(this.penColorBox);
            this.Controls.Add(this.positionTextBox);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.penWidth);
            this.Controls.Add(this.widthSelector);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.canvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SETPaint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SETPaint";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillColorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolBar tools;
        private System.Windows.Forms.ToolBarButton open;
        private System.Windows.Forms.ToolBarButton save;
        private System.Windows.Forms.ToolBarButton rectangle;
        private System.Windows.Forms.ToolBarButton ellipse;
        private System.Windows.Forms.ToolBarButton about;
        private System.Windows.Forms.ToolBarButton lineTool;
        private System.Windows.Forms.ToolBarButton fillTool;
        private System.Windows.Forms.ColorDialog colors;
        private System.Windows.Forms.NumericUpDown widthSelector;
        private System.Windows.Forms.Label penWidth;
        private System.Windows.Forms.ToolBarButton clear;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.PictureBox penColorBox;
        private System.Windows.Forms.Label penColorLabel;
        private System.Windows.Forms.Label fillColorLabel;
        private System.Windows.Forms.PictureBox fillColorPictureBox;
        private System.Windows.Forms.ToolBarButton fillColorPicker;
        private System.Windows.Forms.ToolBarButton penColorPicker;
        private System.Windows.Forms.ToolBarButton colorPicker;
        private System.Windows.Forms.ToolBarButton undo;
    }
}

