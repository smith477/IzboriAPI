using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Reklame : Izborne_Aktivnosti
    {
        public virtual DateTime TrajanjeOd { get; set; }
        public virtual DateTime TrajanjeDo { get; set; }
        public virtual int Cena { get; set; }
    }
    public class Mediji : Reklame
    {
        public virtual int BrojEmitovanja { get; set; }
        public virtual int TrajanjeReklame { get; set; }
        public virtual string NazivMedija { get; set; }
    }
    public class Pano : Reklame
    {
        public virtual string Grad { get; set; }
        public virtual string Agencija { get; set; }
        public virtual string Ulica { get; set; }
        public virtual string Povrsina { get; set; }
    }
    public class Stampa : Reklame
    {
        public virtual string Boja { get; set; }
        public virtual string NazivLista { get; set; }
    }
}
