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

        DataTable table = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 f2 = new Form2();


            /*Személy n = new Személy();
            n.SzületésiÉv = Int32.Parse(textBox1.Text);
            n.Nem = Int32.Parse(textBox2.Text) == 1 ? Nem.Male : Nem.Female;
            n.AlkoholistaÉv = Int32.Parse(textBox3.Text);
*/
            //table = f2.dataGridView1;
            DataGridView table = f2.dataGridView1;
            int t = 0;


            f2.dataGridView1.Rows.Insert(0, "one", "2");

            /*
                        row.Cells[0].Value = 1;
                        row.Cells[1].Value = 1;
                        row.Cells[2].Value = 3;
            */
            //f2.dataGridView1.Rows.Add(row);
/*
            int n = f2.dataGridView1.Rows.Add();
            f2.dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
            f2.dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
            f2.dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
        */}
    }
}
