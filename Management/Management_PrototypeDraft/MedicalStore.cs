using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Management_PrototypeDraft
{
    public partial class MedicalStoreForm : Form
    {
        public MedicalStoreForm()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        int selectedRow;

        private void MedicalStoreForm_Load(object sender, EventArgs e)
        {
            lbl_Date.Text = DateTime.Now.ToLongDateString();
            timer1.Start();

            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Supplied Date", typeof(string));
            table.Columns.Add("Discription", typeof(string));

            datagrid.DataSource = table;
        }

        private void datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = datagrid.Rows[selectedRow];

            txtBoxID.Text = row.Cells[0].Value.ToString();
            txtBoxName.Text = row.Cells[1].Value.ToString();
            txtBoxSuDate.Text = row.Cells[2].Value.ToString();
            txtBoxDiscription.Text = row.Cells[3].Value.ToString();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtBoxID.Text, txtBoxName.Text, txtBoxSuDate.Text, txtBoxDiscription.Text);
            datagrid.DataSource = table;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            DataGridViewRow updatedRow = datagrid.Rows[selectedRow];
            updatedRow.Cells[0].Value = txtBoxID.Text;
            updatedRow.Cells[1].Value = txtBoxName.Text;
            updatedRow.Cells[2].Value = txtBoxSuDate.Text;
            updatedRow.Cells[3].Value = txtBoxDiscription.Text;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            datagrid.Rows.RemoveAt(selectedRow);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Data\MedStoreData.txt", true);
            sw.WriteLine("=================Medical Store`S DATA==================");

            for (int i = 0; i < datagrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < datagrid.Columns.Count; j++)
                {

                    sw.Write("  " + datagrid.Rows[i].Cells[j].Value.ToString() + "  " + "|");

                }
                sw.WriteLine("");
                sw.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
            }
            sw.WriteLine(lbl_Date.Text + "                                                                                   " + lbl_Time.Text);
            sw.WriteLine("__________________________________________________________________________________________________________________________________________");
            sw.Close();
            MessageBox.Show("Data Saved Successfully", "Backed Up!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader se = new StreamReader(@"Data\MedStoreData.txt");
            string a = se.ReadToEnd();
            richTextBox1.Text = a;
            se.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
