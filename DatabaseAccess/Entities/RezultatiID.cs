using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class RezultatiId
    {
        public virtual int Id { get; set; }

        public virtual Glasacka_Mesta Glasacka_Mesta { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(RezultatiId))
                return false;

            RezultatiId recievedObject = (RezultatiId)obj;

            if ((Glasacka_Mesta.Id == recievedObject.Glasacka_Mesta.Id) &&
                (Id == recievedObject.Id))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
