using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Telefon
    {
        public virtual TelefonId Id { get; set; }

        public Telefon()
        {
            Id = new TelefonId();
        }
    }
}
