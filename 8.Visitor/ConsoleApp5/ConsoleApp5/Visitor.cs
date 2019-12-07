using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public interface IVisitor
    {
        void Visit(Rectangle rect);
        void Visit(Circle circle);
        void Visit(Triangle triangle);
    }
    public class DrawVisitor : IVisitor
    {
        private readonly int _x;
        private readonly int _y;
        public DrawVisitor(int x , int y)
        {
            _x = x;
            _y = y;
        }

        public void Visit(Rectangle rect)
        {
            Console.WriteLine($"Draw rect: {_x}:{_y}");
        }

        public void Visit(Circle circle)
        {
            Console.WriteLine($"Draw circle: {_x}:{_y}");
        }

        public void Visit(Triangle triangle)
        {
            Console.WriteLine($"Draw triangle: {_x}:{_y}");
        }
    }

    public class GetAreaVisitor : IVisitor
    {
        public void Visit(Rectangle rect)
        {
            var width = rect.Width;
            var height = rect.Height;
            Console.WriteLine($"Area rect: {width*height}");
        }

        public void Visit(Circle circle)
        {
            var r = circle.R;
            Console.WriteLine($"Area circle: {2*Math.PI*r*r}");
        }

        public void Visit(Triangle triangle)
        {
            var h = triangle.H;
            var _base = triangle.Base;
            Console.WriteLine($"Area triangle: {0.5*_base*h}");
        }
    }

    public class GetAngleVisitor : IVisitor
    {
        public void Visit(Rectangle rect)
        {
            Console.WriteLine($"Angle rect: {90}");
        }

        public void Visit(Circle circle)
        {
            Console.WriteLine($"Angle circle: {360}");
        }

        public void Visit(Triangle triangle)
        {
            //пускай будет правильный треугольник
            Console.WriteLine($"Angle triangle: {60}");
        }
    }
}
