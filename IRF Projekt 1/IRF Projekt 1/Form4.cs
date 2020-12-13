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
                        Kor = int.Parse(line[1]),
                        Gender = (Nem)Enum.Parse(typeof(Nem), line[0]),
                        Valószínűség = double.Parse(line[2])
                    });
                }
            }

            return NemAlkoholistaVSZs;
        }

        List<Személy> Személyek = new List<Személy>();
        List<AlkoholistaVSZ> AlkoholistaVSZs = new List<AlkoholistaVSZ>();
        List<NemAlkoholistaVSZ> NemAlkoholistaVSZs = new List<NemAlkoholistaVSZ>();



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
                /*
                    for (int i = 0; i < Személyek.Count; i++)
                    {
                        Személy személy = Személyek[i];
                        if (!személy.Alkoholista) continue;

                        byte kor = (byte)(year - személy.SzületésiÉv);

                        double pnemalkoholista = (from x in NemAlkoholistaVSZs
                                               where x.Gender == személy.Nem && x.Kor == kor + 1
                                               select x.Valószínűség).First();
                        if (rng.NextDouble() <= pnemalkoholista) személy.Alkoholista = false;


                        double palkoholista = (from x in AlkoholistaVSZs
                                               where x.Kor == kor
                                               select x.Valószínűség).FirstOrDefault();

                        if (rng.NextDouble() <= palkoholista)
                        {
                        
                        }



                    }
                    */
                //            }

                //}

               
                int hanyEveVagyokAlkoholista = rng.Next(minAlkoholistaÉv, maxAlkholistaÉV);
                int numberOfEmber = (from x in Személyek
                                     where x.SzületésiÉv == year && x.Nem == Nem.Male && x.AlkoholistaÉv == hanyEveVagyokAlkoholista
                                     select x).Count();
                /*int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();*/
                //Console.WriteLine(
                //    string.Format("Év:{0} Fiuk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Temp\output.txt", true))
                {
                    file.WriteLine(string.Format("Év:{0} // Hány éve alkholista: {1} // Db ember:{2}", year, hanyEveVagyokAlkoholista, numberOfEmber));
                }
            }
        }
    }
}
