using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class DoubleBufferBitmap
    {
        public DoubleBufferBitmap(Size size)
        {
            _birmaps = new Bitmap[] {
                new Bitmap(size.Width, size.Height),
                new Bitmap(size.Width, size.Height) };
            _graphics = new Graphics[] {
                Graphics.FromImage(_birmaps[0]),
                Graphics.FromImage(_birmaps[1]) };
            _idx = 0;
        }

        public Graphics BufferGraphic { get { return _graphics[1 - _idx]; } }
        public Bitmap ViewBitmap { get { return _birmaps[_idx]; } }

        private Bitmap[] _birmaps;
        private Graphics[] _graphics;
        private int _idx;

        public Bitmap Flip()
        {
            _idx = 1 - _idx;
            return ViewBitmap;
        }

        public void Dispose()
        {
            foreach (var item in _graphics)
            {
                item.Dispose();
            }
            foreach (var item in _birmaps)
            {
                item.Dispose();
            }
        }

    }
}