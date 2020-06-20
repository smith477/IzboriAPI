using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class LokacijeId
    {
        public virtual Deljenje_Letki Deljenje_Letki { get; set; }
        public virtual string Lokacija { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(LokacijeId))
                return false;

            LokacijeId recievedObject = (LokacijeId)obj;

            if ((Deljenje_Letki.Id == recievedObject.Deljenje_Letki.Id) &&
                (Lokacija == recievedObject.Lokacija))
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
