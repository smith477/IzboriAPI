using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Koordinator_Opstine : Aktivista_Stranke
    {
        public virtual string Adresa_Kancelarije { get; set; }
        public virtual string Ime_Opstine { get; set; }

        public virtual IList<Izborne_Aktivnosti> Izborne_Aktivnosti { get; set; }

        public Koordinator_Opstine()
        {
            Izborne_Aktivnosti = new List<Izborne_Aktivnosti>();
        }
    }
}
