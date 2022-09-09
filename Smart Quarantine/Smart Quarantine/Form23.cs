using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form23 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        string type = "";
        int i = 0, minutes = 0, seconds = 0;

        public Form23()
        {
            InitializeComponent();
        }

        public Form23(string t)
        {
            InitializeComponent();
            type = t;
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form19 f = new Form19();
            f.Show();
            this.Hide();
        }

        // Make form movable
        private void Form23_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form23_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form23_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (type == "doctor")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "55");
            }
            else if (type == "pharmacist")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "52");
            }
            else if (type == "market")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "57");
            }
            else if (type == "other")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "57");
            }
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 5)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
                pictureBox1.Visible = false;
                if (type == "doctor")
                {
                    Image myimage = new Bitmap("video call doctor.png");
                    this.BackgroundImage = myimage;
                }
                else if (type == "pharmacist")
                {
                    Image myimage = new Bitmap("video call pharmacist.png");
                    this.BackgroundImage = myimage;
                }
                else if (type == "market")
                {
                    Image myimage = new Bitmap("video call market.png");
                    this.BackgroundImage = myimage;
                }
                else if (type == "other")
                {
                    Image myimage = new Bitmap("video call.png");
                    this.BackgroundImage = myimage;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            if (seconds < 10)
            {
                if (minutes < 10)
                {
                    label1.Text = "0" + minutes.ToString() + ":0" + seconds.ToString();
                }
                else
                {
                    label1.Text = minutes.ToString() + ":0" + seconds.ToString();
                }
            }
            else
            {
                if (minutes < 10)
                {
                    label1.Text = "0" + minutes.ToString() + ":" + seconds.ToString();
                }
                else
                {
                    label1.Text = minutes.ToString() + ":" + seconds.ToString();
                }
            }
        }
    }
}
