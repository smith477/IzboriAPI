using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class ProtivkandidatiId_View
    {
        public virtual Duel_View Duel { get; set; }
        public virtual string Protivkandidat { get; set; }

        public ProtivkandidatiId_View() { }

        public ProtivkandidatiId_View(ProtivkandidatiId pkid)
        {
            Duel = new Duel_View(pkid.Duel);
            Protivkandidat = pkid.Protivkandidat;
        }
    }
}
