using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tu.shapes.ClassLibraryShapes
{
    public interface IGraphics
    {
        void DrawRectangle(Color colorBorder, Color? colorFill, float x, float y, float width, float hieght);
        
        void DrawCircle(Color colorBorder, Color? colorFill, float x, float y, float radius);
    }
}
