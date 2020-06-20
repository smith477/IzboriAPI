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
    class Akcije_Mapiranja : SubclassMap<Akcije>
    {
        public Akcije_Mapiranja()
        {
            Table("AKCIJE");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");

            HasManyToMany(x => x.Aktivisti)
                .Table("UCESTVUJE")
                .ParentKeyColumn("ID_AKCIJE")
                .ChildKeyColumn("ID_AKTIVISTE_STRANKE")
                .Inverse()
                .Cascade.All();


        }
    }
}
