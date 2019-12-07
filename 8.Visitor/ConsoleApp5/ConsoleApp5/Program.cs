using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle(5, 4);
            var circle = new Circle(5);
            var rect = new Rectangle(5, 10);
            var drawVisitor = new DrawVisitor(0, 0);
            var areaVisitor = new GetAreaVisitor();
            var angleVisitor = new GetAngleVisitor();

            triangle.Accept(drawVisitor); // Draw triangle: 0:0
            rect.Accept(angleVisitor); // Angle rect: 90
            circle.Accept(areaVisitor); // Area circle: 157,07963267949



        }
    }
}
