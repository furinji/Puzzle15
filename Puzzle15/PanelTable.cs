using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class PanelTable
    {
        public PanelTable(Form1 form1)
        {
            _form1 = form1;
            _tableDic = new Dictionary<Point, Panel>();
            _lightStateInfos = new LightStateInfoCollection();
            Init();
        }

        public LightStateInfoCollection LightStateInfos
        {
            get { return _lightStateInfos; }
        }

        private Form1 _form1;
        private Dictionary<Point, Panel> _tableDic;
        private LightStateInfoCollection _lightStateInfos;

        public Panel[] GetPanels()
        {
            return _tableDic.Values.ToArray();
        }

        public Panel GetPanel(Point posIdx)
        {
            return _tableDic[posIdx];
        }

        public void Init()
        {
            _tableDic.Clear();
            for (int i = 0; i < 16; i++)
            {
                int n = (i + 1) % 16;
                int idxX = i % 4;
                int idxY = i / 4;
                Panel panel = new Panel(n);
                panel.SetIdxAndPos(new Point(idxX, idxY));
                _tableDic[new Point(idxX, idxY)] = panel;
            }
        }

        public void TurnOnLight(Point pos)
        {
            bool inRangeX = (0 <= pos.X && pos.X < Panel.Width * 4);
            bool inRangeY = (0 <= pos.Y && pos.Y < Panel.Width * 4);
            if ((inRangeX && inRangeY) == false)
            {
                return;
            }
            int idxX = pos.X / Panel.Width;
            int idxY = pos.Y / Panel.Width;
            Point posIdx = new Point(idxX, idxY);
            Direction movableDirection = GetMovableDirection(posIdx);
            LightState lightState = LightState.Soft;
            if (movableDirection != Direction.None)
            {
                lightState = LightState.Hard;
            }
            _lightStateInfos.AddInfoItem(new LightStateInfoAtNumber(
                _tableDic[posIdx].Number, lightState));
        }

        public Direction GetMovableDirection(Point pos)
        {
            if (_tableDic[pos].Number < 1) { return Direction.None; }
            if (pos.Y > 0 && 
                _tableDic[new Point(pos.X, pos.Y - 1)].Number == 0)
            {
                return Direction.Up;
            }
            else if (pos.X < 3 &&
                _tableDic[new Point(pos.X + 1, pos.Y)].Number == 0)
            {
                return Direction.Right;
            }
            else if (pos.Y < 3 &&
                _tableDic[new Point(pos.X, pos.Y + 1)].Number == 0)
            {
                return Direction.Down;
            }
            else if (pos.X > 0 &&
                _tableDic[new Point(pos.X - 1, pos.Y)].Number == 0)
            {
                return Direction.Left;
            }
            return Direction.None;
        }

        public void ReplacePanel(
            Point panel1Idx, Point panel2Idx)
        {
            Panel panel1 = _tableDic[panel1Idx];
            Panel panel2 = _tableDic[panel2Idx];
            Point pos1 = panel1.Idx;
            Point pos2 = panel2.Idx;
            panel1.SetIdxAndPos(pos2);
            panel2.SetIdxAndPos(pos1);
            _tableDic[panel1Idx] = panel2;
            _tableDic[panel2Idx] = panel1;
        }

        public bool IsClear()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    int num = y * 4 + x + 1;
                    if(num > 15) { num = 0; }
                    Point idx = new Point(x, y);
                    if (_tableDic[idx].Number != num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static Point GetIdx(Point pos)
        {
            return new Point(pos.X / Panel.Width, pos.Y / Panel.Width);
        }

    }
}
