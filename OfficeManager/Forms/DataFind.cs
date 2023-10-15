using MySql.Data.MySqlClient;
using OfficeManager.Classes;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;

namespace OfficeManager.Forms
{
    public partial class DataFind : Form
    {
        MySqlConnection conn = DBConnection.GetDBConnection();

        public DataFind()
        {
            InitializeComponent();
        }

        private void DataFind_Load(object sender, EventArgs e)
        {

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            try
            {
                conn.Open();
                async Task FilterDataAsync()
                {
                    string sqlQuery = $"SELECT * FROM table1 " +
                    $"JOIN table2 ON table1.ID = table2.ID " +
                    $"WHERE LastName LIKE @inputText";
                    using (MySqlCommand comm = new MySqlCommand(sqlQuery, conn))
                    {
                        comm.Parameters.AddWithValue("@inputText", inputText + "%");
                        using (MySqlDataReader reader = (MySqlDataReader)await comm.ExecuteReaderAsync())
                        {
                            DataTable table = new DataTable();
                            table.Load(reader);
                            dataGridView1.DataSource = table;
                        }
                    }
                }

                await FilterDataAsync();
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
