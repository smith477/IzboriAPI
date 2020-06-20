using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entities;


namespace DatabaseAccess.Mapping
{
    class Rezultati_Mapiranja : ClassMap<Rezultati>
    {
        public Rezultati_Mapiranja()
        {
            Table("REZULTATI");

            //Id(x => x.Id, "ID_REZULTATA").GeneratedBy.TriggerIdentity();

            CompositeId(x => x.Id)
                .KeyProperty(x => x.Id, "ID_REZULTATA")
                .KeyReference(x => x.Glasacka_Mesta, "ID_GLASACKOG_MESTA");

            Map(x => x.Broj_Biraca, "BROJ_BIRACA");
            Map(x => x.Procenat_Glasanja, "PROCENAT_GLASANJA");
            Map(x => x.Krug_Izbora, "KRUG_IZBORA");

            
        }
    }
}
