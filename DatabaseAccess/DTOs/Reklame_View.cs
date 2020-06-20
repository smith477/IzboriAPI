using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class Reklame_View : Izborne_Aktivnosti_View
    {
        public virtual DateTime TrajanjeOd { get; set; }
        public virtual DateTime TrajanjeDo { get; set; }
        public virtual int Cena { get; set; }

        public Reklame_View() { }

        public Reklame_View(Reklame r) : base(r)
        {
            TrajanjeOd = r.TrajanjeOd;
            TrajanjeDo = r.TrajanjeDo;
            Cena = r.Cena;
        }
    }
}
