using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form11 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        ArrayList items = new ArrayList();
        ArrayList values = new ArrayList();
        ArrayList prices = new ArrayList();
        string type = "";
        double sum;
        double total;

        public Form11()
        {
            InitializeComponent();
        }

        public Form11(string tp, ArrayList i, ArrayList v, ArrayList p, double t)
        {
            InitializeComponent();
            button3.Enabled = true;
            type = tp;
            items = i;
            values = v;
            prices = p;
            total = t;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Προϊόν";
            dataGridView1.Columns[1].Name = "Ποσότητα";
            dataGridView1.Columns[2].Name = "Τιμή";
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            for (int j = 0; j < items.Count; j++)
            {
                dataGridView1.Rows.Add(items[j], values[j], prices[j]);
            }
            //Change cell font
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Century Gothic", 14F, GraphicsUnit.Pixel);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.Bisque;
            }
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

        private void Form11_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        // Delete
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Σίγουρα θέλετε να διαγράψετε την παραγγελία;", "Διαγραφή", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string s1 = dataGridView1.CurrentRow.Cells["Προϊόν"].Value.ToString();
                string s2 = dataGridView1.CurrentRow.Cells["Ποσότητα"].Value.ToString();
                double s3 = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Τιμή"].Value.ToString());
                items.Remove(s1);
                values.Remove(s2);
                prices.Remove(s3);
                dataGridView1.Rows.Clear();
                for (int j = 0; j < items.Count; j++)
                {
                    dataGridView1.Rows.Add(items[j], values[j], prices[j]);
                }
                //Change cell font
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Century Gothic", 14F, GraphicsUnit.Pixel);
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.Bisque;
                }
                sum = 0;
                foreach (double k in prices)
                {
                    sum = sum + k;
                }
                total = sum;
                label6.Text = sum.ToString() + " €";
                if (dataGridView1.Rows.Count == 0)
                {
                    button3.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Make form movable
        private void Form11_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form11_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form11_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form11_KeyDown(object sender, KeyEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == "coffee")
            {
                Form10 f = new Form10(items, values, prices, total);
                f.Show();
                this.Hide();
            }
            else if (type == "food")
            {
                Form13 f = new Form13(items, values, prices, total);
                f.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12(total);
            f.Show();
            this.Hide();
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
