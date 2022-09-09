using System;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Το μήνυμά σας είναι κενό!", "Μήνυμα λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Το μήνυμά σας στάλθηκε!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 f = new Form20();
            f.Show();
            this.Hide();
        }

        // Tool tip
        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Πίσω (Ctrl + Β)", button1);
        }

        // Key shortcut
        private void Form22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.B)
            {
                button1.PerformClick();
            }
        }
    }
}
