/* 
* FILE          : Line.cs
* PROJECT       : WaMP - Assignment #3
* PROGRAMMER    : Dave Yeardley
* FIRST VERSION : 2012-09-28
* DESCRIPTION   : This project is a simple paint program that uses Windows Forms. It allows
*                 the user to draw line, ellipses and rectangles. The user can change the line
*                 width, colour or fill in the ellipses and rectangles. It also allows for the
*                 saving and loading of images. This file contains the class Line.
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
    * NAME      : Line
    * PURPOSE   : This class is used override the DrawShape method in the 
    *             abstract class Shape so that lines may be drawn. 
    */
    class Line: Shape
    {


        /*
        * METHOD       : DrawShape
        * DESCRIPTION  : This method overrides the method in the base class Shape. It draws a line.
        * PARAMETERS   : Graphics g
        * RETURNS      : none
        */
        public override void DrawShape(Graphics g)
        {
            g.DrawLine(ShapePen, new Point(MouseStart.X, MouseStart.Y), new Point(MouseEnd.X, MouseEnd.Y));

        }
    }
}
