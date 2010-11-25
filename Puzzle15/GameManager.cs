using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Puzzle15
{
    public class GameManager
    {
        public GameManager(Form1 form1)
        {
            _form1 = form1;
            _taskList = new TaskList();
            Init();
        }

        public bool IsClicked { get; set; }
        public bool IsGameMode { get; set; }
        public int Step { get; set; }

        private Form1 _form1;
        private TaskList _taskList;

        public void Init()
        {
            IsClicked = false;
            IsGameMode = false;
            Step = 0;
        }
        
        public void LoopsTick()
        {
            bool isClicked = IsClicked;
            IsClicked = false;
            _form1.PanelTable.LightStateInfos.ClearItems();
            if (_taskList.DoTask()) { return; }
            if (IsGameMode == false) { return; }
            if (CheckClear())
            {
                IsGameMode = false;
                return;
            }
            Point mousePos = _form1.MousePosOnPicbox();
            if (isClicked)
            {
                Point mousePosIdx = PanelTable.GetIdx(mousePos);
                Direction direction =
                    _form1.PanelTable.GetMovableDirection(mousePosIdx);
                if (direction != Direction.None)
                {
                    SlidePanel(mousePosIdx, direction);
                    return;
                }
            }
            _form1.PanelTable.TurnOnLight(mousePos);
        }

        public void NewGame()
        {
            Step = 0;
            _taskList.AddTask(new TaskShuffle(_form1));
        }

        private bool CheckClear()
        {
            if (_form1.PanelTable.IsClear())
            {
                _taskList.AddTask(
                    new TaskClearAnime(_form1));
                return true;
            }
            return false;
        }

        private void SlidePanel(Point mousePosIdx, Direction direction)
        {
            Step += 1;
            _taskList.AddTask(new TaskSlidePanel(
                mousePosIdx, direction, _form1));
            _form1.PanelTable.LightStateInfos.AddInfoItem(
                new LightStateInfoAtNumber(
                    _form1.PanelTable.GetPanel(mousePosIdx).Number,
                    LightState.Hard));
        }

    }
}
