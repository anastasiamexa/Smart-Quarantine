using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form15 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        string type = "";
        int j1 = 0, j2 = 0, j3 = 0, j4 = 0, j5 = 0;
        bool tv_livingroom = false, tv_office = false, tv_parents = false;
        bool light_livingroom = false, light_office = false, light_kitchen = false, light_kids = false, light_parents = false;
        bool thermostat = false, tent = true;

        public Form15()
        {
            InitializeComponent();
        }

        public Form15(string t)
        {
            InitializeComponent();
            type = t;
            if (t == "kids")
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox7.Enabled = false;
                groupBox8.Enabled = false;
                pictureBox33.Image = Image.FromFile("office_kids.png");
                pictureBox34.Image = Image.FromFile("kitchen_kids.png");
                pictureBox36.Image = Image.FromFile("bedroom_kids.png");
                pictureBox37.Image = Image.FromFile("backyard_kids.png");
                pictureBox38.Image = Image.FromFile("bathroom_kids.png");
                pictureBox39.Image = Image.FromFile("entrance_kids.png");
            }
            circularProgressBar1.Visible = false;
            circularProgressBar2.Visible = false;
            circularProgressBar3.Visible = false;
            circularProgressBar4.Visible = false;
            circularProgressBar5.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            label13.Visible = false;
            label12.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            label1.Visible = false;
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

        // Camera
        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Form17 f = new Form17(false, 15);
            f.Show();
            this.Hide();
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

        // Thermostat
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (thermostat == false)
            {
                pictureBox7.Image = Image.FromFile("temperature.png");
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                label1.Visible = true;
                thermostat = true;
            }
            else if (thermostat == true)
            {
                pictureBox7.Image = Image.FromFile("temperature off.png");
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                label1.Visible = false;
                thermostat = false;
            }
        }

        // Hot
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Image.FromFile("hot.png");
        }

        // Cold
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Image.FromFile("cold.png");
        }

        // Tv switch
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Random spawn person at the door
            if (type == "parents")
            {
                Random r = new Random();
                int rInt = r.Next(0, 10);
                if (rInt == 0) // Someone is outside
                {
                    Form18 f = new Form18(true, 15);
                    f.Show();
                    this.Hide();
                }
            }

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
            // Random spawn person at the door
            Random r = new Random();
            int rInt = r.Next(0, 10);
            if (rInt == 0) // Someone is outside
            {
                Form18 f = new Form18(true, 15);
                f.Show();
                this.Hide();
            }

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
            // Random spawn person at the door
            Random r = new Random();
            int rInt = r.Next(0, 10);
            if (rInt == 0) // Someone is outside
            {
                Form18 f = new Form18(true, 15);
                f.Show();
                this.Hide();
            }

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

        // Light switch
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // Random spawn person at the door
            if (type == "parents")
            {
                Random r = new Random();
                int rInt = r.Next(0, 10);
                if (rInt == 0) // Someone is outside
                {
                    Form18 f = new Form18(true, 15);
                    f.Show();
                    this.Hide();
                }
            }

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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            // Random spawn person at the door
            Random r = new Random();
            int rInt = r.Next(0, 10);
            if (rInt == 0) // Someone is outside
            {
                Form18 f = new Form18(true, 15);
                f.Show();
                this.Hide();
            }

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
            // Random spawn person at the door
            Random r = new Random();
            int rInt = r.Next(0, 10);
            if (rInt == 0) // Someone is outside
            {
                Form18 f = new Form18(true, 15);
                f.Show();
                this.Hide();
            }

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

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            // Random spawn person at the door
            Random r = new Random();
            int rInt = r.Next(0, 10);
            if (rInt == 0) // Someone is outside
            {
                Form18 f = new Form18(true, 15);
                f.Show();
                this.Hide();
            }

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

        // Turn vacuum on
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

        // Turn printer on
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

        // Turn coffee machine on
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

        // Turn whashing machine on
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

        // Turn sprinkler on
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

        // Devices
        private void button5_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16(type);
            f.Show();
            this.Hide();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        // Main menu
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
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

        // Make form movable
        private void Form15_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form15_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form15_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form15_KeyDown(object sender, KeyEventArgs e)
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

        // Timer for vacuum
        private void timer1_Tick(object sender, EventArgs e)
        {
            j1++;
            if (j1 == 2)
            {
                timer1.Enabled = false;
                circularProgressBar1.SubscriptText = "Τέλος!";
                label2.Visible = true;
                label3.Visible = true;
            }
        }

        // Timer for printer
        private void timer2_Tick(object sender, EventArgs e)
        {
            j2++;
            if (j2 == 2)
            {
                timer2.Enabled = false;
                circularProgressBar2.SubscriptText = "Τέλος!";
                label5.Visible = true;
                label4.Visible = true;
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
                label7.Visible = true;
                label6.Visible = true;
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
                label9.Visible = true;
                label8.Visible = true;
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
                label12.Visible = true;
                label13.Visible = true;
            }
        }
    }
}
