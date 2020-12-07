using IRF_Projekt_1.Entities;
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

namespace IRF_Projekt_1
{
    public partial class Form4 : Form
    {
        List<Személy> Személyek = new List<Személy>();
        List<AlkoholistaVSZ> AlkoholistaVSZs = new List<AlkoholistaVSZ>();
        List<NemAlkoholistaVSZ> NemAlkoholistaVSZs = new List<NemAlkoholistaVSZ>();

        public Form4()
        {
            InitializeComponent();

            Személyek = GetSzemélyek(@"C:\Temp\Résztvevők.csv");
            dataGridView1.DataSource = Személyek;
            
        }

        public List<Személy> GetSzemélyek(string csvpath)
        {
            List<Személy> Személyek = new List<Személy>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    Személyek.Add(new Személy()
                    {
                        SzületésiÉv = int.Parse(line[0]),
                        Nem = (Nem)Enum.Parse(typeof(Nem), line[1]),
                        AlkoholistaÉv = int.Parse(line[2])
                    });
                }
            }

            return Személyek;
        }

    }
}
