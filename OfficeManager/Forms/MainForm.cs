using OfficeManager.Forms;
using System;
using System.Windows.Forms;

namespace OfficeManager
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DataView"] != null)
            {
                MessageBox.Show("Form is open!");
            }
            else
            {
                DataView dv = new DataView();
                dv.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DataIn"] != null)
            {
                MessageBox.Show("Form is open!");
            }
            else
            {
                DataIn di = new DataIn();
                di.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DataEdit"] != null)
            {
                MessageBox.Show("Form is open!");
            }
            else
            {
                DataEdit de = new DataEdit();
                de.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DeleteData"] != null)
            {
                MessageBox.Show("Form is open!");
            }
            else
            {
                DeleteData dd = new DeleteData();
                dd.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DataFind"] != null)
            {
                MessageBox.Show("Form is open!");
            }
            else
            {
                DataFind df = new DataFind();
                df.Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
