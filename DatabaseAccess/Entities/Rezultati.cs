using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Rezultati
    {
        public virtual RezultatiId Id { get; set; }
        public virtual int Broj_Biraca { get; set; }
        public virtual int Procenat_Glasanja { get; set; }
        public virtual int Krug_Izbora { get; set; }

        public Rezultati()
        {
            Id = new RezultatiId();
        }
    }
}
