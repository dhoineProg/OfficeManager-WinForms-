using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using OfficeManager.Classes;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace OfficeManager.Classes
{
    public class DataRepository
    {
        static void GetData()
        {
            MySqlConnection conn = DBConnection.GetDBConnection();

            List<MyData> mydates = new List<MyData> ();
            try
            {
                using (conn)
                {
                    conn.Open();

                    string selectQuery = "SELECT * FROM table1";

                    using (MySqlCommand comm = new MySqlCommand(selectQuery, conn))
                    using (MySqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MyData mydata = new MyData
                            {
                                ID = reader.GetInt32("ID"),
                                FName = reader.GetString("FirstName"),
                                LName = reader.GetString("LastName"),
                                Age = reader.GetInt32("Age"),
                                Education = reader.GetString("Education"),
                            };

                            mydates.Add(mydata);
                        }
                    }
                    string selectQuery2 = "SELECT * FROM table2";

                    using (MySqlCommand comm = new MySqlCommand(selectQuery2, conn))
                    using (MySqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MyData mydata = new MyData
                            {
                                ID = reader.GetInt32("ID"),
                                Salary = reader.GetInt32("Salary"),
                                Currency = reader.GetString("Currency"),
                            };

                            mydates.Add(mydata);
                        }
                    }
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
