using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Akcije_View : Izborne_Aktivnosti_View
    {
        public virtual IList<Aktivista_Stranke_View> Aktivisti { get; set; }

        public Akcije_View() 
        {
            Aktivisti = new List<Aktivista_Stranke_View>();
        }

        public Akcije_View(Akcije a) : base(a)
        {
        }
    }
}
