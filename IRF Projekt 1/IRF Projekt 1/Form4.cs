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
using System.Windows;
using System.Windows.Forms;

namespace IRF_Projekt_1
{
    public partial class Form4 : Form
    {

        List<Személy> Személyek = new List<Személy>();
        List<AlkoholistaVSZ> AlkoholistaVSZs = new List<AlkoholistaVSZ>();
        List<NemAlkoholistaVSZ> NemAlkoholistaVSZs = new List<NemAlkoholistaVSZ>();

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


        public List<AlkoholistaVSZ> GetAlkoholistaVSZs(string csvpath)
        {
            List<AlkoholistaVSZ> AlkoholistaVSZs = new List<AlkoholistaVSZ>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    AlkoholistaVSZs.Add(new AlkoholistaVSZ()
                    {
                        Kor = int.Parse(line[0]),
                        AlkoholistaÉv = int.Parse(line[1]),
                        Valószínűség = double.Parse(line[2])
                    });
                }
            }

            return AlkoholistaVSZs;
        }

        public List<NemAlkoholistaVSZ> GetNemAlkoholistaVSZs(string csvpath)
        {
            List<NemAlkoholistaVSZ> NemAlkoholistaVSZs = new List<NemAlkoholistaVSZ>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    NemAlkoholistaVSZs.Add(new NemAlkoholistaVSZ()
                    {
                        Kor = int.Parse(line[0]),
                        Gender = (Nem)Enum.Parse(typeof(Nem), line[1]),
                        Valószínűség = double.Parse(line[2])
                    });
                }
            }

            return NemAlkoholistaVSZs;
        }




        public Form4()
        {
            InitializeComponent();

            Személyek = GetSzemélyek(@"C:\Temp\Résztvevők.csv");
            AlkoholistaVSZs = GetAlkoholistaVSZs(@"C:\Temp\Alkoholista.csv");
            NemAlkoholistaVSZs = GetNemAlkoholistaVSZs(@"C:\Temp\Nem_Alkoholista.csv");

            // dataGridView1.DataSource = AlkoholistaVSZs;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            int minYear = 99999;
            int maxYear = 1;

            int minAlkoholistaÉv = 9999;
            int maxAlkholistaÉV = 1;

            // csak a férfiakat tekintve a szélső értékek (legkisebb / legnagyobb évszám --- hány éves alkholisták - min/max)

            for (int i = 0; i < Személyek.Count; i++)
            {
                Személy személy = Személyek[i];
                if (személy.Nem == Nem.Female) continue;

                if (személy.SzületésiÉv > maxYear)
                {
                    maxYear = személy.SzületésiÉv;
                }

                if (személy.SzületésiÉv < minYear)
                {
                    minYear = személy.SzületésiÉv;
                }

                if (személy.AlkoholistaÉv > maxAlkholistaÉV)
                {
                    maxAlkholistaÉV = személy.AlkoholistaÉv;
                }

                if (személy.AlkoholistaÉv < minAlkoholistaÉv)
                {
                    minAlkoholistaÉv = személy.AlkoholistaÉv;
                }
            }


            for (int year = minYear; year < maxYear; year++)
            {
             //random szám felhasználása
                       
                int hanyEveVagyokAlkoholistaFerfi = rng.Next(minAlkoholistaÉv, maxAlkholistaÉV);
                int numberOfFerfi = (from x in Személyek
                                     where x.SzületésiÉv == year && x.Nem == Nem.Male && x.AlkoholistaÉv >= hanyEveVagyokAlkoholistaFerfi
                                     select x).Count();
               
                {

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\output.txt", true))
                    {
                     file.WriteLine(string.Format("{0}-ban/ben {1} férfi született, aki(k) {2} éve alkoholisták.", year, numberOfFerfi, hanyEveVagyokAlkoholistaFerfi));
                    }

                }  
                    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //visszaesők száma

            int jovorevisszaesok = (from z in NemAlkoholistaVSZs
                                    where z.Valószínűség >= 0.05
                                    select z).Count();

         //Hányan maradnak alkoholisták?

            int jovorealkoholista = (from y in AlkoholistaVSZs
                                     where y.Valószínűség >= 0.5
                                     select y).Count();

            int mindenki = jovorealkoholista + jovorevisszaesok;


            System.Windows.Forms.MessageBox.Show("Jövőre a visszaesők és nem kigyógyultak száma: " + mindenki + " személy", "Előrejelzés", MessageBoxButtons.OK);
            // MessageBox.Show(string.Format("Jövőre a visszaesők és nem kigyógyultak száma: {0}", mindenki));
        }
    }
}
