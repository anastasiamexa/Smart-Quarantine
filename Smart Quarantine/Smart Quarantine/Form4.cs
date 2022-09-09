using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form4 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        ArrayList moveList = new ArrayList();

        public Form4()
        {
            InitializeComponent();
            panel1.Visible = false;
            groupBox2.Visible = false;
            button3.Enabled = false;
        }

        public Form4(ArrayList list)
        {
            InitializeComponent();
            moveList = list;
            panel1.Visible = false;
            groupBox2.Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "ΚΩΔΙΚΟΣ 6")
            {
                if (String.IsNullOrEmpty(comboBox4.Text))
                {
                    panel1.Visible = false;
                    button2.Enabled = true;
                }
                else
                {
                    if (comboBox4.Text != "Ποδήλατο" && comboBox4.Text != "Περπάτημα")
                    {
                        panel1.Visible = true;
                        button2.Enabled = false;
                    }
                    else
                    {
                        panel1.Visible = false;
                        button2.Enabled = true;
                    }
                }
            }
            else
            {
                if (comboBox4.Text == "Συνδυασμός")
                {
                    groupBox2.Visible = true;
                    comboBox4.Enabled = false;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "ΚΩΔΙΚΟΣ 6")
            {
                if (String.IsNullOrEmpty(comboBox4.Text))
                {
                    panel1.Visible = false;
                    button2.Enabled = true;
                }
                else
                {
                    if (comboBox4.Text != "Ποδήλατο" && comboBox4.Text != "Περπάτημα")
                    {
                        panel1.Visible = true;
                        button2.Enabled = false;
                    }
                    else
                    {
                        panel1.Visible = false;
                        button2.Enabled = true;
                    }
                }
            }
            else
            {
                if (comboBox4.Text == "Συνδυασμός")
                {
                    groupBox2.Visible = true;
                    comboBox4.Enabled = false;
                }
                panel1.Visible = false;
                button2.Enabled = true;
            }
        }

        // Reset button
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            comboBox4.Enabled = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox3.Text) || String.IsNullOrEmpty(comboBox4.Text))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα υποχρεωτικά πεδία.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox4.Text == "Συνδυασμός")
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false
                    && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε συνδυαστικό τρόπο μετάβασης.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string temp = "";
                    if (checkBox1.Checked == true)
                    {
                        temp += checkBox1.Text + " ";
                    }
                    if (checkBox2.Checked == true)
                    {
                        temp += checkBox2.Text + " ";
                    }
                    if (checkBox3.Checked == true)
                    {
                        temp += checkBox3.Text + " ";
                    }
                    if (checkBox4.Checked == true)
                    {
                        temp += checkBox4.Text + " ";
                    }
                    if (checkBox5.Checked == true)
                    {
                        temp += checkBox5.Text + " ";
                    }
                    if (checkBox6.Checked == true)
                    {
                        temp += checkBox6.Text + " ";
                    }
                    button3.Enabled = true;
                    moveList.Add("Ώρα " + dateTimePicker1.Text + ", " + comboBox3.Text + ". " + comboBox4.Text + ", μετάβαση με " + temp);
                    MessageBox.Show("Επιτυχής προσθήκη μετακίνησης.", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                button3.Enabled = true;
                moveList.Add("Ώρα " + dateTimePicker1.Text + ", " + comboBox3.Text + ", μετάβαση με " + comboBox4.Text);
                MessageBox.Show("Επιτυχής προσθήκη μετακίνησης.", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            button1.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(moveList);
            f.Show();
            this.Hide();
        }

        // Tool tips
        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Επιστροφή στην επιλογή\n απλού τρόπου μετάβασης", button1);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Προσθήκη μετακινήσης (Ctrl + A)", button2);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Προβολή αποθηκευμένων μετακινήσεων (Ctrl + P)", button3);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Επιστροφή στο κεντρικό μενού", button5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Make the form movable
        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form4_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                button4.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                button2.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.P)
            {
                button3.PerformClick();
            }
        }

        // Home menu
        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm",HelpNavigator.TopicId, "22");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }
    }
}
