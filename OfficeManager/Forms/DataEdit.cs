using MySql.Data.MySqlClient;
using OfficeManager.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace OfficeManager.Forms
{
    public partial class DataEdit : Form
    {
        MySqlConnection conn = DBConnection.GetDBConnection();


        public DataEdit()
        {
            InitializeComponent();
        }

        private void DataEdit_Load(object sender, EventArgs e)
        {
            conn.Open();

            try
            {
                string query = $"SELECT * FROM table1 JOIN table2 ON  table1.ID =  table2.ID";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter mda = new MySqlDataAdapter(command);
                    DataSet dateSet = new DataSet();
                    mda.Fill(dateSet);
                    dataGridView.DataSource = dateSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                string fname = textBox2.Text;
                string lname = textBox3.Text;
                int age = Convert.ToInt32(textBox4.Text);
                string edc = textBox5.Text;
                int salary = Convert.ToInt32(textBox6.Text);
                string currency = textBox7.Text;

                string request = $"UPDATE table1 SET FirstName = '{fname}', LastName = '{lname}', Age = {age}, Education = '{edc}' WHERE ID = {id};";
                string request2 = $"UPDATE table2 SET  Salary = {salary}, Currency = '{currency}' WHERE ID = {id};";
                string request3 = $"SELECT * FROM table1 JOIN table2 ON  table1.ID =  table2.ID";
                using (MySqlCommand command = new MySqlCommand(request, conn)) command.ExecuteNonQuery();
                using (MySqlCommand command = new MySqlCommand(request2, conn)) command.ExecuteNonQuery();
                using (MySqlCommand command = new MySqlCommand(request3, conn))
                {
                    MySqlDataAdapter mda = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    mda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    command.ExecuteNonQuery();
                }
                    

            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
