using _123.user_control;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _123
{
    public partial class crud : Form
    {
        bool sidebarExpand;
        public crud()
        {
            InitializeComponent();
            pictureBox1.Click += pictureBox1_Click;
            acceuil uc = new acceuil();
            addusercontrol(uc);

        }
        private void addusercontrol(UserControl usercontrol)
        {

            usercontrol.Dock = DockStyle.Fill;

            panelcontainer.Controls.Clear();
            panelcontainer.Controls.Add(usercontrol);
            usercontrol.BringToFront();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            home uc = new home();
            addusercontrol(uc);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void sidebartimer_tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width) {
                sidebarExpand = false;
                sidebartimer.Stop();
                }
            }else
            {
                sidebar.Width += 10;
                if (sidebar.Width==sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebartimer.Stop();
                }
            }
        }

        private void menubutton_Click(object sender, EventArgs e)
        {
            sidebartimer.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            company uc = new company();
            addusercontrol(uc);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            candidat uc = new candidat();
            addusercontrol(uc);
        }

      

        private void crud_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            acceuil uc = new acceuil();
            addusercontrol(uc);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();

        }

        private void panelcontainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
