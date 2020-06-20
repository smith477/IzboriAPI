using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Glasacka_Mesta_View
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual int Broj_biraca { get; set; }
        public virtual int Broj_mesta { get; set; }
        public virtual IList<Aktivista_Stranke_View> Aktivisti { get; set; }
        public virtual IList<Primedbe_View> Primedbe { get; set; }
        public virtual IList<Rezultati_View> Rezultati { get; set; }

        public Glasacka_Mesta_View()
        {
            Aktivisti = new List<Aktivista_Stranke_View>();
            Primedbe = new List<Primedbe_View>();
            Rezultati = new List<Rezultati_View>();
        }
        public Glasacka_Mesta_View(Glasacka_Mesta gm)
        {
            Id = gm.Id;
            Naziv = gm.Naziv;
            Broj_biraca = gm.Broj_biraca;
            Broj_mesta = gm.Broj_mesta;
        }
    }
}
