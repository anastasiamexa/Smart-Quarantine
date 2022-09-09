using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form7 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        int i = 0, seconds = 7;

        public Form7()
        {
            InitializeComponent();
        }

        public Form7(bool flag)
        {
            InitializeComponent();
            panel1.Visible = flag;
            if (flag == false)
            {
                timer1.Enabled = true;
                panel2.Visible = true;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Make form movable
        private void Form7_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form7_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form7_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form7_KeyDown(object sender, KeyEventArgs e)
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

        // Home menu
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "25");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            seconds--;
            label4.Text = seconds.ToString() + " δευτερόλεπτα";
            if (i == 7) // After 7 seconds go to home menu
            {
                timer1.Enabled = false;
                Form3 f = new Form3();
                f.Show();
                this.Hide();
            }
        }
    }
}
