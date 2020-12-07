using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Projekt_1.Entities
{
    public class Személy
    {
        public int SzületésiÉv { get; set; }
        public Nem Nem { get; set; }
        public int AlkoholistaÉv { get; set; }
        public bool Alkoholista { get; set; }

        public Személy()
        {
            Alkoholista = true;
        }
    }
}
