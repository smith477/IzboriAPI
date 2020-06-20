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
    class Stampa_Mapiranja : SubclassMap<Stampa>
    {
        public Stampa_Mapiranja()
        {
            Table("STAMPA");
            KeyColumn("ID_IZBORNE_AKTIVNOSTI");
            Map(x => x.Boja, "BOJA");
            Map(x => x.NazivLista, "NAZIV_LISTA");
        }
    }
}
