using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class EmailId_View
    {
        //public virtual Aktivista_Stranke_View Aktivista { get; set; }
        public virtual string Email { get; set; }

        public EmailId_View() { }

        public EmailId_View(EmailId eid)
        {
            Email = eid.Email;
            //Aktivista = new Aktivista_Stranke_View(eid.Aktivista);
        }
    }
}
