using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Izborne_Aktivnosti
    {
        public virtual int Id { get; protected set; }

        public virtual Koordinator_Opstine Koordinator { get; set; }

        public Izborne_Aktivnosti()
        {
            Koordinator = new Koordinator_Opstine();
        }
    }
}
