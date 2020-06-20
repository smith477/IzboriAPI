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
    class Koordinator_Opstine_Mapiranja : SubclassMap<Koordinator_Opstine>
    {
        public Koordinator_Opstine_Mapiranja()
        {
            Table("KOORDINATOR_OPSTINE");

            KeyColumn("ID_AKTIVISTE_STRANKE");

            Map(x => x.Adresa_Kancelarije, "ADRESA_KANCELARIJE");
            Map(x => x.Ime_Opstine, "IME_OPSTINE");

            HasMany(x => x.Izborne_Aktivnosti).KeyColumn("ID_AKTIVISTE_STRANKE").LazyLoad().Cascade.All().Inverse();

        }
    }
}
