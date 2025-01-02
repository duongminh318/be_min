using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession9
{
    public interface IShape
    {
        public double CalculateArea();
        public double CalculatePerimeter();
    }

    public interface IShapeInfo
    {
        public string DisplayArea();
    }

    public class Rectangle : IShape, IShapeInfo
    {
        public double Width {  get; set; }
        public double Height { get; set; }


        public double CalculateArea()
        {
            return Width * Height;  
        }

        public double CalculatePerimeter()
        {
            return 2 * (Height + Width);
        }

        public string DisplayArea()
        {
            return CalculateArea().ToString();
        }
    }
}
