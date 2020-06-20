using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    class Reklame_Mapiranja : SubclassMap<Reklame>
    {
        public Reklame_Mapiranja()
        {
            Table("REKLAME");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");

            Map(x => x.Cena, "CENA");
            Map(x => x.TrajanjeOd, "TRAJANJE_OD");
            Map(x => x.TrajanjeDo, "TRAJANJE_DO");
        }
    }
}
