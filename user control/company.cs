using Google.Protobuf.WellKnownTypes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Diagnostics.Metrics;

namespace _123.user_control
{
    public partial class company : UserControl
    {

        MySqlConnection connection;
        public company()
        {
            InitializeComponent();
            string connectionString = "server=127.0.0.1; User=root; database=jobhunt_projet; password=";
            connection = new MySqlConnection(connectionString);
            LoadCompany();
            PictureBox pictureBox = new PictureBox();



            pictureBox.Click += pictureBox2_Click;


            PictureBox pictureBox2 = new PictureBox();



            pictureBox2.Click += pictureBox2_Click;
        }

        private void LoadCompany()
        {
            try
            {
                //////////////////////////////////////////// Ouvrir la connexion à la base de données////////////////////////////////////////////////////////

                connection.Open();
                string query = "SELECT * FROM company";

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                dataGridViewCompany.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des company : " + ex.Message);
            }
            finally
            {

                connection.Close();
            }
        }

        private void company_Load(object sender, EventArgs e)
        {
            try
            {
                //////////////////////////////////////////// Ouvrir la connexion à la base de données////////////////////////////////////////////////////////

                connection.Open();
                string query = "SELECT * FROM company";

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                dataGridViewCompany.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des company : " + ex.Message);
            }
            finally
            {

                connection.Close();
            }
        }

        ////////////////////////////////////////////methode pour supprimer un company////////////////////////////////////////////////////////////////////////////
        private void DeleteCompany(int id)
        {
            try
            {
                connection.Open();

                string query = "DELETE FROM company WHERE id = @id";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

                MessageBox.Show("Company supprimé avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du company : " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                LoadCompany();

            }
        }
        ////////////////////////////////////// Méthode pour effacer les champs de saisie///////////////////////////////////////////////////////////////////
        private void ClearFields()
        {
            // Effacer le contenu des TextBox
            name.Text = string.Empty;
            email.Text = string.Empty;
            password.Text = string.Empty;
            num.Text = string.Empty;
            other_num.Text = string.Empty;

            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;

        }

        /////////////////////////////////////////////////////creation d'une company///////////////////////////////////////////////////////////////////////////////////////////////////


        private void CreateCompany(string name, string email, string password, string num, string autre_numéro, string industry , string location , string country , int ID_user)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO company (name, email, password, numero, autre_numéro, industry,location,country, ID_user) " +
                               "VALUES (@name, @email, @password, @numero, @autre_numéro, @industry,@location,@country, @ID_user)";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@numero", num);
                command.Parameters.AddWithValue("@autre_numéro", autre_numéro);
                command.Parameters.AddWithValue("@industry", industry);
                command.Parameters.AddWithValue("@location", location);
                command.Parameters.AddWithValue("@country", country);
                command.Parameters.AddWithValue("@ID_user", ID_user);
                command.ExecuteNonQuery();

                MessageBox.Show("Company créé avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du company : " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                LoadCompany();

            }
        }
        ///////////////////////////////////////////////////////////////update d'un company////////////////////////////////////////////////////////////
        private void UpdateCompany(int id , string name, string email, string password, string num, string other_num, string industry, string location, string country)
        {
            try
            {
                connection.Open();

                string query = "UPDATE company SET ";
                List<string> updates = new List<string>();

                if (!string.IsNullOrEmpty(name))
                {
                    updates.Add("name = @name");
                }
                if (!string.IsNullOrEmpty(email))
                {
                    updates.Add("email = @email");
                }
                if (!string.IsNullOrEmpty(password))
                {
                    updates.Add("password = @password");
                }
                if (!string.IsNullOrEmpty(num))
                {
                    updates.Add("num = @num");
                }
                if (!string.IsNullOrEmpty(other_num))
                {
                    updates.Add("other_num = @other_num");
                }
                if (!string.IsNullOrEmpty(industry))
                {
                    updates.Add("industry = @industry");
                }
                if (!string.IsNullOrEmpty(location))
                {
                    updates.Add("location = @location");
                }
                if (!string.IsNullOrEmpty(country))
                {
                    updates.Add("country = @country");
                }

                query += string.Join(", ", updates);
                query += " WHERE id = @id";

                MySqlCommand command = new MySqlCommand(query, connection);

                if (!string.IsNullOrEmpty(name))
                {
                    command.Parameters.AddWithValue("@name", name);
                }
                if (!string.IsNullOrEmpty(email))
                {
                    command.Parameters.AddWithValue("@email", email);
                }
                if (!string.IsNullOrEmpty(password))
                {
                    command.Parameters.AddWithValue("@password", password);
                }
                if (!string.IsNullOrEmpty(num))
                {
                    command.Parameters.AddWithValue("@num", num);
                }
                if (!string.IsNullOrEmpty(other_num))
                {
                    command.Parameters.AddWithValue("@other_num", other_num);
                }
                if (!string.IsNullOrEmpty(location))
                {
                    command.Parameters.AddWithValue("@location", location);
                }
                if (!string.IsNullOrEmpty(country))
                {
                    command.Parameters.AddWithValue("@country", country);
                }
                command.Parameters.AddWithValue("@id", id);

                // Exécuter la commande
                command.ExecuteNonQuery();

                MessageBox.Show("Company mis à jour avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du company : " + ex.Message);
            }
            finally
            {
                // Fermer la connexion à la base de données
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                LoadCompany();

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompany.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewCompany.SelectedRows[0].Cells["id"].Value);

                DeleteCompany(id);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un company à supprimer.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox_search.Text.Trim();
            string mysqlcon = "server=127.0.0.1; User=root; database=jobhunt_projet; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);

            try
            {
                mySqlConnection.Open();
                string query = "SELECT * FROM company WHERE name LIKE @searchValue ";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridViewCompany.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche : " + ex.Message);
            }
            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameValue = name.Text;
            string emailValue = email.Text;
            string passwordValue = password.Text;
            string numValue = num.Text;
            string autre_numero = other_num.Text;
            string industry = comboBox3.Text;
            string location = comboBox1.Text;
            string country = comboBox2.Text;
            int ID_user = 1; 

            CreateCompany(nameValue, emailValue, passwordValue, numValue, autre_numero, industry, location, country, ID_user);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompany.SelectedRows.Count > 0)
            {
                int companyId = Convert.ToInt32(dataGridViewCompany.SelectedRows[0].Cells["id"].Value);
                string nameValue = name.Text;
                string emailValue = email.Text;
                string passwordValue = password.Text;
                string numValue = num.Text;
                string autre_numero = other_num.Text;
                string industry = comboBox3.Text;
                string location = comboBox1.Text;
                string country = comboBox2.Text;
                UpdateCompany(companyId, nameValue, emailValue, passwordValue, numValue, autre_numero, industry, location, country);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un company à mettre à jour.");
            }
        }
    }
    }


    

