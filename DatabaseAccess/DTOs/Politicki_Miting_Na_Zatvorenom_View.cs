using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class Politicki_Miting_Na_Zatvorenom_View : Politicki_Miting_View
    {
        public virtual string Vlasnik_Prostora { get; set; }
        public virtual int Cena_Iznajmljivanja { get; set; }

        public Politicki_Miting_Na_Zatvorenom_View() { }

        public Politicki_Miting_Na_Zatvorenom_View(Politicki_Miting_Na_Zatvorenom pmnz) : base(pmnz)
        {
            Vlasnik_Prostora = pmnz.Vlasnik_Prostora;
            Cena_Iznajmljivanja = pmnz.Cena_Iznajmljivanja;
        }
    }
}
