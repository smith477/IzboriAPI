using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    class Izborne_Aktivnosti_Mapiranja : ClassMap<Izborne_Aktivnosti>
    {
        public Izborne_Aktivnosti_Mapiranja()
        {
            //Mapiranje tabele
            Table("IZBORNE_AKTIVNOSTI");

            //Mapiranje primarnog kjuca
            Id(x => x.Id, "ID_IZBORNE_AKTIVNOSTI").GeneratedBy.TriggerIdentity();

            References(x => x.Koordinator).Column("ID_AKTIVISTE_STRANKE").LazyLoad();

        }
       
    }
}
