using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Protivkandidati_View
    {
        public virtual ProtivkandidatiId_View Id { get; set; }

        public Protivkandidati_View() { }

        public Protivkandidati_View(Protivkandidati pk)
        {
            Id = new ProtivkandidatiId_View(pk.Id); 
        }
    }
}
