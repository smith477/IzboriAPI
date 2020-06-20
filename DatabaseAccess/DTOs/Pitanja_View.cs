using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Pitanja_View
    {
        public virtual PitanjaId_View Id { get; set; }

        public Pitanja_View() { }

        public Pitanja_View(Pitanja p)
        {
            Id = new PitanjaId_View(p.Id);
        }
    }
}
