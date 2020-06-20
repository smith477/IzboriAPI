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
    class Mediji_Mapiranja : SubclassMap<Mediji>
    {
        public Mediji_Mapiranja()
        {
            Table("MEDIJI");
            KeyColumn("ID_IZBORNE_AKTIVNOSTI");
            Map(x => x.BrojEmitovanja, "BROJ_EMITOVANJA");
            Map(x => x.TrajanjeReklame, "TRAJANJE_REKLAME");
            Map(x => x.NazivMedija, "NAZIV_MEDIJA");
        }
    }
}
