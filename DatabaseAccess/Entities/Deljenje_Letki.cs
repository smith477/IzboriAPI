using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Deljenje_Letki : Akcije
    {
        public virtual string Grad { get; set; }

        public virtual IList<Lokacije> Lokacije { get; set; }
        
        public Deljenje_Letki()
        {
            Lokacije = new List<Lokacije>();
        }
    }
}
