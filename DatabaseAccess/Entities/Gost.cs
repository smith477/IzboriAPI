using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Gost
    {
        public virtual GostId Id { get; set; }
        public virtual string Licno_Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Titula { get; set; }
        //public virtual IList<Funkcije> Funkcije {get; set;}

    public Gost()
    {
            Id = new GostId();
            //Funkcije = new List<Funkcije>();
    }
    }
}
