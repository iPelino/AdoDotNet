using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace HostelManagementSystem
{
    public partial class FormLogin : Form
    {
        private string connectionString;
        private MySqlConnection connection;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void DatabaseConnection()
        {
            try
            {
                connectionString = "Server=localhost;Database=hosteldb;Uid=root;Pwd=Pe2dalino@24;";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private bool Login(string username, string password)
        {
     
            DatabaseConnection();
            var selectCommand = new MySqlCommand();
            selectCommand.CommandText = "select * from users where username=@username AND password=@password";
            selectCommand.Parameters.AddWithValue("@username", username);
            selectCommand.Parameters.AddWithValue("@password", password);
            selectCommand.Connection = connection;

            MySqlDataReader dataReader = selectCommand.ExecuteReader();
            if (dataReader.Read())
            {
                //MessageBox.Show("Login Successful");
                return true;
            }
            else
            {
               // MessageBox.Show("Invalid Username or Password");
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;
            if (username =="" || password =="")
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            if (Login(username, password))
            {
                //MessageBox.Show("Login Successful");
                //this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
