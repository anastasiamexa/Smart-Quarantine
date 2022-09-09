using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form13 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        ArrayList items = new ArrayList();
        ArrayList values = new ArrayList();
        ArrayList prices = new ArrayList();
        double price = 0;
        double total = 0;

        public Form13()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel1.Visible = false;
        }

        public Form13(ArrayList i, ArrayList v, ArrayList p, double t)
        {
            InitializeComponent();
            items = i;
            values = v;
            prices = p;
            total = t;
            groupBox1.Enabled = false;
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

        private void Form13_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        // Add to cart
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                int x = listBox1.SelectedIndex; // Appetizer selected
                // Find price of selected appetizer
                switch (x)
                {
                    case 0:
                        price = 2;
                        break;
                    case 1:
                        price = 2.50;
                        break;
                    case 2:
                        price = 2;
                        break;
                    case 3:
                        price = 1.50;
                        break;
                    case 4:
                        price = 4;
                        break;
                    default:
                        price = 0;
                        break;
                }
                if (price != 0)
                {
                    if (String.IsNullOrEmpty(listBox2.Text))
                    {
                        MessageBox.Show("Παρακαλώ επιλέξτε ποσότητα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        items.Add(listBox1.Text);
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
                else if (price == 0)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε ορεκτικό.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                price = 0;
                listBox1.ClearSelected();
                listBox2.ClearSelected();
            }
            else if (radioButton2.Checked == true)
            {
                int x = listBox4.SelectedIndex; // Main dish selected
                // Find price of selected main dish
                switch (x)
                {
                    case 0:
                        price = 7;
                        break;
                    case 1:
                        price = 10;
                        break;
                    case 2:
                        price = 9;
                        break;
                    case 3:
                        price = 6;
                        break;
                    case 4:
                        price = 8.50;
                        break;
                    default:
                        price = 0;
                        break;
                }
                if (price != 0)
                {
                    if (String.IsNullOrEmpty(listBox3.Text))
                    {
                        MessageBox.Show("Παρακαλώ επιλέξτε ποσότητα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        items.Add(listBox4.Text);
                        values.Add(listBox3.Text);
                        // Compute the price
                        prices.Add(Int32.Parse(listBox3.Text) * price);
                        /*for (int i = 0; i < items.Count; i++)
                        {
                            //MessageBox.Show(items[i] + " " + values[i] + " " + prices[i] + "€");
                        }*/
                        MessageBox.Show("Επιτυχής καταχώρηση!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (price == 0)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε κυρίως πιάτο.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                price = 0;
                listBox3.ClearSelected();
                listBox4.ClearSelected();
            }
            else if (radioButton3.Checked == true)
            {
                int x = listBox6.SelectedIndex; // Dessert selected
                // Find price of selected dessert
                switch (x)
                {
                    case 0:
                        price = 4;
                        break;
                    case 1:
                        price = 4.20;
                        break;
                    case 2:
                        price = 3;
                        break;
                    case 3:
                        price = 4.50;
                        break;
                    case 4:
                        price = 2.50;
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
                    MessageBox.Show("Παρακαλώ επιλέξτε επιδόρπιο.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                price = 0;
                listBox6.ClearSelected();
                listBox5.ClearSelected();
            }
            else if (radioButton4.Checked == true)
            {
                int x = listBox8.SelectedIndex; // Drink selected
                // Find price of selected drink
                switch (x)
                {
                    case 0:
                        price = 1;
                        break;
                    case 1:
                        price = 1.80;
                        break;
                    case 2:
                        price = 3;
                        break;
                    case 3:
                        price = 3;
                        break;
                    case 4:
                        price = 0.50;
                        break;
                    default:
                        price = 0;
                        break;
                }
                if (price != 0)
                {
                    if (String.IsNullOrEmpty(listBox7.Text))
                    {
                        MessageBox.Show("Παρακαλώ επιλέξτε ποσότητα.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        items.Add(listBox8.Text);
                        values.Add(listBox7.Text);
                        // Compute the price
                        prices.Add(Int32.Parse(listBox7.Text) * price);
                        /*for (int i = 0; i < items.Count; i++)
                        {
                            MessageBox.Show(items[i] + " " + values[i] + " " + prices[i] + "€");
                        }*/
                        MessageBox.Show("Επιτυχής καταχώρηση!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (price == 0)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε ποτό.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                price = 0;
                listBox8.ClearSelected();
                listBox7.ClearSelected();
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
                Form11 f = new Form11("food", items, values, prices, total);
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
            Form9 f = new Form9("food");
            f.Show();
            this.Hide();
        }

        // Make form movable
        private void Form13_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form13_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form13_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form13_KeyDown(object sender, KeyEventArgs e)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = true;
            groupBox1.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = true;
            groupBox1.Enabled = false;
            groupBox3.Enabled = true;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = true;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            groupBox5.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = true;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = true;
            radioButton4.Checked = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "35");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }
    }
}
