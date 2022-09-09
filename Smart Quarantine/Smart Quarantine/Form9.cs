using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form9 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        string type = "";

        public Form9()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        public Form9(string t)
        {
            InitializeComponent();
            type = t;
            panel1.Visible = false;
        }

        // Reduce flickering when form loads
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Hide();
        }

        // Make form movable
        private void Form9_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form9_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form9_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                button4.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.B)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        // Tool tips
        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πίσω (Ctrl + Β)", button1);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Συνέχεια (Enter)", button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (type == "coffee")
            {
                Form10 f = new Form10();
                f.Show();
                this.Hide();
            }
            else if (type == "food")
            {
                Form13 f = new Form13();
                f.Show();
                this.Hide();
            }
        }

        // Change image in pictureboxes
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_selected.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            panel1.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox2.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox3.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox4.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox5.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox6.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox7.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox8.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox9.Image = Image.FromFile("baseline_location_on_black_48dp.png");
            pictureBox10.Image = Image.FromFile("baseline_location_on_black_selected.png");
            panel1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (type == "coffee")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "32");
            }
            else if (type == "food")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "35");
            }
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }
    }
}
