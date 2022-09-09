using System;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form18 : Form
    {
        bool visitor;
        int form = 0;

        public Form18()
        {
            InitializeComponent();
        }

        public Form18(bool v, int f)
        {
            InitializeComponent();
            visitor = v;
            form = f;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form17 f = new Form17(visitor, form);
            f.Show();
            this.Hide();
        }
    }
}
