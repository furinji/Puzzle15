using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puzzle15
{
    public partial class FormOption : Form
    {
        public FormOption()
        {
            InitializeComponent();
            this.Shown += new EventHandler(FormOption_Shown);
            this.FormClosed += new FormClosedEventHandler(FormOption_FormClosed);
            button_Close.Click += new EventHandler(button_Close_Click);
            numericUpDown1.KeyDown += new KeyEventHandler(numericUpDown1_KeyDown);
        }

        void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FormOption_FormClosed(object sender, FormClosedEventArgs e)
        {
            TimesShuffle = (int)numericUpDown1.Value;
        }

        void FormOption_Shown(object sender, EventArgs e)
        {
            int x = CenterPosition.X - this.Width / 2;
            int y = CenterPosition.Y - this.Height / 2;
            this.Location = new Point(x, y);
            Init();
        }

        public int TimesShuffle { get; set; }
        public Point CenterPosition { get; set; }

        private void Init()
        {
            numericUpDown1.Value = (decimal)TimesShuffle;
        }

    }
}
