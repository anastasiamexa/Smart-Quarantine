using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form10 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        ArrayList items = new ArrayList();
        ArrayList values = new ArrayList();
        ArrayList prices = new ArrayList();
        string extras = "";
        double price = 0;
        double total = 0;

        public Form10()
        {
            InitializeComponent();
            panel4.Visible = false;
            panel1.Visible = false;
        }

        public Form10(ArrayList i, ArrayList v, ArrayList p, double t)
        {
            InitializeComponent();
            items = i;
            values = v;
            prices = p;
            total = t;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
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

        private void Form10_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        // Add to cart
        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (radioButton1.Checked == true)
            {
                if (radioButton4.Checked == true)
                {
                    extras += radioButton4.Text + " ";
                    flag = true;
                }
                if (radioButton5.Checked == true)
                {
                    extras += radioButton5.Text + " ";
                    flag = true;
                }
                if (radioButton6.Checked == true)
                {
                    extras += radioButton6.Text + " ";
                    flag = true;
                }
                if (checkBox1.Checked == true)
                {
                    extras += checkBox1.Text + " ";
                }
                int x = listBox1.SelectedIndex; // Coffee selected
                // Find price of selected coffee
                switch (x)
                {
                    case 0:
                        price = 1.50;
                        break;
                    case 1:
                        price = 2.50;
                        break;
                    case 2:
                        price = 2.50;
                        break;
                    case 3:
                        price = 2;
                        break;
                    case 4:
                        price = 3;
                        break;
                    case 5:
                        price = 3.50;
                        break;
                    default:
                        price = 0;
                        break;
                }
                if (price != 0)
                {
                    if (flag)
                    {
                        if (String.IsNullOrEmpty(listBox2.Text))
                        {
                            MessageBox.Show("Παρακαλώ επιλέξτε ποσότητα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            items.Add(listBox1.Text + " " + extras);
                            values.Add(listBox2.Text);

                            // Compute the price
                            prices.Add(Int32.Parse(listBox2.Text) * price);
                            /*for (int i = 0; i < items.Count; i++)
                            {
                                //MessageBox.Show(items[i] + " " + values[i] + " " + prices[i] + "€");
                            }*/
                            MessageBox.Show("Επιτυχής καταχώρηση!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Παρακαλώ επιλέξτε ποσότητα ζάχαρης.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (price == 0)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε καφέ.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                extras = "";
                price = 0;
                listBox1.ClearSelected();
                listBox2.ClearSelected();
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                checkBox1.Checked = false;
            }
            else if (radioButton2.Checked == true)
            {
                int x = listBox3.SelectedIndex; // Drink selected
                // Find price of selected drink
                switch (x)
                {
                    case 0:
                        price = 1;
                        break;
                    case 1:
                        price = 1.50;
                        break;
                    case 2:
                        price = 2;
                        break;
                    case 3:
                        price = 3;
                        break;
                    case 4:
                        price = 3.20;
                        break;
                    default:
                        price = 0;
                        break;
                }
                if (price != 0)
                {
                    if (String.IsNullOrEmpty(listBox4.Text))
                    {
                        MessageBox.Show("Παρακαλώ επιλέξτε ποσότητα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        items.Add(listBox3.Text);
                        values.Add(listBox4.Text);
                        // Compute the price
                        prices.Add(Int32.Parse(listBox4.Text) * price);
                        /*for (int i = 0; i < items.Count; i++)
                        {
                            //MessageBox.Show(items[i] + " " + values[i] + " " + prices[i] + "€");
                        }*/
                        MessageBox.Show("Επιτυχής καταχώρηση!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (price == 0)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε ρόφημα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                price = 0;
                listBox3.ClearSelected();
                listBox4.ClearSelected();
            }
            else if (radioButton3.Checked == true)
            {
                int x = listBox6.SelectedIndex; // Snack selected
                // Find price of selected snack
                switch (x)
                {
                    case 0:
                        price = 1;
                        break;
                    case 1:
                        price = 4;
                        break;
                    case 2:
                        price = 4.50;
                        break;
                    case 3:
                        price = 3.50;
                        break;
                    case 4:
                        price = 3;
                        break;
                    default:
                        price = 0;
                        break;
                }
                if (price != 0)
                {
                    if (String.IsNullOrEmpty(listBox5.Text))
                    {
                        MessageBox.Show("Παρακαλώ επιλέξτε ποσότητα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        items.Add(listBox6.Text);
                        values.Add(listBox5.Text);
                        // Compute the price
                        prices.Add(Int32.Parse(listBox5.Text) * price);
                        /*for (int i = 0; i < items.Count; i++)
                        {
                            MessageBox.Show(items[i] + " " + values[i] + " " + prices[i] + "€");
                        }*/
                        MessageBox.Show("Επιτυχής καταχώρηση!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (price == 0)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε σνακ.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                price = 0;
                listBox6.ClearSelected();
                listBox5.ClearSelected();
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε κατηγορία.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Show cart
        private void button3_Click(object sender, EventArgs e)
        {
            double sum = 0;
            foreach (double i in prices)
            {
                sum = sum + i;
            }
            total = sum;
            if (sum == 0)
            {
                MessageBox.Show("Δεν υπάρχει καμία παραγγελία.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {   
                Form11 f = new Form11("coffee", items, values, prices, total);
                f.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9("coffee");
            f.Show();
            this.Hide();
        }

        // Make form movable
        private void Form10_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form10_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form10_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form10_KeyDown(object sender, KeyEventArgs e)
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

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Προβολή των προϊόντων στο καλάθι", button3);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Προσθήκη στο καλάθι", button2);
        }

        // Choose category
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            groupBox5.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            radioButton3.Checked = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = true;
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
