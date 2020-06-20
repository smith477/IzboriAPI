using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class PitanjaId_View
    {
        public virtual Duel_View Duel { get; set; }
        public virtual string Pitanja { get; set; }

        public PitanjaId_View() { }

        public PitanjaId_View(PitanjaId pid)
        {
            Duel = new Duel_View(pid.Duel);
            Pitanja = pid.Pitanja;
        }
    }
}
