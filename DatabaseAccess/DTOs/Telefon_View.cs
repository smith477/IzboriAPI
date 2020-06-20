using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Telefon_View
    {
        public virtual TelefonId_View Id { get; set; }

        public Telefon_View() { }

        public Telefon_View(Telefon t)
        {
            Id = new TelefonId_View(t.Id);
        }
    }
}
