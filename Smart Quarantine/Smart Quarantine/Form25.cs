using System;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form25 : Form
    {
        int i = 0;

        public Form25()
        {
            InitializeComponent();
        }

        private void Form25_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Form19 f = new Form19();
            f.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 10)
            {
                timer1.Enabled = false;
                Form26 f = new Form26();
                f.Show();
                this.Hide();
            }
        }
    }
}
