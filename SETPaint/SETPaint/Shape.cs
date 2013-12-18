/* 
* FILE          : Shape.cs
* PROJECT       : WaMP - Assignment #3
* PROGRAMMER    : Dave Yeardley
* FIRST VERSION : 2012-09-28
* DESCRIPTION   : This project is a simple paint program that uses Windows Forms. It allows
*                 the user to draw line, ellipses and rectangles. The user can change the line
*                 width, colour or fill in the ellipses and rectangles. It also allows for the
*                 saving and loading of images. This file contains the abstract class Shape.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SETPaint
{
    /*
    * NAME      : Shape
    * PURPOSE   : This class is an abstract base class. All shapes that may be drawn
    *             the program are derived from this class. It is used so that a container
    *             may be used to hold all shapes.             
    */
    abstract class Shape
    {
        /**************************
         *   P R O P E R T I E S  *
         **************************/
        //All the things needed to make the lines and shapes
        public Point MouseStart { get; set; }
        public Point MouseEnd { get; set; }
        public Rectangle ShapeRect { get; set; }
        public Pen ShapePen { get; set; }
        public Brush ShapeBrush { get; set; }

        /*
        * METHOD       : DrawShape
        * DESCRIPTION  : This method will be overridden in derived classes.
        * PARAMETERS   : Graphics g
        * RETURNS      : none
        */
        public abstract void DrawShape(Graphics g);
        
    }
}
