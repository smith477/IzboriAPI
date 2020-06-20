using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Lokacije_View
    {
        public virtual LokacijeId_View Id { get; set; }

        public Lokacije_View() { }

        public Lokacije_View(Lokacije l)
        {
            Id = new LokacijeId_View(l.Id);
        }
    }
}
