using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Politicki_Miting : Akcije
    {
        public virtual string Lokacija { get; set; }
        public virtual string Mesto { get; set; }
        public virtual int Na_Otvorenom { get; set; }

        public virtual IList<Gost> Gosti { get; set; }

        public Politicki_Miting()
        {
            Gosti = new List<Gost>();
        }

    }
}
