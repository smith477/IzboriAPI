using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;


namespace DatabaseAccess.Mapping
{
    class Aktivista_Stranke_Mapiranja : ClassMap<Aktivista_Stranke>
    {
        public Aktivista_Stranke_Mapiranja()
        {
            //Mapiranje tabele
            Table("AKTIVISTA_STRANKE");

            //Mapiranje primarnog kjuca
            Id(x => x.Id, "ID_AKTIVISTE_STRANKE").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Licno_ime, "LICNO_IME");
            Map(x => x.Ime_roditelja, "IME_RODITELJA");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Datum_rodjenja, "DATUM_RODJENJA");
            Map(x => x.Ulica, "ULICA");
            Map(x => x.Broj, "BROJ");

            //mapiranje veze 1:N Aktivista_Stranke-Glasacko_Mesto
            References(x => x.PratiGlasackoMesto).Column("ID_GLASACKOG_MESTA").LazyLoad();

            HasMany(x => x.Email).KeyColumn("ID_AKTIVISTE_STRANKE").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Telefon).KeyColumn("ID_AKTIVISTE_STRANKE").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.Akcije)
                .Table("UCESTVUJE")
                .ParentKeyColumn("ID_AKTIVISTE_STRANKE")
                .ChildKeyColumn("ID_AKCIJE")
                .Cascade.All();



        }
    }

    //public class Koordinator_Opstine_Mapiranja : SubclassMap<Koordinator_Opstine>
    //{
    //    public Koordinator_Opstine_Mapiranja()
    //    {
    //        Table("KOORDINATOR_OPSTINE");

    //        Map(x => x.Ime_opstine, "IME_OPSTINE");
    //        Map(x => x.Adresa_kancelarije, "ADRESA_KANCELARIJE");

    //        DiscriminatorValue(1);
    //    }
    //}
}
