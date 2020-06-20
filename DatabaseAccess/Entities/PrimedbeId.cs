using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class PrimedbeId
    {
        public virtual Glasacka_Mesta Glasacka_Mesta { get; set; }
        public virtual string Primedbe { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(PrimedbeId))
                return false;

            PrimedbeId recievedObject = (PrimedbeId)obj;

            if ((Glasacka_Mesta.Id == recievedObject.Glasacka_Mesta.Id) &&
                (Primedbe == recievedObject.Primedbe))
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
