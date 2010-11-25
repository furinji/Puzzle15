using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class TaskShuffle : ILoopTask
    {
        static TaskShuffle()
        {
            _random = new Random();
            TimesShuffle = 5000;
        }

        public TaskShuffle(Form1 form1)
        {
            _form1 = form1;
            _wait = 10;
            Init();
        }

        public static int TimesShuffle { get; set; }

        private static Random _random;
        private Form1 _form1;
        private bool _isComplete;
        private int _idxX;
        private int _idxY;
        private Direction _lastDirection;
        private int _cnt;
        private int _timesPer;
        private ILightStateInfo[][] _lightPatterns;
        private int _animeCnt;
        private int _wait;
        private int _waitCnt;

        private void Init()
        {
            _timesPer = TimesShuffle / 180;
            if (_timesPer < 1) { _timesPer = 1; }
            else if (_timesPer > 20) { _timesPer = 20; }
            _isComplete = false;
            _form1.PanelTable.Init();
            _lastDirection = Direction.None;
            _idxX = 3;
            _idxY = 3;
            _cnt = 0;
            _animeCnt = 0;
            _waitCnt = 0;
            _lightPatterns = new ILightStateInfo[][]
            {
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(0, 0), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 0), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(0, 1), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 1), LightState.Hard)
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(2, 0), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(3, 0), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 1), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(3, 1), LightState.Hard)
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(2, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(3, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(3, 3), LightState.Hard)
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(0, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(0, 3), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Hard)
                }
            };
        }

        public void DoTask()
        {
            _form1.PanelTable.LightStateInfos.AddInfoItems(_lightPatterns[_animeCnt]);
            if (_waitCnt >= _wait)
            {
                _animeCnt = (_animeCnt + 1) % _lightPatterns.Length;
                _waitCnt = 0;
            }
            else
            {
                _waitCnt += 1;
            }
            for (int i = 0; i < _timesPer; i++)
            {
                if (_cnt >= TimesShuffle)
                {
                    _isComplete = true;
                    return;
                }
                NextShuffle();
                _cnt += 1;
            }
        }

        public bool IsComplete 
        {
            get
            {
                _form1.GameManager.IsGameMode = true;
                return _isComplete;
            }
        }

        private void NextShuffle()
        {
            List<Direction> directions =
                new List<Direction>(){
                    Direction.Up, Direction.Down,
                    Direction.Left, Direction.Right};
            switch (_lastDirection)
            {
                case Direction.Up:
                    directions.Remove(Direction.Down);
                    break;
                case Direction.Down:
                    directions.Remove(Direction.Up);
                    break;
                case Direction.Left:
                    directions.Remove(Direction.Right);
                    break;
                case Direction.Right:
                    directions.Remove(Direction.Left);
                    break;
                default:
                    break;
            }
            if (_idxX < 1)
            {
                directions.Remove(Direction.Left);
            }
            else if (_idxX > 2)
            {
                directions.Remove(Direction.Right);
            }
            if (_idxY < 1)
            {
                directions.Remove(Direction.Up);
            }
            else if (_idxY > 2)
            {
                directions.Remove(Direction.Down);
            }
            int n = _random.Next(directions.Count);
            Direction newDirection = directions[n];
            Point newIdx;
            switch (newDirection)
            {
                case Direction.Up:
                    newIdx = new Point(_idxX, _idxY - 1);
                    break;
                case Direction.Down:
                    newIdx = new Point(_idxX, _idxY + 1);
                    break;
                case Direction.Left:
                    newIdx = new Point(_idxX - 1, _idxY);
                    break;
                case Direction.Right:
                    newIdx = new Point(_idxX + 1, _idxY);
                    break;
                default:
                    newIdx = new Point(_idxX, _idxY);
                    break;
            }
            _form1.PanelTable.ReplacePanel(
                new Point(_idxX, _idxY), newIdx);
            _idxX = newIdx.X;
            _idxY = newIdx.Y;
            _lastDirection = newDirection;
        }

    }
}
