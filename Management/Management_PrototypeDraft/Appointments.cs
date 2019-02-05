using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_PrototypeDraft
{
    public partial class AppointmentsForm : Form
    {
        public AppointmentsForm()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        int selectedRow;

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            lbl_Date.Text = DateTime.Now.ToLongDateString();
            timer1.Start();

            table.Columns.Add("Patient",typeof(string));
            table.Columns.Add("Date", typeof(string));
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Doctor", typeof(string));

            datagrid.DataSource = table;
        }

        private void datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = datagrid.Rows[selectedRow];

            txtBoxName.Text = row.Cells[0].Value.ToString();
            textBoxDate.Text = row.Cells[1].Value.ToString();
            txtBoxTime.Text = row.Cells[2].Value.ToString();
            txtBoxDoctor.Text = row.Cells[3].Value.ToString();


        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            table.Rows.Add( txtBoxName.Text, textBoxDate.Text, txtBoxTime.Text, txtBoxDoctor.Text);
            datagrid.DataSource = table;
        }

        private void button_update_Click(object sender, EventArgs e)
        {

            DataGridViewRow updatedRow = datagrid.Rows[selectedRow];
            updatedRow.Cells[0].Value = txtBoxName.Text;
            updatedRow.Cells[1].Value = textBoxDate.Text;
            updatedRow.Cells[2].Value = txtBoxTime.Text;
            updatedRow.Cells[3].Value = txtBoxDoctor.Text;
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
        { //path should be changed as for executable file
            StreamWriter sw = new StreamWriter(@"Data\AppointmentData.txt", true);
            sw.WriteLine("===========APPOINTMENT`S DATA============");

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
        { //path should be changed as for executable file
            StreamReader sr = new StreamReader(@"Data\AppointmentData.txt");
            string a = sr.ReadToEnd();
            richTextBox1.Text = a;
            sr.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
