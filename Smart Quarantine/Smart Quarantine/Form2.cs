using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form2 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        string u;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string user)
        {
            InitializeComponent();
            u = user;
            if (user == "resident")
            {
                panel1.Visible = true;
            }
            else if (user == "visitor")
            {
                panel1.Visible = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Make the form movable
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                button4.PerformClick();
            }
        }

        // Tool tips
        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        // No, then exit the application
        private void button1_Click(object sender, EventArgs e)
        {
            button4.PerformClick();
        }

        // Yes, go back
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(true);
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (u == "resident")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "15");
            }
            else if (u == "visitor")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "12");
            }
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }
    }
}
