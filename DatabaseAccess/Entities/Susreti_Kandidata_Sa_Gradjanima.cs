using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Susreti_Kandidata_Sa_Gradjanima : Akcije
    {
        public virtual string Grad { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual DateTime Vreme { get; set; }

        public Susreti_Kandidata_Sa_Gradjanima()
        {

        }
    }
}
