using IRF_Projekt_1.Entities;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            
        }
         

        
       
        //DataTable table = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {

           /*Form2 f2 = new Form2();

            string path = "C:\\Temp\\Résztvevők.xml";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();




            foreach (DataGridViewColumn col in f2.dataGridView1.Columns)

            {

                dt.Columns.Add(col.DataPropertyName, col.ValueType);

            }

            //adding new rows

            foreach (DataGridViewRow row in f2.dataGridView1.Rows)

            {

                DataRow row1 = dt.NewRow();

                for (int i = 0; i < f2.dataGridView1.ColumnCount; i++)

                    //if value exists add that value else add Null for that field

                    row1[i] = (row.Cells[i].Value == null ? DBNull.Value : row.Cells[i].Value);

                dt.Rows.Add(row1);

            }

            //Copying from datatable to dataset

            ds.Tables.Add(dt);

            //writing new values to XML

            ds.WriteXml(path);

            MessageBox.Show("Successfully added ", "Success");

            this.Close();




            Személy n = new Személy();
            n.SzületésiÉv = Int32.Parse(textBox1.Text);
            n.Nem = Int32.Parse(textBox2.Text) == 1 ? Nem.Male : Nem.Female;
            n.AlkoholistaÉv = Int32.Parse(textBox3.Text);

            //table = f2.dataGridView1;
            DataGridView table = f2.dataGridView1;
            int t = 0;


            f2.dataGridView1.Rows.Insert(0, "one", "2");

            
                        row.Cells[0].Value = 1;
                        row.Cells[1].Value = 1;
                        row.Cells[2].Value = 3;
          
            //f2.dataGridView1.Rows.Add(row);

            int n = f2.dataGridView1.Rows.Add();
            f2.dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
            f2.dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
            f2.dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;*/
    
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        } 
    }
}
