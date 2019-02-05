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
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();

        }

        DataTable table = new DataTable();
        int selectedRow;

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            lbl_Date.Text = DateTime.Now.ToLongDateString();
            timer1.Start();

            //adding columns header text on form load
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Gender", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("Field of Specialization", typeof(string));

            //putting the above data into datagrid Doctor
           datagridDoctor.DataSource = table;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            //when clicked on add, all the text from text box`s will be put in data grid row,column by column
            table.Rows.Add(txtBoxID.Text, txtBoxName.Text, cmBoxGender.Text, txtBoxAge.Text, txtBoxField.Text);

            //putting the above data into datagrid Doctor
            datagridDoctor.DataSource = table;

        }

        private void datagridDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //when a cell is clicked, it will pass its row index no. to the int variable selected row
            selectedRow = e.RowIndex;

            DataGridViewRow row = datagridDoctor.Rows[selectedRow];

            //giving index`s to the coloumns
            txtBoxID.Text = row.Cells[0].Value.ToString();
            txtBoxName.Text = row.Cells[1].Value.ToString();
            cmBoxGender.Text = row.Cells[2].Value.ToString();
            txtBoxAge.Text = row.Cells[3].Value.ToString();
            txtBoxField.Text = row.Cells[4].Value.ToString();

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            //updating the selected row
            DataGridViewRow updatedRow = datagridDoctor.Rows[selectedRow];
            updatedRow.Cells[0].Value = txtBoxID.Text;
            updatedRow.Cells[1].Value = txtBoxName.Text;
            updatedRow.Cells[2].Value = cmBoxGender.Text;
            updatedRow.Cells[3].Value = txtBoxAge.Text;
            updatedRow.Cells[4].Value = txtBoxField.Text;


        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            //removing the row selected or highlited
            datagridDoctor.Rows.RemoveAt(selectedRow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //path should be changed as for executable file
            StreamWriter sw = new StreamWriter(@"Data\DoctorData.txt", true);
            sw.WriteLine("=============================DOCTOR`S DATA============================");

            for (int i = 0; i < datagridDoctor.Rows.Count-1; i++) // -1 is b/c the row is always one extra in table in the last so neglecting it by doing -1
            {
                for (int j = 0; j < datagridDoctor.Columns.Count; j++)
                {
                    
                    sw.Write("  " + datagridDoctor.Rows[i].Cells[j].Value.ToString()+"  "+"|");

                }
                sw.WriteLine("");
                sw.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
            }
            sw.WriteLine(lbl_Date.Text + "                                                                                   " + lbl_Time.Text);
            sw.WriteLine("__________________________________________________________________________________________________________________________________________");
            sw.Close();
            MessageBox.Show("Data Saved Successfully","Backed Up!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //path should be changed as for executable file
            StreamReader sr = new StreamReader(@"Data\DoctorData.txt");
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
