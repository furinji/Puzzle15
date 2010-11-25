using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzle15
{
    public class TaskList
    {
        public TaskList()
        {
            _taskList = new List<ILoopTask>();
        }

        private List<ILoopTask> _taskList;

        public void AddTask(ILoopTask task)
        {
            _taskList.Add(task);
        }

        public bool DoTask()
        {
            while (_taskList.Count > 0)
            {
                if (_taskList[0].IsComplete == false)
                {
                    _taskList[0].DoTask();
                    return true;
                }
                _taskList.RemoveAt(0);
            }
            return false;
        }

    }
}
