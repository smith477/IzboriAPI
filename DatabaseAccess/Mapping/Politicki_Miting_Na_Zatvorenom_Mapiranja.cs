using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Mapping
{
    class Politicki_Miting_Na_Zatvorenom_Mapiranja : SubclassMap<Politicki_Miting_Na_Zatvorenom>
    {
        public Politicki_Miting_Na_Zatvorenom_Mapiranja()
        {
            Table("POLITICKI_MITING_NA_ZATVORENOM");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");

            Map(x => x.Vlasnik_Prostora, "VLASNIK_PROSTORA");
            Map(x => x.Cena_Iznajmljivanja, "CENA_IZNAJMLJIVANJA");

        }
    }

}
