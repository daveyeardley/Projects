/* 
* FILE          : SETPaint.cs
* PROJECT       : WaMP - Assignment #3
* PROGRAMMER    : Dave Yeardley
* FIRST VERSION : 2012-09-28
* DESCRIPTION   : This project is a simple paint program that uses Windows Forms. It allows
*                 the user to draw line, ellipses and rectangles. The user can change the line
*                 width, colour or fill in the ellipses and rectangles. The user may also undo
*                 actions as well as save or load images.
*/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace SETPaint
{
/*
* NAME      : SETPaint
* PURPOSE   : The SETPaint class is a windows form that provides the GUI for a 
*           simple paint program. The are attributes and methods of this class 
*           are for drawing, clearing, saving and loading images.
*/
    public partial class SETPaint : Form
    {

        
        #region Constants
        /**************************
         *   C O N S T A N T S    *
         **************************/

        // these are used for the specific type of shape to draw 
        private const int LINE = 1;                 // line              
        private const int RECT = 2;                 // rectangle
        private const int ELLI = 3;                 // ellipse

        // this enum is used for the index into the array for the toolbar
        enum toolBarOptions
        {
            OPEN,
            SAVE,
            DRAW_LINE,
            RECTANGLE,
            ELLIPSE,
            FILL,
            PEN_COLOR_PICKER,
            FILL_COLOR_PICKER,
            CLEAR,
            ABOUT,
            UNDO
        }

        #endregion
       
        #region Attributes

        /**************************
        *   A T T R I B U T E S   *
        **************************/
        List<Shape> shapes = new List<Shape>();     // keeps track of all shapes and lines that are on the canvas
        private int drawShape = LINE;               // keeps track of which shape is currently selected to be drawn
        private Boolean drawRubberBand = false;     // keeps track of whether to show rubberBanding and if a rectangle should be calculated
        private Point mouseStart = new Point(0, 0); // the point where the user first left-clicked while drawing
        private Point mouseEnd = new Point(0, 0);   // the point where the click was released
        private Bitmap bmp = null;                  // everything is displayed as a bitmap
        private float penThickness = 1;             // keeps track of line width for lines and border for shapes
        private Color penColor = Color.Red;         // keeps track of pen colour
        private Color fillColor = Color.Red;        // keeps track of fill color
        private Boolean fill = false;               // keeps track of if fill shape setting

        #endregion

        #region Properties

        /**************************
         *   P R O P E R T I E S  *
         **************************/

        public int DrawShape
        {
            get
            {
                return drawShape;
            }
            set
            {
                //check if it's a valid shape
                if (value == LINE || value == RECT || value == ELLI)
                {
                    drawShape = value;
                }
            }
        }

        public Boolean DrawRubberBand
        {
            get
            {
                return drawRubberBand;
            }
            set
            {
                //check for a Boolean state 
                if (value == true || value == false)
                {
                    drawRubberBand = value;
                }
            }
        }

        public Point MouseStart
        {
            get
            {
                return mouseStart;
            }
            set
            {
                //how to validate a point
                mouseStart = value;
            }
        }

        public Point MouseEnd
        {
            get
            {
                return mouseEnd;
            }
            set
            {
                mouseEnd = value;
            }
        }


        public float PenThickness
        {
            get
            {
                return penThickness;
            }
            set 
            {
                //This value has a max and min as specified by the numericupdown
                penThickness = value;
            }
        }

        public Color PenColor
        {
            get
            {
                return penColor;
            }
            set
            {
                //How to validate a color???
                penColor = value;
            }
        }

        public Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
            }
        }

        public Boolean Fill
        {
            get
            {
                return fill;
            }
            set
            {
                if (value == true || value == false)
                {
                    fill = value;
                }
            }
        }

        #endregion

        #region Methods

        /*
         * METHOD       : SETPaint
         * DESCRIPTION  : This is the constructor for SETPaint. A bitmap is allocated on
         *                which lines and shapes will be drawn. Some user feedback elements
         *                are initialized.
         * PARAMETERS   : none
         * RETURNS      : none
         */
        public SETPaint()
        {
            InitializeComponent();
            //prepare the main drawing area
            bmp = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = bmp;
            //name in the title
            this.Text = "Untitled - SETPaint";
            //user feedback for colors and tool
            penColorBox.BackColor = PenColor;               //initial pen color in status bar
            fillColorPictureBox.BackColor = FillColor;      //initial pen color in status bar 
            lineTool.Pushed = true;                         //initial drawing too is line
        }


        /*
         * METHOD       : canvas_Paint
         * DESCRIPTION  : This method is responsible for all drawing on the canvas.
         *                It draws the rubber banding when sizing a line or shape. It then 
         *                redraws the contents of List shapes.
         *        
         * PARAMETERS   : object sender - 
         *                PaintEventArgs e - 
         * RETURNS      : none
         */
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            //draw the shapes and lines
            foreach (Shape shape in shapes)
            {
                shape.DrawShape(e.Graphics);

            }
            //draw the rubber band 
            if (DrawRubberBand)
            {
                Pen p = new Pen(PenColor, penThickness);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                switch (drawShape)
                {
                    case LINE:
                        e.Graphics.DrawLine(p, MouseStart, MouseEnd);
                        break;
                    case RECT:
                        e.Graphics.DrawRectangle(p, CalculateRectangle());
                        break;
                    case ELLI:
                        e.Graphics.DrawEllipse(p, CalculateRectangle());
                        break;
                }
            }
            
            
        }


        /*
         * METHOD       : CalculateRectangle
         * DESCRIPTION  : Calculates the size of the rectangle when drawing an ellipse or rectangle.
         * PARAMETERS   : none
         * RETURNS      : Rectangle rect - the rectangle to draw
         */
        private Rectangle CalculateRectangle()
        {
            
           //get the x and y co-ordinates of where to draw the rectangle 
           //by getting the smaller value of MouseStart and MouseEnd
           //then get the dimensions by getting the absolute value of the difference
            Rectangle rect = new Rectangle(Math.Min(MouseEnd.X, MouseStart.X),
                               Math.Min(MouseEnd.Y, MouseStart.Y),
                               Math.Abs(MouseEnd.X - MouseStart.X),
                               Math.Abs(MouseEnd.Y - MouseStart.Y));

            return rect;
        }


        /*
         * METHOD       : canvas_MouseDown
         * DESCRIPTION  : This method is an event handler for a left-click of the mouse
         *                on the canvas. It sets DrawRubberBand to since the user is drawing 
         *                something and sets the start point 
         * PARAMETERS   : object sender - the canvas is the control here
         *                MouseEventArgs e - contains mouse information about location and clicks
         * RETURNS      : none
         */
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            //mouse clicked on the canvas, means we are drawing something
            DrawRubberBand = true;
            //let's get the location of the mouse
            MouseStart = e.Location;
            //MouseEnd will be updated as the mouse moves see canvas_MouseMove.
            MouseEnd = e.Location;
            
        }


        /*
         * METHOD       : canvas_MouseMove
         * DESCRIPTION  : Gets location information about the mouse when it is
         *                on the canvas and the left button is down. It is used to update
         *                MouseEnd. See canvas_MouseDown.
         * PARAMETERS   : object sender - the canvas is the control here
         *                MouseEventArgs e - contains mouse information about location and clicks
         * RETURNS      : none
         */
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //we are only concerned with the left button being held down
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //update MouseEnd or the end and the beginning will be the same
                MouseEnd = e.Location;
                //let's display the information in the textbox at the bottom of the screen
                positionTextBox.Text ="Position: " + e.Location.ToString();
                //????Why do this????
                canvas.Invalidate();
            }
            else
            {
                //display nothing in the status bar if the left button is not pressed
                positionTextBox.Text = "";
            }
        }


        /*
         * METHOD       : canvas_MouseUp
         * DESCRIPTION  : Draws the actual lines and shapes after the left-button has been released.           
         * PARAMETERS   : object sender - the canvas is the control here
         *                MouseEventArgs e - contains mouse information about location and clicks
         * RETURNS      : none
         */
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            //button is released no need for rubber banding
            DrawRubberBand = false;
            //create the graphics object for drawing the lines and shapes to
            //Graphics gr = Graphics.FromImage(bmp);
            //create the brush object for filling in shapes
            SolidBrush brush = new SolidBrush(FillColor);
            
            //Which shape shall we add to shapes?
            switch (DrawShape)
            {
                case LINE:
                    //it's a line allocate and initialize
                    Line newLine = new Line();
                    newLine.ShapePen = new Pen(PenColor, PenThickness);
                    newLine.MouseStart = new Point(MouseStart.X, MouseStart.Y);
                    newLine.MouseEnd = new Point(MouseEnd.X, MouseEnd.Y);
                    //add it to the list
                    shapes.Add(newLine);
                    break;
                case RECT:
                    //it's a rectangle allocate and initialize
                    MyRectangle newRectangle = new MyRectangle();
                    newRectangle.ShapePen = new Pen(PenColor, PenThickness);
                    newRectangle.ShapeRect = CalculateRectangle();
                    //do we need a fill?
                    if (Fill)
                    {
                        //lets set the brush for the fill
                        newRectangle.ShapeBrush = brush;
                    }
                    //add it to the list
                    shapes.Add(newRectangle);
                    break;
                case ELLI:
                    //it's an ellipse, allocate and initialize
                    MyEllipse newEllipse = new MyEllipse();
                    newEllipse.ShapePen = new Pen(PenColor, PenThickness);
                    newEllipse.ShapeRect = CalculateRectangle();
                    // Do we need a fill?
                    if (Fill)
                    {
                        //let's set the brush for the fill
                        newEllipse.ShapeBrush = brush;
                    }
                    shapes.Add(newEllipse);
                    break;
                default:
                    break;
            }

            canvas.Invalidate();


        }



        /*
         * METHOD       : tools_ButtonClick
         * DESCRIPTION  : Determines the appropriate course of action given a click
         *                of a button on the tool bar.
         * PARAMETERS   : object sender                 -  the toolbar
         *                ToolBarButtonClickEventArgs e - information about which button was clicked
         * RETURNS      : none
         */
        private void tools_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch ((toolBarOptions)tools.Buttons.IndexOf(e.Button))
            {
                case toolBarOptions.OPEN:
                    OpenFile();
                    break;
                case toolBarOptions.SAVE:
                    SaveFile();
                    break;
                case toolBarOptions.DRAW_LINE:
                    drawShape = LINE;
                    rectangle.Pushed = false;
                    ellipse.Pushed = false;
                    fillTool.Pushed = false;
                    Fill = false;
                    //SetDrawShape();
                    break;
                case toolBarOptions.RECTANGLE:
                    drawShape = RECT;
                    lineTool.Pushed = false;
                    ellipse.Pushed = false;
                    //SetDrawShape();
                    break;
                case toolBarOptions.ELLIPSE:
                    drawShape = ELLI;
                    lineTool.Pushed = false;
                    rectangle.Pushed = false;
                    //SetDrawShape();
                    break;
                case toolBarOptions.FILL:
                    ToggleFill();
                    break;
                case toolBarOptions.PEN_COLOR_PICKER:
                    DialogResult result = colors.ShowDialog();
                    PenColor = colors.Color;
                    penColorBox.BackColor = PenColor; 
                    break;
                case toolBarOptions.FILL_COLOR_PICKER:
                    DialogResult fillResult = colors.ShowDialog();
                    FillColor = colors.Color;
                    fillColorPictureBox.BackColor = FillColor;
                    break;
                case toolBarOptions.CLEAR:
                    ClearScreen();
                    break;
                case toolBarOptions.ABOUT:
                    AboutBox about = new AboutBox();
                    about.Show();
                    break;
                case toolBarOptions.UNDO:
                    //make sure there are shapes to undo
                    if (shapes.Count > 0)
                    {
                        //OK, we can remove the most recent shape
                        shapes.RemoveAt(shapes.Count - 1);
                    }
                    else
                    {
                        MessageBox.Show("There is nothing to undo!");
                    }
                    //force a redrawing of the canvas
                    canvas.Invalidate();
                    break;
                default:
                    break;

            }

        }


        /*
        * METHOD       : SetDrawShape
        * DESCRIPTION  : Sets the draw shape based on the state of the button pressed on
        *                on the toolbar. Also untoggles the other shape buttons. 
        * PARAMETERS   : none
        * RETURNS      : none
        */
        private void SetDrawShape()
        {
            if (lineTool.Pushed)
            {
                //set shape
                DrawShape = LINE;
                //untoggle the other buttons
                rectangle.Pushed = false;
                ellipse.Pushed = false;
            }
            else if (rectangle.Pushed)
            {
                //set shape
                DrawShape = RECT;
                //untoggle the other buttons
                lineTool.Pushed = false;
                ellipse.Pushed = false;
            }
            else if (ellipse.Pushed)
            {
                //set shape
                DrawShape = ELLI;
                //untoggle the other buttons
                lineTool.Pushed = false;
                rectangle.Pushed = false;
            }
        }

        /*
         * METHOD       : ToggleFill
         * DESCRIPTION  : Reads the state of toggleFill in the tool bar to change
         *                the fill to the same state as the button.
         * PARAMETERS   : none
         * RETURNS      : none
         */
        private void ToggleFill()
        {
            if (drawShape != LINE)
            {
                if (fillTool.Pushed)
                {
                    Fill = true;
                }
                else
                {
                    Fill = false;
                }
            }
            else
            {
                fillTool.Pushed = false;
            }
        }



        /*
         * METHOD       : widthSelector_ValueChanged
         * DESCRIPTION  : The pen width has been adjust using the numeric up and down on the 
         *                the form. This method will update penThickness accordingly.
         * PARAMETERS   : object sender- 
         *                EventArgs e - we are concerned the value from the numericUpDown
         * RETURNS      : none
         */
        private void widthSelector_ValueChanged(object sender, EventArgs e)
        {
            //cast the numericUpDown Decimal as a float
            float newWidth = (float)widthSelector.Value;
            //set the width of the pen/border
            PenThickness = newWidth;
        }


        #region FileIO
        /*
         * METHOD       : SaveFile
         * DESCRIPTION  : Opens and SaveFileDialog that allows the user to save the image
         *                on the canvas to a file.
         * PARAMETERS   : none
         * RETURNS      : none
         */
        private void SaveFile()
        {

            //create a SaveFileDialog object
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP Files (*.bmp)|*.bmp |JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            sfd.Title = "Choose a save location";
            sfd.FileName = "myDrawing";
            sfd.DefaultExt = "bmp";
            Graphics gr  = Graphics.FromImage(bmp);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.Text = sfd.FileName + " - SETPaint";
                //the actions in the SaveFileDialog are OK
                try
                {
                    
                    foreach (Shape shape in shapes)
                    {
                        shape.DrawShape(gr);

                    }
                    
                    bmp.Save(sfd.FileName);
                    //canvas.Image.Save(sfd.FileName);
                }
                catch (Exception ex)
                {
                    //something went wrong notify the user of the exception
                    MessageBox.Show("Error saving image " + ex.Message);
                }
            }
            
        }

        


        /*
         * METHOD       : OpenFile
         * DESCRIPTION  : Allows the user to choose and image to load from a file then
         *                displays it on the canvas so it may be worked on some more
         * PARAMETERS   : none
         * RETURNS      : none
         */
        private void OpenFile()
        {
            //create an OpenFileDialog object
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BMP Files (*.bmp)|*.bmp|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            ofd.Title = "Choose a file to open";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //all is well let's try to open the file
                try
                {
                    this.Text = ofd.FileName + " - SETPaint";
                    canvas.Image = new Bitmap(ofd.OpenFile());
                    bmp.Dispose();
                    bmp = (Bitmap)canvas.Image;
                    ofd.Dispose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image " + ex.Message);
                }

            }

        }

        #endregion

        /*
         * METHOD       : ClearScreen
         * DESCRIPTION  : Clears the screen if the user confirms the action via a MessageBox.
         * PARAMETERS   : none
         * RETURNS      : none
         */
        private void ClearScreen()
        {
            //Let's confirm
            DialogResult confirm = MessageBox.Show("Are you sure?", "Clear Screen", MessageBoxButtons.YesNo);
            //Did the user say confirm?
            if (confirm == DialogResult.Yes)
            {
                //let's delete shapes list
                shapes.Clear();
                //Out with the old
                bmp.Dispose();
                //and in with the new
                bmp = new Bitmap(canvas.Width, canvas.Height);
                canvas.Image = bmp;
            }

        }

        #endregion

    }
}

