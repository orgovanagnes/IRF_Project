using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Projekt_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //XML beolvasása

            DataSet ds = new DataSet();
            ds.ReadXml("C:/Temp/Résztvevők.xml");
          
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = item["Születési_Év"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Nem"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Alkoholista_Év"].ToString();
            }
       
        }

        private void Form2_Load(object sender, EventArgs e)
        { 

            textBox1.Width = 100;
            textBox1.Height = 200;
            textBox1.Multiline = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sor törlése

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CSV fájlba írás, ezt a későbbiekben beolvasam és felhasználom

            int count_row = dataGridView1.RowCount;
            int count_cell = dataGridView1.Rows[0].Cells.Count;

            for (int row_index = 0; row_index < count_row - 2; row_index++)
            {
                for (int cell_index = 0; cell_index < count_cell; cell_index++)
                {
                    textBox1.Text = textBox1.Text + dataGridView1.Rows[row_index].Cells[cell_index].Value.ToString() + ";";
                }
                textBox1.Text = textBox1.Text + "\r\n";
            }

            System.IO.File.WriteAllText(@"C:\Temp\Résztvevők.csv", textBox1.Text);

        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            //új adatok hozzáadása

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBox2.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBox5.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBox4.Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //XML mentése
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
           
            dt.TableName = "Résztvevők";
            dt.Columns.Add("Születési_Év");
            dt.Columns.Add("Nem");
            dt.Columns.Add("Alkoholista_Év");
            ds.Tables.Add(dt);


            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row = ds.Tables[0].NewRow();
                row["Születési_Év"] = r.Cells[0].Value.ToString();
                row["Nem"] = r.Cells[1].Value.ToString();
                row["Alkoholista_Év"] = r.Cells[2].Value.ToString();
                ds.Tables[0].Rows.Add(row);
            }

            ds.WriteXml("C:\\Temp\\Résztvevőkoutpot.xml");
            


        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            Regex r = new Regex(@"^[1-2]{1}$");

            if (!r.IsMatch(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.BackColor = Color.Red;
            }
            else
            {
                textBox5.BackColor = Color.LightGreen;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
