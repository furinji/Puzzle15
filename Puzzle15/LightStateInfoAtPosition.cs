using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class LightStateInfoAtPosition : ILightStateInfo
    {
        public LightStateInfoAtPosition(
            Point position, LightState lightState)
        {
            _position = position;
            _lightState = lightState;
        }

        private Point _position;
        private LightState _lightState;

        public LightState GetLightState(Panel panel)
        {
            if (panel.IdxX == _position.X && panel.IdxY == _position.Y)
            {
                return _lightState;
            }
            else
            {
                return LightState.Off;
            }
        }

    }
}