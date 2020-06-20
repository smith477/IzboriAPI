using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Primedbe_View
    {
        public virtual PrimedbeId_View Id { get; set; }

        public Primedbe_View() { }

        public Primedbe_View(Primedbe p)
        {
            Id = new PrimedbeId_View(p.Id);
        }
    }
}
