using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    public class Intervju_U_Stampi_Mapiranja : SubclassMap<Intervju_U_Stampi>
    {
        public Intervju_U_Stampi_Mapiranja() 
        {
            Table("INTERVJU_U_STAMPI");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.DatumIntervjua, "DATUM_INTERVJUA");
            Map(x => x.DatumObjavljivanja, "DATUM_OBJAVLJIVANJA");
            Map(x => x.Novinar, "NOVINAR");
        } 
    }
}
