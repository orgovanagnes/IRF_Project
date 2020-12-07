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
           /* Form3 f3 = new Form3();

            if (f3.ShowDialog() == DialogResult.OK)
            {
                dolgozo = new Dolgozok();
                dolgozo.Név = f3.textBox1.Text;
                dolgozo.Születési_dátum = DateTime.Parse(f3.textBox2.Text);
                dolgozo.Cím = f3.textBox3.Text;
                dolgozo.Fizetés = Int32.Parse(f3.textBox4.Text);
                dolgozo.BeosztásFK = Int32.Parse(f3.textBox5.Text);

                context.Dolgozoks.Add(dolgozo);
                context.SaveChanges();

                Listázás();

            }*/
        }
    }
}
