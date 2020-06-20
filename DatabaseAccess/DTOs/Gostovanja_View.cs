using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Gostovanja_View : Pojavljivanje_U_Medijima_View
    {
        public virtual int ProcenjenaGledanost { get; set; }
        public virtual string NazivEmisije { get; set; }
        public virtual string NazivMedija { get; set; }
        public virtual string Voditelj { get; set; }

        public Gostovanja_View() { }

        public Gostovanja_View(Gostovanja g)
        {
            ProcenjenaGledanost = g.ProcenjenaGledanost;
            NazivEmisije = g.NazivEmisije;
            NazivMedija = g.NazivMedija;
            Voditelj = g.Voditelj;
        }
    }
}
