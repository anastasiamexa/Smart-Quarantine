using System;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form26 : Form
    {
        System.Media.SoundPlayer intro = new System.Media.SoundPlayer();

        public Form26()
        {
            InitializeComponent();
            intro.SoundLocation = "sirena_ambulanza.wav";
            intro.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            intro.Stop();
            Form19 f = new Form19();
            f.Show();
            this.Hide();
        }
    }
}
