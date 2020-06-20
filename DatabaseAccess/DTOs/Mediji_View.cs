using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class Mediji_View : Reklame_View
    {
        public virtual int BrojEmitovanja { get; set; }
        public virtual int TrajanjeReklame { get; set; }
        public virtual string NazivMedija { get; set; }

        public Mediji_View() { }

        public Mediji_View(Mediji m) : base(m)
        {
            BrojEmitovanja = m.BrojEmitovanja;
            TrajanjeReklame = m.TrajanjeReklame;
            NazivMedija = m.NazivMedija;
        }
    }
}
