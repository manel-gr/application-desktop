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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            string mysqlcon = "server=127.0.0.1; User=root; database=jobhunt_projet; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);

            string name = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Les champs ne peuvent pas être vides.");
            }
            else
            {
                try
                {
                    mySqlConnection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM admin WHERE name = @name AND password = @password", mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("@name", name);
                    mySqlCommand.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // L'utilisateur existe dans la base de données
                        MessageBox.Show("Connexion réussie !");
                        crud crud = new crud();
                        crud.Show();
                        this.Hide();
                    }
                    else
                    {
                        // L'utilisateur n'existe pas ou les informations de connexion sont incorrectes
                        MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la connexion à la base de données : " + ex.Message);
                }
                finally
                {
                    if (mySqlConnection.State == ConnectionState.Open)
                    {
                        mySqlConnection.Close();
                    }

                }
            }
        }







    }
}
