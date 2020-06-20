using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Gostovanja : Pojavljivanje_U_Medijima
    {
        public virtual int ProcenjenaGledanost { get; set; }
        public virtual string NazivEmisije { get; set; }
        public virtual string NazivMedija { get; set; }
        public virtual string Voditelj { get; set; }
    }
}
