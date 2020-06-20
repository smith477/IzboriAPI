using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Duel : Pojavljivanje_U_Medijima
    {
        public virtual IList<Protivkandidati> Protivkandidati { get; set; }
        public virtual IList<Pitanja> Pitanja { get; set; }
        public Duel()
        {
            Protivkandidati = new List<Protivkandidati>();
            Pitanja = new List<Pitanja>();
        }
    }
}
