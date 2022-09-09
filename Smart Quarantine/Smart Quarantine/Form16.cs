using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form16 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        string type = "";
        int j1 = 0, j2 = 0, j3 = 0, j4 = 0, j5 = 0;
        bool tv_livingroom = false, tv_office = false, tv_parents = false;
        bool light_livingroom = false, light_office = false, light_kitchen = false, light_kids = false, light_parents = false;
        bool thermostat = false, tent = true;

        public Form16()
        {
            InitializeComponent();
        }

        public Form16(string t)
        {
            InitializeComponent();
            type = t;
            if (t == "kids")
            {
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            else if (t == "parents")
            {
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
            }
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            circularProgressBar1.Visible = false;
            circularProgressBar2.Visible = false;
            circularProgressBar3.Visible = false;
            circularProgressBar4.Visible = false;
            circularProgressBar5.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label24.Visible = false;
            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            label10.Visible = false;
            label14.Text = "Η τέντα είναι κατεβασμένη";
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

        // Light switch
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (light_livingroom == false)
            {
                pictureBox6.Image = Image.FromFile("light on.png");
                pictureBox5.Image = Image.FromFile("toggle_on(1).png");
                light_livingroom = true;
            }
            else if (light_livingroom == true)
            {
                pictureBox6.Image = Image.FromFile("light off.png");
                pictureBox5.Image = Image.FromFile("toggle_off.png");
                light_livingroom = false;
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (light_kids == false)
            {
                pictureBox21.Image = Image.FromFile("light on.png");
                pictureBox20.Image = Image.FromFile("toggle_on(1).png");
                light_kids = true;
            }
            else if (light_kids == true)
            {
                pictureBox21.Image = Image.FromFile("light off.png");
                pictureBox20.Image = Image.FromFile("toggle_off.png");
                light_kids = false;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (light_office == false)
            {
                pictureBox11.Image = Image.FromFile("light on.png");
                pictureBox10.Image = Image.FromFile("toggle_on(1).png");
                light_office = true;
            }
            else if (light_office == true)
            {
                pictureBox11.Image = Image.FromFile("light off.png");
                pictureBox10.Image = Image.FromFile("toggle_off.png");
                light_office = false;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (light_kitchen == false)
            {
                pictureBox17.Image = Image.FromFile("light on.png");
                pictureBox16.Image = Image.FromFile("toggle_on(1).png");
                light_kitchen = true;
            }
            else if (light_kitchen == true)
            {
                pictureBox17.Image = Image.FromFile("light off.png");
                pictureBox16.Image = Image.FromFile("toggle_off.png");
                light_kitchen = false;
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (light_parents == false)
            {
                pictureBox26.Image = Image.FromFile("light on.png");
                pictureBox25.Image = Image.FromFile("toggle_on(1).png");
                light_parents = true;
            }
            else if (light_parents == true)
            {
                pictureBox26.Image = Image.FromFile("light off.png");
                pictureBox25.Image = Image.FromFile("toggle_off.png");
                light_parents = false;
            }
        }

        // TV switch
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (tv_livingroom == false)
            {
                pictureBox3.Image = Image.FromFile("tv_on.png");
                pictureBox4.Image = Image.FromFile("toggle_on(1).png");
                tv_livingroom = true;
            }
            else if (tv_livingroom == true)
            {
                pictureBox3.Image = Image.FromFile("round_tv_black_48dp.png");
                pictureBox4.Image = Image.FromFile("toggle_off.png");
                tv_livingroom = false;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (tv_office == false)
            {
                pictureBox13.Image = Image.FromFile("tv_on.png");
                pictureBox12.Image = Image.FromFile("toggle_on(1).png");
                tv_office = true;
            }
            else if (tv_office == true)
            {
                pictureBox13.Image = Image.FromFile("round_tv_black_48dp.png");
                pictureBox12.Image = Image.FromFile("toggle_off.png");
                tv_office = false;
            }
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (tv_parents == false)
            {
                pictureBox30.Image = Image.FromFile("tv_on.png");
                pictureBox29.Image = Image.FromFile("toggle_on(1).png");
                tv_parents = true;
            }
            else if (tv_parents == true)
            {
                pictureBox30.Image = Image.FromFile("round_tv_black_48dp.png");
                pictureBox29.Image = Image.FromFile("toggle_off.png");
                tv_parents = false;
            }
        }

        // Other device switch
        // Thermostat
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (thermostat == false)
            {
                pictureBox7.Image = Image.FromFile("temperature.png");
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                label10.Visible = true;
                thermostat = true;
            }
            else if (thermostat == true)
            {
                pictureBox7.Image = Image.FromFile("temperature off.png");
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                label10.Visible = false;
                thermostat = false;
            }
        }

        // Cold
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Image.FromFile("cold.png");
        }

        // Hot
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Image.FromFile("hot.png");
        }

        // Tent
        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (tent == false)
            {
                pictureBox31.Image = Image.FromFile("tent.png");
                label14.Text = "Η τέντα είναι κατεβασμένη";
                tent = true;
            }
            else if (tent == true)
            {
                pictureBox31.Image = Image.FromFile("tent off.png");
                label14.Text = "Η τέντα είναι σηκωμένη";
                tent = false;
            }
        }

        // Vaccum
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            circularProgressBar1.Visible = true;
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(5);
                circularProgressBar1.Value = i;
                circularProgressBar1.Update();
            }
            timer1.Enabled = true;
        }

        // Printer
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox15.Enabled = false;
            circularProgressBar2.Visible = true;
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(5);
                circularProgressBar2.Value = i;
                circularProgressBar2.Update();
            }
            timer2.Enabled = true;
        }

        // Coffee machine
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            pictureBox19.Enabled = false;
            circularProgressBar3.Visible = true;
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(5);
                circularProgressBar3.Value = i;
                circularProgressBar3.Update();
            }
            timer3.Enabled = true;
        }

        // Washing machine
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            pictureBox23.Enabled = false;
            circularProgressBar4.Visible = true;
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(5);
                circularProgressBar4.Value = i;
                circularProgressBar4.Update();
            }
            timer4.Enabled = true;
        }

        // Sprinkler
        private void pictureBox28_Click(object sender, EventArgs e)
        {
            pictureBox28.Enabled = false;
            circularProgressBar5.Visible = true;
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(5);
                circularProgressBar5.Value = i;
                circularProgressBar5.Update();
            }
            timer5.Enabled = true;
        }

        // Camera
        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Form17 f = new Form17(false, 16);
            f.Show();
            this.Hide();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            f.Show();
            this.Hide();
        }

        // Lights
        private void button7_Click(object sender, EventArgs e)
        {
            // Random spawn person at the door
            if (type == "parents")
            {
                Random r = new Random();
                int rInt = r.Next(0, 5);
                if (rInt == 0) // Someone is outside
                {
                    Form18 f = new Form18(true, 16);
                    f.Show();
                    this.Hide();
                }
            }

            panel2.Visible = true;
            if (panel2.Visible)
            {
                button7.BackColor = Color.DarkOrange;
                button8.BackColor = Color.AntiqueWhite;
                button9.BackColor = Color.AntiqueWhite;
                panel3.Visible = false;
                panel4.Visible = false;
            }
        }

        // Tvs
        private void button8_Click(object sender, EventArgs e)
        {
            // Random spawn person at the door
            if (type == "parents")
            {
                Random r = new Random();
                int rInt = r.Next(0, 5);
                if (rInt == 0) // Someone is outside
                {
                    Form18 f = new Form18(true, 16);
                    f.Show();
                    this.Hide();
                }
            }

            panel3.Visible = true;
            if (panel3.Visible)
            {
                button8.BackColor = Color.DarkOrange;
                button7.BackColor = Color.AntiqueWhite;
                button9.BackColor = Color.AntiqueWhite;
                panel2.Visible = false;
                panel4.Visible = false;
            }
        }

        // Other devices
        private void button9_Click(object sender, EventArgs e)
        {
            // Random spawn person at the door
            if (type == "parents")
            {
                Random r = new Random();
                int rInt = r.Next(0, 5);
                if (rInt == 0) // Someone is outside
                {
                    Form18 f = new Form18(true, 16);
                    f.Show();
                    this.Hide();
                }
            }

            panel4.Visible = true;
            if (panel4.Visible)
            {
                button9.BackColor = Color.DarkOrange;
                button7.BackColor = Color.AntiqueWhite;
                button8.BackColor = Color.AntiqueWhite;
                panel2.Visible = false;
                panel3.Visible = false;
            }
        }

        // Timer for vacuum
        private void timer1_Tick(object sender, EventArgs e)
        {
            j1++;
            if (j1 == 2)
            {
                timer1.Enabled = false;
                circularProgressBar1.SubscriptText = "Τέλος!";
                label18.Visible = true;
                label17.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        // Timer for printer
        private void timer2_Tick(object sender, EventArgs e)
        {
            j2++;
            if (j2 == 2)
            {
                timer2.Enabled = false;
                circularProgressBar2.SubscriptText = "Τέλος!";
                label21.Visible = true;
                label20.Visible = true;
            }
        }

        // Timer for coffee machine
        private void timer3_Tick(object sender, EventArgs e)
        {
            j3++;
            if (j3 == 2)
            {
                timer3.Enabled = false;
                circularProgressBar3.SubscriptText = "Τέλος!";
                label24.Visible = true;
                label23.Visible = true;
            }
        }

        // Timer for washing machine
        private void timer4_Tick(object sender, EventArgs e)
        {
            j4++;
            if (j4 == 2)
            {
                timer4.Enabled = false;
                circularProgressBar4.SubscriptText = "Τέλος!";
                label27.Visible = true;
                label26.Visible = true;
            }
        }

        // Timer for sprinkler
        private void timer5_Tick(object sender, EventArgs e)
        {
            j5++;
            if (j5 == 2)
            {
                timer5.Enabled = false;
                circularProgressBar5.SubscriptText = "Τέλος!";
                label29.Visible = true;
                label30.Visible = true;
            }
        }

        // Rooms
        private void button3_Click(object sender, EventArgs e)
        {
            Form15 f = new Form15(type);
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (type == "kids")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "45");
            }
            else if (type == "parents")
            {
                Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "42");
            }
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }

        // Make form movable
        private void Form16_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form16_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form16_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form16_KeyDown(object sender, KeyEventArgs e)
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

        // Mouse hovers
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Ενεργοποίηση σκούπας", pictureBox1);
        }

        private void pictureBox15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Ενεργοποίηση εκτυπωτή", pictureBox15);
        }

        private void pictureBox19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Ενεργοποίηση καφετιέρας", pictureBox19);
        }

        private void pictureBox23_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Ενεργοποίηση πλυντηρίου", pictureBox23);
        }

        private void pictureBox28_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Ενεργοποίηση αυτόματου ποτίσματος", pictureBox28);
        }

        // Tool tips
        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Επιστροφή στην σελίδα του login (Ctrl + Β)", button1);
        }
    }
}
