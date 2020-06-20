using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Funkcije
    {
        public virtual FunkcijeId Id { get; set; }

        public Funkcije()
        {
            Id = new FunkcijeId();
        }
    }
}
