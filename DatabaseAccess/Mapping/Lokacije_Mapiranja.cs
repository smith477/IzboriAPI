using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    class Lokacije_Mapiranja : ClassMap<Lokacije>
    {
        public Lokacije_Mapiranja()
        {
            Table("LOKACIJE");

            CompositeId(x => x.Id)
                .KeyReference(x => x.Deljenje_Letki, "ID_IZBORNE_AKTIVNOSTI")
                .KeyProperty(x => x.Lokacija, "LOKACIJA");

        }
    }
}
