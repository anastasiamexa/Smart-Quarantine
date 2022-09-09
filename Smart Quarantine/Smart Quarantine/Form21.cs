using System;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form21 : Form
    {
        int i = 0, minutes = 0, seconds = 0;

        public Form21()
        {
            InitializeComponent();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            Form20 f = new Form20();
            f.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 5)
            {
                timer1.Enabled = false;
                Random r = new Random();
                int rInt = r.Next(0, 2);
                if (rInt == 0)
                {
                    label16.Visible = false;
                    label1.Visible = true;
                    timer2.Enabled = true;
                    pictureBox1.Visible = false;
                }
                else if (rInt == 1)
                {
                    label16.Text = "Δεν απάντησε";
                    pictureBox1.Visible = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            if (seconds < 10)
            {
                if (minutes < 10)
                {
                    label1.Text = "0" + minutes.ToString() + ":0" + seconds.ToString();
                }
                else
                {
                    label1.Text = minutes.ToString() + ":0" + seconds.ToString();
                }
            }
            else
            {
                if (minutes < 10)
                {
                    label1.Text = "0" + minutes.ToString() + ":" + seconds.ToString();
                }
                else
                {
                    label1.Text = minutes.ToString() + ":" + seconds.ToString();
                }
            }
        }
    }
}
