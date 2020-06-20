using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class FunkcijeId
    {
        public virtual Gost Gost { get; set; }
        public virtual string Funkcija { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(FunkcijeId))
                return false;
            FunkcijeId recievedObject = (FunkcijeId)obj;

            if ((Gost.Id == recievedObject.Gost.Id) &&
                (Funkcija == recievedObject.Funkcija))
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
