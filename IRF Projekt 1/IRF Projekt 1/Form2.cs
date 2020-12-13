using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            DataSet ds = new DataSet();
            ds.ReadXml("C:/Temp/Résztvevők.xml");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CSV fájlba írás 

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

        private void Form2_Load(object sender, EventArgs e)
        {

            textBox1.Multiline = true;

        }
    }
}
