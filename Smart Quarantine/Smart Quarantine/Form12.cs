using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form12 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        double total;

        public Form12()
        {
            InitializeComponent();
        }

        public Form12(double t)
        {
            total = t;
            InitializeComponent();
            // Set the Format type and the CustomFormat string.
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";

            panel1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            pictureBox2.Visible = false;
            button3.Visible = false;
            label6.Text = total.ToString() + " €";
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

        private void Form12_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        // Checks if name is valid 
        bool IsName(string number)
        {
            return Regex.Match(number, @"^[ a-z A-Z ]+$").Success;
        }

        // Checks if phone number is valid 
        bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{12}|[0-9]{10})$").Success;
        }

        // Checks if card number is valid 
        bool IsCardNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{16})$").Success;
        }

        // Checks if cvv number is valid 
        bool IsCVVNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{3})$").Success;
        }

        // Checks if email is valid 
        bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(email);
            if (!isValidEmail)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Undo button
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            button1.Enabled = true;
            panel1.Visible = false;
            groupBox4.Enabled = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        // Personal Info
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag1 = false;
            bool flag2 = false;
            bool flag4 = false;
            bool flag3 = true;
            if (IsValidEmail(textBox7.Text))
            {
                flag1 = true;
            }
            if (IsPhoneNumber(textBox5.Text))
            {
                flag2 = true;
            }
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                flag3 = false;
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (IsName(textBox4.Text))
            {
                flag4 = true;
            }
            if (flag1 && flag2 && flag3 && flag4) // If user enters valid values to all required fields
            {
                panel1.Visible = true;
                button1.Enabled = false;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Enabled = false;
                button3.Visible = false;
            }
            if (flag3 == true)
            {
                if (flag1 == false)
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε έγκυρο email.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (flag2 == false)
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε έγκυρο αριθμό κινητού.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (flag4 == false)
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε έγκυρο όνομα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Payment
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                bool flag1 = false;
                bool flag2 = false;
                bool flag5 = false;
                bool flag3 = true;
                bool flag4 = true;
                string s = dateTimePicker1.Text;
                string output = s.Substring(s.Length - 4, 4); // yyyy date format
                if (IsCVVNumber(textBox3.Text))
                {
                    flag1 = true;
                }
                if (IsCardNumber(textBox1.Text))
                {
                    flag2 = true;
                }
                if (String.IsNullOrEmpty(textBox2.Text))
                {
                    flag3 = false;
                    MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Int32.Parse(output) <= 2020)
                {
                    flag4 = false;
                    MessageBox.Show("Παρακαλώ συμπληρώστε σωστά την ημερομηνία λήξης.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (IsName(textBox2.Text))
                {
                    flag5 = true;
                }
                if (flag1 && flag2 && flag3 && flag4 && flag5) // If user enters valid values to all required fields
                {
                    MessageBox.Show("Επιτυχής καταχώρηση παραγγελίας!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form3 f = new Form3();
                    f.Show();
                    this.Hide();
                }
                if (flag3 == true)
                {
                    if (flag1 == false)
                    {
                        MessageBox.Show("Παρακαλώ συμπληρώστε έγκυρο CVV.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (flag2 == false)
                    {
                        MessageBox.Show("Παρακαλώ συμπληρώστε έγκυρο αριθμό κάρτας.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (flag5 == false)
                    {
                        MessageBox.Show("Παρακαλώ συμπληρώστε έγκυρο όνομα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (radioButton2.Checked == true)
            {
                MessageBox.Show("Επιτυχής καταχώρηση παραγγελίας!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 f = new Form3();
                f.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Make form movable
        private void Form12_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form12_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form12_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form12_KeyDown(object sender, KeyEventArgs e)
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
            toolTip1.Show("  Συνέχεια στην διαδικασία πληρωμής", button1);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Ολοκλήρωση παραγγελίας", button3);
        }

        // Using card
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            button3.Visible = false;
        }

        // Using cash
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            button3.Visible = true;
        }

        // MasterCard
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            button3.Visible = true;
        }

        // Visa
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            button3.Visible = true;
        }

        // Show help CVV
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
            radioButton4.Checked = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            radioButton4.Checked = true;
            radioButton3.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "32");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }
    }
}
