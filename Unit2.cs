using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace George_Jackson_Unit2_IT481
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-VESVVKN\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            txtMessageText.Text = "Retrieving Records...";
            command.Connection = connection;
            command.CommandText = "select * from Customers";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CustomersListDataGridView.DataSource = dt;
            txtMessageText.Text = "Retrieval Successful!";

            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-VESVVKN\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            txtMessageText.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Customers (ID, Company) values('" +
            txtID.Text + "','" + txtCompanyName.Text + "')";
            command.ExecuteNonQuery();
            txtMessageText.Text = "Record Inserted...";
            connection.Close();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-VESVVKN\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            txtMessageText.Text = "Counting Records...";
            command.Connection = connection;
            command.CommandText = "select count(*) from Customers";
            int count = (int)command.ExecuteScalar();
            txtMessageText.Text = "Number of records: " + count;
            connection.Close();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_Load() Called...");
            txtMessageText.Text = "Startup...";
            try
            {
                System.Diagnostics.Debug.WriteLine("within the try");
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-VESVVKN\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                connection.Open();
                txtMessageText.Text = "Connection Successful";
                connection.Close();
            }
            catch (Exception ex)
            {
                txtMessageText.Text = "Error, " + ex;
            }
        }
    }
}
