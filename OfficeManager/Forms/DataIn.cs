using MySql.Data.MySqlClient;
using OfficeManager.Classes;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Xml;


namespace OfficeManager.Forms
{
    public partial class DataIn : Form
    {

        public DataIn()
        {
            InitializeComponent();
        }

        private void DataIn_Load(object sender, EventArgs e)
        {
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string firstTable = $"INSERT INTO table1(FirstName, LastName, Age, Education) VALUES (@fname, @lname, @age, @edc)";
            string secondTable = $"INSERT INTO table2(Salary, Currency) VALUES (@salary, @currency)";
            try
            {
                using (MySqlConnection conn = DBConnection.GetDBConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand(firstTable, conn))
                    {
                        command.Parameters.AddWithValue("@fname", textBox1.Text);
                        command.Parameters.AddWithValue("@lname", textBox2.Text);
                        command.Parameters.AddWithValue("@age", textBox3.Text);
                        command.Parameters.AddWithValue("@edc", textBox4.Text);
                        command.ExecuteNonQuery();
                    }
                    using (MySqlCommand command = new MySqlCommand(secondTable, conn))
                    {
                        command.Parameters.AddWithValue("@salary", textBox5.Text);
                        command.Parameters.AddWithValue("@currency", textBox6.Text);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Данные успешно добавлены в базу данных.");
                    conn.Close();
                    DataIn di = new DataIn();
                    di.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
