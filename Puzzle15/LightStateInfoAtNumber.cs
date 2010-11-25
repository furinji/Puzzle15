using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzle15
{
    public class LightStateInfoAtNumber : ILightStateInfo
    {
        public LightStateInfoAtNumber(int number, LightState lightState)
        {
            _number = number;
            _lightState = lightState;
        }

        private int _number;
        private LightState _lightState;

        public LightState GetLightState(Panel panel)
        {
            if (panel.Number == _number)
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
