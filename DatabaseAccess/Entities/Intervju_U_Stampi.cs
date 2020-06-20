using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Intervju_U_Stampi : Pojavljivanje_U_Medijima
    {
        public virtual string Naziv { get; set; }
        public virtual DateTime DatumIntervjua { get; set; }
        public virtual DateTime DatumObjavljivanja { get; set; }
        public virtual string Novinar { get; set; }
    }
}
