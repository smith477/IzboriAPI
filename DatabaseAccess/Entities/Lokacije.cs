﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Lokacije
    {
        public virtual LokacijeId Id { get; set; }

        public Lokacije()
        {
            Id = new LokacijeId();
        }
    }
}
