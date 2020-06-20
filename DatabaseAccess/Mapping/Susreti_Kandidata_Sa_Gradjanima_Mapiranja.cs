using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izbori.Mapping
{
    class Susreti_Kandidata_Sa_Gradjanima_Mapiranja : SubclassMap<Susreti_Kandidata_Sa_Gradjanima>
    {
        public Susreti_Kandidata_Sa_Gradjanima_Mapiranja()
        {
            Table("SUSRETI_KANDIDATA_I_GRADJANA");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");

            Map(x => x.Grad, "GRAD");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Vreme, "VREME");
        }
    }
}
