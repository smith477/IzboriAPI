using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    public class Pitanja_Mapiranja : ClassMap<Pitanja>
    {
        public Pitanja_Mapiranja()
        {
            Table("PITANJA");

            CompositeId(x => x.Id)
               .KeyReference(x => x.Duel, "ID_IZBORNE_AKTIVNOSTI")
               .KeyProperty(x => x.Pitanja, "PITANJE");
        }
    }
}
