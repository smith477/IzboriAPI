using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class Susreti_Kandidata_Sa_Gradjanima_View : Akcije_View
    {
        public virtual string Grad { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual DateTime Vreme { get; set; }

        public Susreti_Kandidata_Sa_Gradjanima_View() { }

        public Susreti_Kandidata_Sa_Gradjanima_View(Susreti_Kandidata_Sa_Gradjanima sksg) : base(sksg)
        {
            Grad = sksg.Grad;
            Lokacija = sksg.Lokacija;
            Vreme = sksg.Vreme;
        }
    }
}
