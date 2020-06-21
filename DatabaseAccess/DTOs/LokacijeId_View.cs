using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class LokacijeId_View
    {
        //public virtual Deljenje_Letki_View Deljenje_Letki { get; set; }
        public virtual string Lokacija { get; set; }

        public LokacijeId_View() { }

        public LokacijeId_View(LokacijeId lid)
        {
            //Deljenje_Letki = new Deljenje_Letki_View(lid.Deljenje_Letki);
            Lokacija = lid.Lokacija;
        }
    }
}
