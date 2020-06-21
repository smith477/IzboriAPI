using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class TelefonId_View
    {
        //public virtual Aktivista_Stranke_View Aktivista { get; set; }
        public virtual string Telefon { get; set; }

        public TelefonId_View() { }

        public TelefonId_View(TelefonId tid)
        {
            Telefon = tid.Telefon;
            //Aktivista = new Aktivista_Stranke_View(tid.Aktivista);
        }
    }
}
