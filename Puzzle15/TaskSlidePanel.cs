using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class TaskSlidePanel : ILoopTask
    {
        public TaskSlidePanel(Point posIdx, Direction direction, Form1 form1)
        {
            _form1 = form1;
            _panel = _form1.PanelTable.GetPanel(posIdx);
            switch (direction)
            {
                case Direction.Up:
                    _endX = _panel.X;
                    _endY = _panel.Y - Panel.Width;
                    _endPosIdx = new Point(_panel.IdxX, _panel.IdxY - 1);
                    break;
                case Direction.Down:
                    _endX = _panel.X;
                    _endY = _panel.Y + Panel.Width;
                    _endPosIdx = new Point(_panel.IdxX, _panel.IdxY + 1);
                    break;
                case Direction.Left:
                    _endX = _panel.X - Panel.Width;
                    _endY = _panel.Y;
                    _endPosIdx = new Point(_panel.IdxX - 1, _panel.IdxY);
                    break;
                case Direction.Right:
                    _endX = _panel.X + Panel.Width;
                    _endY = _panel.Y;
                    _endPosIdx = new Point(_panel.IdxX + 1, _panel.IdxY);
                    break;
                default:
                    _endX = _panel.X;
                    _endY = _panel.Y;
                    _endPosIdx = new Point(_panel.IdxX, _panel.IdxY);
                    break;
            }
            _isComplete = false;
            _speed = 4;
        }

        private Form1 _form1;
        private Panel _panel;
        private bool _isComplete;
        private int _speed;
        private int _endX;
        private int _endY;
        private Point _endPosIdx;

        public void DoTask()
        {
            int difX = _endX - _panel.X;
            int difY = _endY - _panel.Y;
            if (difX < -_speed)
            {
                _panel.X -= _speed;
            }
            else if (difX > _speed)
            {
                _panel.X += _speed;
            }
            else
            {
                _panel.X += difX;
            }
            if (difY < -_speed)
            {
                _panel.Y -= _speed;
            }
            else if (difY > _speed)
            {
                _panel.Y += _speed;
            }
            else
            {
                _panel.Y += difY;
            }
            if (_panel.X == _endX && _panel.Y == _endY)
            {
                _form1.PanelTable.ReplacePanel(_panel.Idx, _endPosIdx);
                _isComplete = true;
            }
            _form1.PanelTable.LightStateInfos.AddInfoItem(
                new LightStateInfoAtNumber(_panel.Number,LightState.Hard));
        }

        public bool IsComplete 
        {
            get
            {
                return _isComplete;
            }
        }
    }
}
