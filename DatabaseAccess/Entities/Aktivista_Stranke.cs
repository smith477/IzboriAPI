using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Aktivista_Stranke
    {
        public virtual int Id { get; protected set; }
        public virtual string Licno_ime { get; set; }
        public virtual string Ime_roditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime Datum_rodjenja { get; set; }
        public virtual string Ulica { get; set; }
        public virtual string Broj { get; set; }

        public virtual IList<Email> Email { get; set; }

        public virtual IList<Telefon> Telefon { get; set; }

        public virtual IList<Akcije> Akcije { get; set; }

        //Ostalo je ID_Glasackog_mesta
        //ID_Koordinatora_opstine
        public virtual Glasacka_Mesta PratiGlasackoMesto { get; set; }

        public Aktivista_Stranke()
        {
            Email = new List<Email>();
            Telefon = new List<Telefon>();
            Akcije = new List<Akcije>();

        }
    }

    //public class Koordinator_Opstine : Aktivista_Stranke
    //{
    //    public virtual string Ime_opstine { get; set; }
    //    public virtual string Adresa_kancelarije { get; set; }
    //}
}
