using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form20 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
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

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form19 f = new Form19();
            f.Show();
            this.Hide();
        }

        // Make form movable
        private void Form20_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form20_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form20_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form20_KeyDown(object sender, KeyEventArgs e)
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

        // Tool tips
        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πίσω (Ctrl + Β)", button1);
        }

        // Call
        private void button8_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int rInt = r.Next(0, 5);
            if (rInt == 0)
            {
                Form25 f = new Form25();
                f.Show();
                this.Hide();
            }
            else
            {
                Form21 f = new Form21();
                f.Show();
                this.Hide();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int rInt = r.Next(0, 5);
            if (rInt == 0)
            {
                Form25 f = new Form25();
                f.Show();
                this.Hide();
            }
            else
            {
                Form21 f = new Form21();
                f.Show();
                this.Hide();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int rInt = r.Next(0, 5);
            if (rInt == 0)
            {
                Form25 f = new Form25();
                f.Show();
                this.Hide();
            }
            else
            {
                Form21 f = new Form21();
                f.Show();
                this.Hide();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int rInt = r.Next(0, 5);
            if (rInt == 0)
            {
                Form25 f = new Form25();
                f.Show();
                this.Hide();
            }
            else
            {
                Form21 f = new Form21();
                f.Show();
                this.Hide();
            }
        }

        // Message
        private void button9_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            f.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            f.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            f.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            f.Show();
            this.Hide();
        }

        // Mouse hovers
        private void button8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Κλήση", button8);
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Αποστολή μηνύματος", button9);
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Κλήση", button11);
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Αποστολή μηνύματος", button10);
        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Κλήση", button13);
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Αποστολή μηνύματος", button12);
        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Κλήση", button15);
        }

        private void button14_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Αποστολή μηνύματος", button14);
        }

        // Main menu
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form23 f = new Form23("pharmacist");
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form23 f = new Form23("doctor");
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form24 f = new Form24();
            f.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "51");
        }

        private void button16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button16);
        }
    }
}
