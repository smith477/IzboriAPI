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
    class Deljenje_Letki_Mapiranja : SubclassMap<Deljenje_Letki>
    {
        public Deljenje_Letki_Mapiranja()
        {
            Table("DELJENJE_LETKI");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");

            Map(x => x.Grad, "GRAD");

            HasMany(x => x.Lokacije).KeyColumn("ID_IZBORNE_AKTIVNOSTI").LazyLoad().Cascade.All().Inverse();
        }
    }
}
