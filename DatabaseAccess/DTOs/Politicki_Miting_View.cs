using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Politicki_Miting_View : Akcije_View
    {
        public virtual string Lokacija { get; set; }
        public virtual string Mesto { get; set; }
        public virtual int Na_Otvorenom { get; set; }

        public virtual IList<Gost_View> Gosti { get; set; }

        public Politicki_Miting_View()
        {
            Gosti = new List<Gost_View>();
        }

        public Politicki_Miting_View(Politicki_Miting pm) : base(pm)
        {
            Lokacija = pm.Lokacija;
            Mesto = pm.Mesto;
            Na_Otvorenom = pm.Na_Otvorenom;
        }

    }
}
