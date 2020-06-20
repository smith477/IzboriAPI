using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class RezultatiID_View
    {
        public virtual int Id { get; set; }

        public virtual Glasacka_Mesta_View Glasacka_Mesta { get; set; }

        public RezultatiID_View() { }

        public RezultatiID_View(RezultatiId rid)
        {
            Id = rid.Id;
            Glasacka_Mesta = new Glasacka_Mesta_View(rid.Glasacka_Mesta);
        }
    }
}
