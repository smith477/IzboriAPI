using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Deljenje_Letki_View : Akcije_View
    {
        public virtual string Grad { get; set; }
        public virtual IList<Lokacije_View> Lokacije { get; set; }

        public Deljenje_Letki_View()
        {
            Lokacije = new List<Lokacije_View>();
        }

        public Deljenje_Letki_View(Deljenje_Letki dl) : base(dl)
        {
            Grad = dl.Grad;
        }
    }
}
