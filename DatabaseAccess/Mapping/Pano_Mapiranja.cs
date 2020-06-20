using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    class Pano_Mapiranja : SubclassMap<Pano>
    {
        public Pano_Mapiranja()
        {
            Table("PANO");
            KeyColumn("ID_IZBORNE_AKTIVNOSTI");
            Map(x => x.Grad, "GRAD");
            Map(x => x.Agencija, "AGENCIJA");
            Map(x => x.Ulica, "ULICA");
            Map(x => x.Povrsina, "POVRSINA");
        }
    }
}
