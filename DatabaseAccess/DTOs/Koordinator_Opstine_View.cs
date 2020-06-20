using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Koordinator_Opstine_View : Aktivista_Stranke_View
    {
        public virtual string Adresa_Kancelarije { get; set; }
        public virtual string Ime_Opstine { get; set; }

        public virtual IList<Izborne_Aktivnosti_View> Izborne_Aktivnosti { get; set; }
        
        public Koordinator_Opstine_View()
        {
            Izborne_Aktivnosti = new List<Izborne_Aktivnosti_View>();
        }

        public Koordinator_Opstine_View(Koordinator_Opstine ko) : base(ko)
        {
            Adresa_Kancelarije = ko.Adresa_Kancelarije;
            Ime_Opstine = ko.Ime_Opstine;
        }
    }
}
