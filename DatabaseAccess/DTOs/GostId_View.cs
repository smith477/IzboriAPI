using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class GostId_View
    {
        public virtual int Id { get; set; }
        public virtual Politicki_Miting_View Politicki_Miting { get; set; }

        public GostId_View() { }

        public GostId_View(GostId gid)
        {
            Id = gid.Id;
            Politicki_Miting = new Politicki_Miting_View(gid.Politicki_Miting);
        }
    }
}
