using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Puzzle15
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //
            Form1 form1 = new Form1();
            form1.Show();
            form1.GameManager.Init();
            form1.DrawManager.Init();
            int wait = 1000 / 60;
            int nextFrame = System.Environment.TickCount;
            while (form1.Created)
            {
                int currentTime = System.Environment.TickCount;
                if (currentTime > nextFrame)
                {
                    nextFrame += wait;
                    form1.GameManager.LoopsTick();
                    form1.DrawManager.Redraw();
                }
                Application.DoEvents();
            }
            //
        }
    }
}