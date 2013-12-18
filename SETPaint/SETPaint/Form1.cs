//TODO
//About Box for co-ordinates
//Look into toggle buttons for shape and fill
//try on the save as well
//defualt file types for save and open
//add a brush
//add an eraser

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SETPaint
{
    public partial class mainForm : Form
    {

        //constants
        private const int LINE = 1;
        private const int RECT = 2;
        private const int ELLI = 3;
        //attributes
        private int drawShape = LINE;
        private Boolean DrawRubberBand = false;
        private Point MouseStart = new Point(0, 0);
        private Point MouseEnd = new Point(0, 0);
        private Bitmap bmp = null;
        private int PenThickness = 1;
        private Color color = Color.Red;
        private Boolean fill = false;

        public mainForm()
        {
            InitializeComponent();
            bmp = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = bmp;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (DrawRubberBand)
            {
                Pen p = new Pen(color, PenThickness);
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
        
        
        private Rectangle CalculateRectangle()
        {

            Rectangle rect = new Rectangle(Math.Min(MouseEnd.X, MouseStart.X),
                               Math.Min(MouseEnd.Y, MouseStart.Y),
                               Math.Abs(MouseEnd.X - MouseStart.X),
                               Math.Abs(MouseEnd.Y - MouseStart.Y));

            return rect;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            DrawRubberBand = true;
            MouseStart = e.Location;
            MouseEnd = e.Location;

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseEnd = e.Location;
                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            DrawRubberBand = false;
            Graphics gr = Graphics.FromImage(bmp);
            SolidBrush brush = new SolidBrush(color);

            switch (drawShape)
            {
                case LINE:
                    gr.DrawLine(new Pen(color, PenThickness), new Point(MouseStart.X, MouseStart.Y), new Point(MouseEnd.X, MouseEnd.Y));
                    break;
                case RECT:
                    if (fill)
                    {
                        gr.FillRectangle(brush, CalculateRectangle());
                    }
                    else
                    {
                        gr.DrawRectangle(new Pen(color, PenThickness), CalculateRectangle());
                    }
                    break;
                case ELLI:
                    if (fill)
                    {
                        gr.FillEllipse(brush, CalculateRectangle());
                    }
                    else
                    {
                        gr.DrawEllipse(new Pen(color, PenThickness), CalculateRectangle());
                    }
                    break;
                default:
                    break;
            }

            canvas.Invalidate();

        }

        private void tools_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (tools.Buttons.IndexOf(e.Button))
            {
                case 0:
                    OpenFile();
                    break;
                case 1:
                    SaveFile();
                    break;
                case 2:
                    drawShape = LINE;
                    break;
                case 3:
                    drawShape = RECT;
                    break;
                case 4:
                    drawShape = ELLI;
                    break;
                case 5:
                    ToggleFill();
                    break;
                case 6:
                    //color picker
                    DialogResult result = colors.ShowDialog();
                    color = colors.Color;
                    break;
                case 7:
                    ClearScreen();
                    break;
                case 8:
                    
                    break;

            }

        }
        private void ToggleFill()
        {
            //thre is probably a way to use the button state- RESEARCH IT!!!!
            if (fill)
            {
                fill = false;
            }
            else
            {
                fill = true;
            }
        }

        private void widthSelector_ValueChanged(object sender, EventArgs e)
        {
            PenThickness = (int)widthSelector.Value;
        }

        private void SaveFile()
        {
            //find a way to put  a defualt type in
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            String fName = sfd.FileName;

            canvas.Image.Save(sfd.FileName);
        }

        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // bmp = new Bitmap(canvas.Width, canvas.Height);
                    canvas.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    bmp = (Bitmap)canvas.Image;
                    //canvas.Image = new Bitmap(ofd.FileName);
                    this.Controls.Add(canvas);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image" + ex.Message);
                }
            }
        }

        private void ClearScreen()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Clear Screen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                bmp = new Bitmap(canvas.Width, canvas.Height);
                canvas.Image = bmp;
            }
            
        }
        
     }
}

