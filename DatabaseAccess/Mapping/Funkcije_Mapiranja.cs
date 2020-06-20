using FluentNHibernate.Mapping;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapping
{
    //class Funkcije_Mapiranja : ClassMap<Funkcije>
    //{
    //    public Funkcije_Mapiranja()
    //    {
    //        Table("FUNKCIJE");

    //        CompositeId(x => x.Id)
    //            .KeyReference(x => x.Gost, "ID_GOST")
    //            .KeyProperty(x => x.Funkcija, "FUNKCIJA");

    //        //References(x => x.Id.Gost, "ID_GOST");
    //        //References(x => x.Id.Gost.Id.Politicki_Miting, "ID_IZBORNE_AKTIVNOSTI");


    //    }
    //}
}
