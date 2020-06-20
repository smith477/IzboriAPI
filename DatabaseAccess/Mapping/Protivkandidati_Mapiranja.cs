using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    public class Protivkandidati_Mapiranja : ClassMap<Protivkandidati>
    {
        public Protivkandidati_Mapiranja()
        {
            Table("PROTIVKANDIDAT");

            CompositeId(x => x.Id)
               .KeyReference(x => x.Duel, "ID_IZBORNE_AKTIVNOSTI")
               .KeyProperty(x => x.Protivkandidat, "PROTIVKANDIDAT");
        }
    }
}
