using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Intervju_U_Stampi_View : Pojavljivanje_U_Medijima_View
    {
        public virtual string Naziv { get; set; }
        public virtual DateTime DatumIntervjua { get; set; }
        public virtual DateTime DatumObjavljivanja { get; set; }
        public virtual string Novinar { get; set; }

        public Intervju_U_Stampi_View() { }

        public Intervju_U_Stampi_View(Intervju_U_Stampi ius) : base(ius)
        {
            Naziv = ius.Naziv;
            DatumIntervjua = ius.DatumIntervjua;
            DatumObjavljivanja = ius.DatumObjavljivanja;
            Novinar = ius.Novinar;
        }
    }
}
