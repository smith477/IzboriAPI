using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Izborne_Aktivnosti_View
    {
        public virtual int Id { get; protected set; }
        public virtual Koordinator_Opstine_View Koordinator { get; set; }

        public Izborne_Aktivnosti_View() { }

        public Izborne_Aktivnosti_View(Izborne_Aktivnosti ia)
        {
            Id = ia.Id;
            Koordinator = new Koordinator_Opstine_View(ia.Koordinator);
        }
    }
}
