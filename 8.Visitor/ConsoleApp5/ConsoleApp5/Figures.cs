using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface Figures
    {
        void Accept(IVisitor visitor);
    }

    public class Rectangle : Figures
    {
        private readonly int _width;
        private readonly int _height;
        public Rectangle(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int Height => _height;
        public int Width => _width;
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Circle : Figures
    {
        private readonly int _r;
        public Circle(int r)
        {
            _r = r;
        }
        public int R => _r;

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Triangle : Figures
    {
        private readonly int _base;
        private readonly int _h;
        public Triangle(int base_, int h)
        {
            _base = base_;
            _h = h;
        }
        public int H => _h;
        public int Base => _base;
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
