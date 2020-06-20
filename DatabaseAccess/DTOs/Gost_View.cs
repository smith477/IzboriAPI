using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Gost_View
    {
        public virtual GostId_View Id { get; set; }
        public virtual string Licno_Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Titula { get; set; }

        public Gost_View()
        {
        }

        public Gost_View(Gost g)
        {
            Id = new GostId_View(g.Id);
            Licno_Ime = g.Licno_Ime;
            Prezime = g.Prezime;
            Titula = g.Titula;
        }
    }
}
