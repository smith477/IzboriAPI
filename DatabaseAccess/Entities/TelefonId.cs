using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class TelefonId
    {
        public virtual Aktivista_Stranke Aktivista { get; set; }
        public virtual string Telefon { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(TelefonId))
                return false;

            TelefonId recievedObject = (TelefonId)obj;

            if ((Aktivista.Id == recievedObject.Aktivista.Id) &&
                (Telefon == recievedObject.Telefon))
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
