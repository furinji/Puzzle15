using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class PanelImage
    {
        public PanelImage()
        {
            SetImages();
        }

        private Image[] _normalImgs;
        private Image[] _sofLightImgs;
        private Image[] _hardLightImgs;

        public Image GetImage(LightState lightState, int num)
        {
            switch (lightState)
            {
                case LightState.Off:
                    return _normalImgs[num];
                case LightState.Soft:
                    return _sofLightImgs[num];
                case LightState.Hard:
                    return _hardLightImgs[num];
                default:
                    return null;
            }
        }

        public void Dispose()
        {
            foreach (var item in _normalImgs)
            {
                item.Dispose();
            }
            foreach (var item in _sofLightImgs)
            {
                item.Dispose();
            }
            foreach (var item in _hardLightImgs)
            {
                item.Dispose();
            }
        }

        private void SetImages()
        {
            _normalImgs = new Image[16];
            _sofLightImgs = new Image[16];
            _hardLightImgs = new Image[16];
            for (int i = 0; i < 16; i++)
            {
                int n = (i + 1) % 16;
                int x = (i % 4) * Panel.Width;
                int y = (i / 4) * Panel.Width;
                _normalImgs[n] = TrimImage(
                    Properties.Resources._15PuzzlePanel, x, y);
                _sofLightImgs[n] = TrimImage(
                    Properties.Resources._15PuzzlePanel_light, x, y);
                _hardLightImgs[n] = TrimImage(
                    Properties.Resources._15PuzzlePanel_HardLight, x, y);
            }
        }

        private Image TrimImage(Bitmap srcBitmap, int x, int y)
        {
            Bitmap bm = new Bitmap(Panel.Width, Panel.Width);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(srcBitmap,
                    new Rectangle(0, 0, bm.Width, bm.Height),
                    new Rectangle(x, y, bm.Width, bm.Height),
                    GraphicsUnit.Pixel);
            }
            return bm;
        }

    }
}
