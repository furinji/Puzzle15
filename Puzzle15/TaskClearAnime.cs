using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class TaskClearAnime : ILoopTask
    {
        public TaskClearAnime(Form1 form1)
        {
            _form1 = form1;
            _wait = 10;
            _maxAnimeCnt = 60 * 8 / _wait;
            Init();
        }

        private Form1 _form1;
        private bool _isComplete;
        private int _wait;
        private int _waitCnt;
        private int _animeCnt;
        private int _maxAnimeCnt;
        private ILightStateInfo[][] _lightPatterns;

        public void DoTask()
        {
            int n = _animeCnt % _lightPatterns.Length;
            _form1.PanelTable.LightStateInfos.AddInfoItems(_lightPatterns[n]);
            if (_waitCnt >= _wait)
            {
                _waitCnt = 0;
                _animeCnt += 1;
                if (_animeCnt > _maxAnimeCnt) { _isComplete = true; }
            }
            else
            {
                _waitCnt += 1;
            }
        }

        public bool IsComplete
        {
            get
            {
                return _isComplete;
            }
        }

        private void Init()
        {
            _isComplete = false;
            _animeCnt = 0;
            _waitCnt = 0;
            _lightPatterns = new ILightStateInfo[][]
            {
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Hard)
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(1, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Hard)
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(1, 1), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 1), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(0, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Hard)
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(1, 0), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 0), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(0, 1), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 1), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(0, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 2), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Hard)
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(0, 0), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 0), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(0, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 3), LightState.Hard),
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 3), LightState.Hard)
                },
                new ILightStateInfo[] {
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(0, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 3), LightState.Soft)
                },
                new ILightStateInfo[] {
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(0, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 3), LightState.Soft)
                },
                new ILightStateInfo[] {
                },
                new ILightStateInfo[] {
                    new LightStateInfoAtPosition(new Point(0, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 0), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 1), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 2), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(0, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(1, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(2, 3), LightState.Soft),
                    new LightStateInfoAtPosition(new Point(3, 3), LightState.Soft)
                },
                new ILightStateInfo[] {
                }
            };
        }

    }
}
