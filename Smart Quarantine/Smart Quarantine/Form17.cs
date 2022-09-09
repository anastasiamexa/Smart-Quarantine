using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form17 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        bool visitor;
        int form = 0;

        public Form17()
        {
            InitializeComponent();
        }

        public Form17(bool v, int f)
        {
            InitializeComponent();
            visitor = v;
            form = f;
            if (visitor) // Someone is outside
            {
                Random r = new Random();
                int rInt = r.Next(0, 3);
                if (rInt == 0)
                {
                    Image myimage = new Bitmap("delivery.png");
                    this.BackgroundImage = myimage;
                }
                else if (rInt == 1)
                {
                    Image myimage = new Bitmap("delivery_food.png");
                    this.BackgroundImage = myimage;
                }
                else if (rInt == 2)
                {
                    Image myimage = new Bitmap("delivery_groceries.png");
                    this.BackgroundImage = myimage;
                }
                panel1.Visible = true;
                Random r1 = new Random();
                int r1Int = r1.Next(0, 3);
                if (r1Int == 0 || r1Int == 1) // Normal temperature
                {
                    label2.Text = "κανονική.";
                    button3.Visible = true;
                }
                else if (r1Int == 2) // High temperature
                {
                    label2.Text = "υψηλή.";
                    panel3.Visible = true;
                }
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (form == 15)
            {
                Form15 f = new Form15("parents");
                f.Show();
                this.Hide();
            }
            else if (form == 16)
            {
                Form16 f = new Form16("parents");
                f.Show();
                this.Hide();
            }
        }

        private void Form17_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form17_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form17_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                button4.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.B)
            {
                button1.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Παραλάβατε την παραγγελία σας!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Image myimage = new Bitmap("outside.png");
            this.BackgroundImage = myimage;
            panel1.Visible = false;
            panel2.Visible = true;
            button3.Visible = false;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πίσω (Ctrl + Β)", button1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "42");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }
    }
}
