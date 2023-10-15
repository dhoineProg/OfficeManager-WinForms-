using MySql.Data.MySqlClient;
using OfficeManager.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace OfficeManager
{
    public partial class DataView : Form
    {
        MySqlConnection conn = DBConnection.GetDBConnection();

        public DataView()
        {
            InitializeComponent();
        }

        private void DataView_Load(object sender, EventArgs e)
        {
            DataExecute();
        }

        public void DataExecute()
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM table1";
                string query2 = "SELECT * FROM table2";

                DataSet dataSet = new DataSet();

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter mda = new MySqlDataAdapter(command);
                    mda.Fill(dataSet, "Table1Data");
                }

                using (MySqlCommand command = new MySqlCommand(query2, conn))
                {
                    MySqlDataAdapter mda = new MySqlDataAdapter(command);
                    mda.Fill(dataSet, "Table2Data");
                }
                dataGridView.DataSource = dataSet.Tables["Table1Data"];
                dataGridView1.DataSource = dataSet.Tables["Table2Data"];
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

        private void RefreshData()
        {
            try
            {
                conn.Open();
                MessageBox.Show("Вывод данных обновлён.");

                string query = $"SELECT * FROM table1";
                string query2 = $"SELECT * FROM table2";

                /*  При выводе выше, мы используем два dataGridView, если же был бы 1, то запрос вывода бы выглядел следующим образом
                    SELECT * FROM employeDetails
                    JOIN otherDetails ON employeDetails.ID = otherDetails.ID;  
                    При таком запросе, удастся избежать повторений в таблице.
                 */

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    DataTable dateTable = new DataTable();
                    MySqlDataAdapter mda = new MySqlDataAdapter(command);
                    mda.Fill(dateTable);
                    dataGridView.DataSource = dateTable;
                }
                using (MySqlCommand command = new MySqlCommand(query2, conn))
                {
                    DataTable dateTable = new DataTable();
                    MySqlDataAdapter mda = new MySqlDataAdapter(command);
                    mda.Fill(dateTable);
                    dataGridView1.DataSource = dateTable;
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

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                using (MySqlCommand comm = new MySqlCommand("CalculateAVG", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            double averageAge = Convert.ToDouble(reader["avgAge"]);
                            textBox1.Text = $"{averageAge}"; 
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при выполнении процедуры.");
                        }
                    }
                }
            }catch(Exception ex)
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