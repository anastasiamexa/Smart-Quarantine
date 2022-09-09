using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form5 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        ArrayList moveList = new ArrayList();

        public Form5()
        {
            InitializeComponent();
        }

        public Form5(ArrayList list)
        {
            InitializeComponent();
            moveList = list;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Μετακινήσεις";
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            foreach (var value in moveList)
            {
                dataGridView1.Rows.Add(value);
            }
            // Change cell font
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Century Gothic", 14F, GraphicsUnit.Pixel);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.Bisque;
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(moveList);
            f.Show();
            this.Hide();
        }

        // Make form movable
        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form5_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form5_KeyDown(object sender, KeyEventArgs e)
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
        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πίσω (Ctrl + Β)", button1);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        // Delete a cell
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Σίγουρα θέλετε να διαγράψετε την μετακίνηση;", "Διαγραφή", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string s = dataGridView1.CurrentRow.Cells["Μετακινήσεις"].Value.ToString();
                moveList.Remove(s);
                dataGridView1.Rows.Clear();
                foreach (var value in moveList)
                {
                    dataGridView1.Rows.Add(value);
                }
                // Change cell font
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Century Gothic", 14F, GraphicsUnit.Pixel);
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.Bisque;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (moveList.Count > 0)
            {
                MessageBox.Show("Έγινε οριστική υποβολή των μετακινήσεών σας!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form6 f = new Form6();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Δεν υπάρχει καμία μετακίνηση.", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId, "22");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }
    }
}
