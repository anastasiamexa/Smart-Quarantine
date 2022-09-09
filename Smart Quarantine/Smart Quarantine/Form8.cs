using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form8 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        string type = "";

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        // Make form movable
        private void Form8_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form8_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form8_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form8_KeyDown(object sender, KeyEventArgs e)
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

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Επιστροφή στο κεντρκό μενού", button1);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πατήστε εδώ για παραγγελία καφέ", pictureBox1);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πατήστε εδώ για παραγγελία φαγητού", pictureBox2);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Μεταφορά στην ιστοσελίδα του Public", pictureBox3);
        }

        // Mouse hovers
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("coffee_hover.png");
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("restaurant_hover.png");
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("public_hover.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("coffee.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("restaurant.png");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("public.png");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.public.gr/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            type = "coffee";
            Form9 f = new Form9(type);
            f.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            type = "food";
            Form9 f = new Form9(type);
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "30");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }
    }
}
