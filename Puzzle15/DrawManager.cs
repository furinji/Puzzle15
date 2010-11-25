using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class DrawManager
    {
        public DrawManager(Form1 form1)
        {
            _form1 = form1;
        }

        private Form1 _form1;
        private DoubleBufferBitmap _dblBufBitmap;
        private PanelImage _panelImage;

        public void Init()
        {
            _dblBufBitmap = new DoubleBufferBitmap(_form1.Picbox.Size);
            _panelImage = new PanelImage();
        }

        public void Redraw()
        {
            _form1.TextboxStep.Text = 
                String.Format("Step : {0}", _form1.GameManager.Step);
            _dblBufBitmap.BufferGraphic.Clear(Color.Black);
            foreach (var panel in _form1.PanelTable.GetPanels())
            {
                if (panel.Number < 1) { continue; }
                LightState lightState = 
                    _form1.PanelTable.LightStateInfos.GetLightState(panel);
                _dblBufBitmap.BufferGraphic.DrawImage(
                    _panelImage.GetImage(lightState, panel.Number),
                    panel.X, panel.Y);
            }
            _form1.Picbox.Image = _dblBufBitmap.Flip();
        }

        public void Dispose()
        {
            _dblBufBitmap.Dispose();
            _panelImage.Dispose();
        }

    }
}
