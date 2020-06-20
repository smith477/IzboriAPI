using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Duel_View : Pojavljivanje_U_Medijima_View
    {
        public virtual IList<Protivkandidati_View> Protivkandidati { get; set; }
        public virtual IList<Pitanja_View> Pitanja { get; set; }

        public Duel_View() 
        {
            Protivkandidati = new List<Protivkandidati_View>();
            Pitanja = new List<Pitanja_View>();
        }

        public Duel_View(Duel d) : base(d)
        {
        }
    }
}
