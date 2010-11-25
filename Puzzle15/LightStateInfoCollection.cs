using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzle15
{
    public class LightStateInfoCollection
    {
        public LightStateInfoCollection()
        {
            _infoList = new List<ILightStateInfo>();
        }

        private List<ILightStateInfo> _infoList;

        public void ClearItems()
        {
            _infoList.Clear();
        }

        public LightState GetLightState(Panel panel)
        {
            LightState resultState = LightState.Off;
            foreach (var item in _infoList)
            {
                LightState tpState = item.GetLightState(panel);
                if (tpState == LightState.Hard)
                {
                    resultState = LightState.Hard;
                    break;
                }
                else if (tpState == LightState.Soft)
                {
                    if (resultState != LightState.Hard)
                    {
                        resultState = LightState.Soft;
                    }
                }
            }
            return resultState;
        }

        public void AddInfoItem(ILightStateInfo infoItem)
        {
            _infoList.Add(infoItem);
        }

        public void AddInfoItems(ILightStateInfo[] infoItems)
        {
            foreach (var item in infoItems)
            {
                _infoList.Add(item);
            }
        }

    }
}
