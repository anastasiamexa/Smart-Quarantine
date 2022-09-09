using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form6 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        bool flag = false;

        public Form6()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel3.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        // Wants take away
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
        }

        // Makes form movable
        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form6_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form6_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                button4.PerformClick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Image myimage = new Bitmap("background1.jpg");
            this.BackgroundImage = myimage;
            panel3.Visible = true;
            flag = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Image myimage = new Bitmap("background2.jpg");
            this.BackgroundImage = myimage;
            panel3.Visible = true;
            flag = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Image myimage = new Bitmap("background3.jpg");
            this.BackgroundImage = myimage;
            panel3.Visible = true;
            flag = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Tool tips
        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Aποθήκευση της νέας διαδρομής μαζί με το take away", button2);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        // Doesn't want take away
        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            Form7 f = new Form7(flag);
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7(flag);
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
    }
}
