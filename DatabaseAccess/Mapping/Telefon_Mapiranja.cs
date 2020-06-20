using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
        class Telefon_Mapiranja : ClassMap<Telefon>
        {
            public Telefon_Mapiranja()
            {
                Table("TELEFON");

                CompositeId(x => x.Id)
                    .KeyReference(x => x.Aktivista, "ID_AKTIVISTE_STRANKE")
                    .KeyProperty(x => x.Telefon, "TELEFON");

            }
        }
    
}
