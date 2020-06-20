using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entities;

namespace DatabaseAccess.DTOs
{
    public class Email_View
    {
        public virtual EmailId_View Id { get; set; }

        public Email_View() { }

        public Email_View(Email e)
        {
            Id = new EmailId_View(e.Id);
        }
    }
}
