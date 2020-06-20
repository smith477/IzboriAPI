using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    class Gost_Mapiranja : ClassMap<Gost>
    {
        public Gost_Mapiranja()
        {
            Table("GOST");

            CompositeId(x => x.Id)
                .KeyProperty(x => x.Id, "ID_GOST")
                .KeyReference(x => x.Politicki_Miting, "ID_IZBORNE_AKTIVNOSTI");

            Map(x => x.Licno_Ime, "LICNO_IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Titula, "TITULA");

            //HasMany(x => x.Funkcije).KeyColumn("ID_GOST").LazyLoad().Cascade.All().Inverse();


        }
    }
}
