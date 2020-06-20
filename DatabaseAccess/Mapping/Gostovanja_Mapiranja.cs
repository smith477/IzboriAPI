using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    public class Gostovanja_Mapiranja : SubclassMap<Gostovanja>
    {
        public Gostovanja_Mapiranja()
        {
            Table("GOSTOVANJA");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");
            Map(x => x.ProcenjenaGledanost, "PROCENJENA_GLEDANOST");
            Map(x => x.NazivMedija, "NAZIV_MEDIJA");
            Map(x => x.NazivEmisije, "NAZIV_EMISIJE");
            Map(x => x.Voditelj, "VODITELJ");
        }
    }
}
