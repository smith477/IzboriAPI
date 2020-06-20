using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class PrimedbeId_View
    {
        public virtual Glasacka_Mesta_View Glasacka_Mesta { get; set; }
        public virtual string Primedbe { get; set; }

        public PrimedbeId_View() { }

        public PrimedbeId_View(PrimedbeId pid)
        {
            Primedbe = pid.Primedbe;
            Glasacka_Mesta = new Glasacka_Mesta_View(pid.Glasacka_Mesta);
        }
    }
}
