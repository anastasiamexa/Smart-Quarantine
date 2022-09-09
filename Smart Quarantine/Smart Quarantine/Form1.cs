using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Quarantine
{
    public partial class Form1 : Form
    {
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        string user = "";
        int limit, i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // If it's the resident and wants to enter, even though his temperature is very high
        public Form1(bool flag)
        {
            InitializeComponent();
            Image myimage = new Bitmap("background opendoor.png");
            this.BackgroundImage = myimage;
            pictureBox2.Image = Image.FromFile("385.gif");
            button5.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            panel4.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            // Transparent panels
            panel1.BackColor = Color.FromArgb(25, Color.White);
            panel2.BackColor = Color.FromArgb(25, Color.White);
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            panel4.Visible = false;
            limit = pictureBox2.Location.Y;
        }

        // Visitor
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Image myimage = new Bitmap("background green.png");
            this.BackgroundImage = myimage;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            user = "visitor";
        }

        // Resident
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Image myimage = new Bitmap("background blue with keys.png");
            this.BackgroundImage = myimage;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            user = "resident";
        }

        // Move the thermometers within the limits of the form
        private void button1_Click(object sender, EventArgs e)
        {
            if (limit != pictureBox2.Location.Y)
            {
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 10);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((limit + 320) != pictureBox2.Location.Y)
            {
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 10);
            }
        }

        // Start to calculate the temperature
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("test.gif");
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            timer1.Enabled = true;
            panel4.Visible = false;
        }

        // Exit
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Make the form movable
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // Key shortcuts
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                button4.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.Up)
            {
                button1.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.Down)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }

        // Tool tips
        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Μετακίνηση θερμομέτρου προς τα πάνω (Ctrl + Arrow Up key)", button1);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Μετακίνηση θερμομέτρου προς τα κάτω (Ctrl + Arrow Down key)", button2);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Ορισμός του ύψους στην παρούσα θέση (Enter)", button3);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Έξοδος από την εφαρμογή (Ctrl + Ε)", button4);
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Επισκέπτης", panel1);
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Κάτοικος", panel2);
        }

        // Enter the house
        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "online_help.chm", HelpNavigator.TopicId,"10");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("  Βοήθεια", button6);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 5) // after 5 seconds
            {
                timer1.Enabled = false;
                // Pick a random scenario
                Random r = new Random();
                int rInt = r.Next(0, 12);
                //int rInt = 7;
                // More likely the temperature will be normal
                if (rInt == 0 || rInt == 1 || rInt == 2 || rInt == 3 || rInt == 4 || rInt == 9 || rInt == 10 || rInt == 11) 
                {
                    pictureBox2.Image = Image.FromFile("360.gif");
                    if (user == "visitor")
                    {
                        Image myimage = new Bitmap("background opendoor man(mask).png");
                        this.BackgroundImage = myimage;
                    }
                    else if (user == "resident")
                    {
                        Image myimage = new Bitmap("background opendoor.png");
                        this.BackgroundImage = myimage;
                        button5.Visible = true;
                    }
                }
                else if (rInt == 5) // Temperature = 36.9
                {
                    pictureBox2.Image = Image.FromFile("369.gif");
                    MessageBox.Show("Η θερμοκρασία σας είναι σχετικά υψηλή. Παρακαλώ ξεκουραστείτε λίγο και ξαναπροσπαθήστε", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox2.Image = Image.FromFile("thermometer.gif");
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    panel4.Visible = true;
                    i = 0;
                }
                else if (rInt == 6) // Temperature = 37.7
                {
                    pictureBox2.Image = Image.FromFile("377.gif");
                    if (user == "visitor")
                    {
                        MessageBox.Show("Η θερμοκρασία σας είναι υψηλή! Δεν μπορείτε να περάσετε.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pictureBox2.Image = Image.FromFile("thermometer.gif");
                        Image myimage = new Bitmap("background blue.png");
                        this.BackgroundImage = myimage;
                        panel1.Visible = true;
                        panel2.Visible = true;
                        panel3.Visible = true;
                        i = 0;
                    }
                    else if (user == "resident")
                    {
                        DialogResult dialogResult = MessageBox.Show("Η θερμοκρασία σας είναι υψηλή! Είστε σίγουροι ότι θέλετε να μπείτε;", "Προσοχή", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Image myimage = new Bitmap("background opendoor.png");
                            this.BackgroundImage = myimage;
                            button5.Visible = true;
                        }
                        else
                        {
                            pictureBox2.Image = Image.FromFile("thermometer.gif");
                            Image myimage = new Bitmap("background blue.png");
                            this.BackgroundImage = myimage;
                            panel1.Visible = true;
                            panel2.Visible = true;
                            panel3.Visible = true;
                            i = 0;
                        }
                    }
                }
                else if (rInt == 7) // Temperature = 38.5
                {
                    pictureBox2.Image = Image.FromFile("385.gif");
                    // Show the route to the closest diagnostic center
                    if (user == "visitor")
                    {
                        MessageBox.Show("Η θερμοκρασία σας είναι πολύ υψηλή! Δεν μπορείτε να περάσετε.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Form2 f = new Form2(user);
                        f.Show();
                        this.Hide();
                    }
                    else if (user == "resident")
                    {
                        MessageBox.Show("Η θερμοκρασία σας είναι πολύ υψηλή!", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Form2 f = new Form2(user);
                        f.Show();
                        this.Hide();
                    }
                }
                else if (rInt == 8) // Wrong height
                {
                    pictureBox2.Image = Image.FromFile("lo.gif");
                    MessageBox.Show("Λάθος κατά την θερμομέτρηση. Παρακαλώ ορίστε το σωστό ύψος.", "Μήνυμα Λάθους", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBox2.Image = Image.FromFile("thermometer.gif");
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    panel4.Visible = true;
                    i = 0;
                }
            }
        }
    }
}
