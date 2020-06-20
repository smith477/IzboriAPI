using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;

namespace DatabaseAccess.Mapping
{
    public class Pojavljivanje_U_Medijima_Mapiranja : SubclassMap<Pojavljivanje_U_Medijima>
    {
        public Pojavljivanje_U_Medijima_Mapiranja()
        {
            Table("POJAVLJIVANJE_U_MEDIJIMA");

            KeyColumn("ID_IZBORNE_AKTIVNOSTI");
        }
    }
}
