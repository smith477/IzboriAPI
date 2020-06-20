using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    public class Duel_Mapiranja : SubclassMap<Duel>
    {
        public Duel_Mapiranja()
        {
            Table("DUEL");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");

            HasMany(x => x.Protivkandidati).KeyColumn("ID_IZBORNE_AKTIVNOSTI").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Pitanja).KeyColumn("ID_IZBORNE_AKTIVNOSTI").LazyLoad().Cascade.All().Inverse();
        }
    }
}
