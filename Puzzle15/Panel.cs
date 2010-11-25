using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class Panel
    {
        public Panel(int num)
        {
            Number = num;
        }

        public static readonly int Width = 64;

        public int Number { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int IdxX { get; set; }
        public int IdxY { get; set; }
        public Point Idx
        {
            get
            {
                return new Point(IdxX, IdxY);
            }
        }

        public void SetIdxAndPos(Point idx)
        {
            IdxX = idx.X;
            IdxY = idx.Y;
            X = IdxX * Width;
            Y = IdxY * Width;
        }

    }
}
