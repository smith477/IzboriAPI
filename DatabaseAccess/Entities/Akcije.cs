using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Akcije : Izborne_Aktivnosti
    {
        public virtual IList<Aktivista_Stranke> Aktivisti { get; set; }
        public Akcije()
        {
            Aktivisti = new List<Aktivista_Stranke>();
        }
    }
}
