using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _123.user_control
{
    public partial class candidat : UserControl
    {
        MySqlConnection connection;
        public candidat()
        {
            InitializeComponent();
            string connectionString = "server=127.0.0.1; User=root; database=jobhunt_projet; password=";
            connection = new MySqlConnection(connectionString);
            LoadCandidats();

           PictureBox pictureBox = new PictureBox();
           

          
            pictureBox.Click += pictureBox2_Click;

          
            PictureBox pictureBox2 = new PictureBox();
      

           
            pictureBox2.Click += pictureBox2_Click;
        }
        private void LoadCandidats()
        {
            try
            {
                //////////////////////////////////////////// Ouvrir la connexion à la base de données////////////////////////////////////////////////////////

                connection.Open();
                string query = "SELECT * FROM candidat";

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                dataGridViewCandidats.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des candidats : " + ex.Message);
            }
            finally
            {
              
                connection.Close();
            }
        }

        ////////////////////////////////////////////methode pour supprimer un candidat////////////////////////////////////////////////////////////////////////////
        private void DeleteCandidat(int id)
        {
            try
            {
                connection.Open();

                string query = "DELETE FROM candidat WHERE ID = @id";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

                MessageBox.Show("Candidat supprimé avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du candidat : " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                LoadCandidats();
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
            dateTimePicker2.Value = DateTime.Now;
           
            comboBox1.SelectedIndex = -1;
            
        }

        /////////////////////////////////////////////////////creation d'un candidat///////////////////////////////////////////////////////////////////////////////////////////////////
     

        private void CreateCandidat(string name,string family_name, string email, string password, string num, DateTime date_de_naissance, string location_candidat, int ID_user)
        {
            try
            {
                connection.Open();

                //  requête SQL pour insérer un nouveau candidat
                string query = "INSERT INTO candidat (name,family_name, email, password, num, date_de_naissance, location_candidat, ID_user) " +
                               "VALUES (@name,@family_name, @email, @password, @num, @date_de_naissance, @location_candidat, @ID_user)";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@family_name", family_name);

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@num", num);
                command.Parameters.AddWithValue("@date_de_naissance", date_de_naissance);
                command.Parameters.AddWithValue("@location_candidat", location_candidat);
                command.Parameters.AddWithValue("@ID_user", ID_user);
                command.ExecuteNonQuery();

                MessageBox.Show("Candidat créé avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du candidat : " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                LoadCandidats();

            }
        }
        ///////////////////////////////////////////////////////////////update d'un candidat////////////////////////////////////////////////////////////
        private void UpdateCandidat(int id, string name,string family_name , string email, string password, string num, DateTime date_de_naissance, string location_candidat)
        {
            try
            {
                connection.Open();

                //  requête SQL pour mettre à jour le candidat
                string query = "UPDATE candidat SET ";
                List<string> updates = new List<string>();

                if (!string.IsNullOrEmpty(name))
                {
                    updates.Add("name = @name");
                }
                if (!string.IsNullOrEmpty(family_name))
                {
                    updates.Add("family_name = @family_name");
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
                if (date_de_naissance != DateTime.MinValue)
                {
                    updates.Add("date_de_naissance = @date_de_naissance");
                }
                if (!string.IsNullOrEmpty(location_candidat))
                {
                    updates.Add("location_candidat = @location_candidat");
                }

                query += string.Join(", ", updates);
                query += " WHERE ID = @id";

                MySqlCommand command = new MySqlCommand(query, connection);

                if (!string.IsNullOrEmpty(name))
                {
                    command.Parameters.AddWithValue("@name", name);
                }
                if (!string.IsNullOrEmpty(family_name))
                {
                    command.Parameters.AddWithValue("@family_name", family_name);
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
                if (date_de_naissance != DateTime.MinValue)
                {
                    command.Parameters.AddWithValue("@date_de_naissance", date_de_naissance);
                }
                if (!string.IsNullOrEmpty(location_candidat))
                {
                    command.Parameters.AddWithValue("@location_candidat", location_candidat);
                }

                command.Parameters.AddWithValue("@id", id);

                // Exécuter la commande
                command.ExecuteNonQuery();

                MessageBox.Show("Candidat mis à jour avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du candidat : " + ex.Message);
            }
            finally
            {
                // Fermer la connexion à la base de données
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                LoadCandidats();

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void candidat_Load(object sender, EventArgs e)
        {
            button3.Click += button3_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameValue = name.Text;
            string family_namevalue = family_name.Text;
            string emailValue = email.Text;
            string passwordValue = password.Text;
            string numValue = num.Text;
            DateTime date_de_naissance = dateTimePicker2.Value;
            string location_candidat = comboBox1.Text;
            int ID_user = 1; 

            CreateCandidat(nameValue, family_namevalue, emailValue, passwordValue, numValue, date_de_naissance, location_candidat, ID_user);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewCandidats.SelectedRows.Count > 0)
            {
                int candidatId = Convert.ToInt32(dataGridViewCandidats.SelectedRows[0].Cells["ID"].Value);

                DeleteCandidat(candidatId);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un candidat à supprimer.");
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

        private void button4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewCandidats.SelectedRows.Count > 0)
            {
                int candidatId = Convert.ToInt32(dataGridViewCandidats.SelectedRows[0].Cells["ID"].Value);
                string nameValue = name.Text;
                string family_namevalue = family_name.Text;

                string emailValue = email.Text;
                string passwordValue = password.Text;
                string numValue = num.Text;
                DateTime date_de_naissance = dateTimePicker2.Value;
                string location_candidat = comboBox1.Text;

                UpdateCandidat(candidatId, nameValue,family_namevalue, emailValue, passwordValue, numValue, date_de_naissance, location_candidat);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un candidat à mettre à jour.");

            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox_search.Text.Trim();
            string mysqlcon = "server=127.0.0.1; User=root; database=jobhunt_projet; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);

            try
            {
                mySqlConnection.Open();
                string query = "SELECT * FROM candidat WHERE name LIKE @searchValue ";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridViewCandidats.DataSource = dataTable;
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
    }


        }
    
    

