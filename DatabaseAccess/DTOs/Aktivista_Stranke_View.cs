using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Aktivista_Stranke_View
    {
        public virtual int Id { get; set; }
        public virtual string Licno_ime { get; set; }
        public virtual string Ime_roditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime Datum_rodjenja { get; set; }
        public virtual string Ulica { get; set; }
        public virtual string Broj { get; set; }

        public virtual IList<Email_View> Email { get; set; }

        public virtual IList<Telefon_View> Telefon { get; set; }

        public virtual IList<Akcije_View> Akcije { get; set; }

        public Aktivista_Stranke_View() 
        {
            Email = new List<Email_View>();
            Telefon = new List<Telefon_View>();
            Akcije = new List<Akcije_View>();

        }

        public Aktivista_Stranke_View(Aktivista_Stranke astranke)
        {
            if(astranke == null)
            {
                return;
            }
            Id = astranke.Id;
            Licno_ime = astranke.Licno_ime;
            Ime_roditelja = astranke.Ime_roditelja;
            Prezime = astranke.Prezime;
            Datum_rodjenja = astranke.Datum_rodjenja;
            Ulica = astranke.Ulica;
            Broj = astranke.Broj;
        }
    }
}
