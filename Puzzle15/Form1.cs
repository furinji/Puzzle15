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
    public enum Direction
    {
        None, Up, Down, Left, Right
    }

    public enum LightState
    {
        Off, Soft, Hard
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameManager = new GameManager(this);
            DrawManager = new DrawManager(this);
            PanelTable = new PanelTable(this);
            pictureBox1.Click += new EventHandler(pictureBox1_Click);
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            newGameToolStripMenuItem.Click += new EventHandler(newGameToolStripMenuItem_Click);
            optionToolStripMenuItem.Click += new EventHandler(optionToolStripMenuItem_Click);
        }

        void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOption formOption = new FormOption();
            formOption.CenterPosition = new Point(
                this.Location.X + this.Width / 2,
                this.Location.Y + this.Height / 2);
            formOption.TimesShuffle = TaskShuffle.TimesShuffle;
            formOption.ShowDialog();
            TaskShuffle.TimesShuffle = formOption.TimesShuffle;
        }

        void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameManager.NewGame();
        }

        void pictureBox1_Click(object sender, EventArgs e)
        {
            GameManager.IsClicked = true;
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.GameManager.Didpose();
            this.DrawManager.Dispose();
            //this.PanelTable.Dispose();
        }

        public PictureBox Picbox { get { return pictureBox1; } }
        public ToolStripTextBox TextboxStep { get { return toolStripTextBox_Step; } }
        public GameManager GameManager { get; private set; }
        public DrawManager DrawManager { get; private set; }
        public PanelTable PanelTable { get; private set; }

        public Point MousePosOnPicbox()
        {
            Point mousePos = Control.MousePosition;
            Point picboxPos = pictureBox1.PointToScreen(new Point(0, 0));
            return new Point(mousePos.X - picboxPos.X, 
                mousePos.Y - picboxPos.Y);
        }

    }
}
