namespace SETPaint
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tools = new System.Windows.Forms.ToolBar();
            this.open = new System.Windows.Forms.ToolBarButton();
            this.save = new System.Windows.Forms.ToolBarButton();
            this.rectangle = new System.Windows.Forms.ToolBarButton();
            this.ellipse = new System.Windows.Forms.ToolBarButton();
            this.about = new System.Windows.Forms.ToolBarButton();
            this.colorPicker = new System.Windows.Forms.ToolBarButton();
            this.lineTool = new System.Windows.Forms.ToolBarButton();
            this.fillTool = new System.Windows.Forms.ToolBarButton();
            this.colors = new System.Windows.Forms.ColorDialog();
            this.widthSelector = new System.Windows.Forms.NumericUpDown();
            this.penWidth = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(2, 52);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1105, 400);
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
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tools.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.open,
            this.save,
            this.lineTool,
            this.rectangle,
            this.ellipse,
            this.fillTool,
            this.colorPicker,
            this.clear,
            this.about});
            this.tools.ButtonSize = new System.Drawing.Size(69, 69);
            this.tools.DropDownArrows = true;
            this.tools.ImageList = this.imageList;
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.ShowToolTips = true;
            this.tools.Size = new System.Drawing.Size(1107, 52);
            this.tools.TabIndex = 1;
            this.tools.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tools_ButtonClick);
            // 
            // open
            // 
            this.open.ImageKey = "Folder Open.png";
            this.open.Name = "open";
            this.open.Text = "Open";
            // 
            // save
            // 
            this.save.ImageKey = "Save File.png";
            this.save.Name = "save";
            this.save.Text = "Save";
            // 
            // rectangle
            // 
            this.rectangle.ImageKey = "square-icon.png";
            this.rectangle.Name = "rectangle";
            this.rectangle.Text = "Rectangle";
            // 
            // ellipse
            // 
            this.ellipse.ImageKey = "ellipse-xxl.png";
            this.ellipse.Name = "ellipse";
            this.ellipse.Text = "Ellipse";
            // 
            // about
            // 
            this.about.ImageKey = "About.png";
            this.about.Name = "about";
            this.about.Text = "About";
            // 
            // colorPicker
            // 
            this.colorPicker.ImageKey = "color-picker.jpg";
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Text = "Color";
            // 
            // lineTool
            // 
            this.lineTool.ImageKey = "line.png";
            this.lineTool.Name = "lineTool";
            this.lineTool.Text = "Line";
            // 
            // fillTool
            // 
            this.fillTool.ImageKey = "fill.png";
            this.fillTool.Name = "fillTool";
            this.fillTool.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.fillTool.Text = "Fill";
            // 
            // widthSelector
            // 
            this.widthSelector.Location = new System.Drawing.Point(726, 12);
            this.widthSelector.Name = "widthSelector";
            this.widthSelector.Size = new System.Drawing.Size(120, 22);
            this.widthSelector.TabIndex = 2;
            this.widthSelector.ValueChanged += new System.EventHandler(this.widthSelector_ValueChanged);
            // 
            // penWidth
            // 
            this.penWidth.AutoSize = true;
            this.penWidth.Location = new System.Drawing.Point(647, 12);
            this.penWidth.Name = "penWidth";
            this.penWidth.Size = new System.Drawing.Size(73, 17);
            this.penWidth.TabIndex = 3;
            this.penWidth.Text = "Pen Width";
            // 
            // clear
            // 
            this.clear.ImageKey = "Eraser-icon.png";
            this.clear.Name = "clear";
            this.clear.Text = "Clear";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 540);
            this.Controls.Add(this.penWidth);
            this.Controls.Add(this.widthSelector);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.canvas);
            this.Name = "mainForm";
            this.Text = "SETPaint";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSelector)).EndInit();
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
        private System.Windows.Forms.ToolBarButton toggleFill;
        private System.Windows.Forms.ToolBarButton lineTool;
        private System.Windows.Forms.ToolBarButton colorPicker;
        private System.Windows.Forms.ToolBarButton fillTool;
        private System.Windows.Forms.ColorDialog colors;
        private System.Windows.Forms.NumericUpDown widthSelector;
        private System.Windows.Forms.Label penWidth;
        private System.Windows.Forms.ToolBarButton clear;
    }
}

