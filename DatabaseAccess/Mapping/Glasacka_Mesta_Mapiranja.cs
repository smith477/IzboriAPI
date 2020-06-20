using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    class Glasacka_Mesta_Mapiranja : ClassMap<Glasacka_Mesta>
    {

        public Glasacka_Mesta_Mapiranja()
        {
            //Mapiranje tabele
            Table("GLASACKA_MESTA");

            //Mapiranje primarnog kjuca
            Id(x => x.Id, "ID_GLASACKOG_MESTA").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Broj_biraca, "BROJ_BIRACA");
            Map(x => x.Broj_mesta, "BROJ_MESTA");

            //HasMany(x => x.Primedbe).KeyColumn("PRIMEDBE").LazyLoad().Cascade.All();
            HasMany(x => x.Aktivisti).KeyColumn("ID_GLASACKOG_MESTA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Primedbe).KeyColumn("ID_GLASACKOG_MESTA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Rezultati).KeyColumn("ID_GLASACKOG_MESTA").LazyLoad().Cascade.All().Inverse();
        }
        
    }
}
