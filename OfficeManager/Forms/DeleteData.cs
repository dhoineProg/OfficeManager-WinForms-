using MySql.Data.MySqlClient;
using OfficeManager.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace OfficeManager.Forms
{
    public partial class DeleteData : Form
    {
        MySqlConnection conn = DBConnection.GetDBConnection();
        public DeleteData()
        {
            InitializeComponent();
        }

        private void DeleteData_Load(object sender, EventArgs e)
        {
            DataExecute();
        }

        public void DataExecute()
        {
            try
            {
                conn.Open();

                string query = $"SELECT * FROM table1 JOIN table2 ON table1.ID = table2.ID";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter mda = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    mda.Fill(dt);
                    dataGridView.DataSource = dt;
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = $"SELECT * FROM table1 JOIN table2 ON table1.ID = table2.ID";


                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter mda = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    mda.Fill(dt);
                    dataGridView.DataSource = dt;
                }

                MessageBox.Show("Вывод данных обновлён.");
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                int id = Convert.ToInt32(textBox1.Text);

                // Удаление записей из таблиц
                string deleteQuery1 = $"DELETE FROM table1 WHERE table1.ID = {id}";
                string deleteQuery2 = $"DELETE FROM table2 WHERE table2.ID = {id}";

                using (MySqlCommand deleteCommand1 = new MySqlCommand(deleteQuery1, conn))
                {
                    deleteCommand1.ExecuteNonQuery();
                }

                using (MySqlCommand deleteCommand2 = new MySqlCommand(deleteQuery2, conn))
                {
                    deleteCommand2.ExecuteNonQuery();
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
    }
}

