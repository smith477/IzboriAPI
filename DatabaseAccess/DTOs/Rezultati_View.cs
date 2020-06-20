using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Rezultati_View
    {
        public virtual RezultatiID_View Id { get; set; }
        public virtual int Broj_Biraca { get; set; }
        public virtual int Procenat_Glasanja { get; set; }
        public virtual int Krug_Izbora { get; set; }

        public Rezultati_View() { }

        public Rezultati_View(Rezultati r)
        {
            Id = new RezultatiID_View(r.Id);
            Broj_Biraca = r.Broj_Biraca;
            Procenat_Glasanja = r.Procenat_Glasanja;
            Krug_Izbora = r.Krug_Izbora;
        }
    }
}
