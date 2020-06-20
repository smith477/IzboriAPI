using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class EmailId
    {
        public virtual Aktivista_Stranke Aktivista { get; set; }
        public virtual string Email { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(EmailId))
                return false;

            EmailId recievedObject = (EmailId)obj;

            if ((Aktivista.Id == recievedObject.Aktivista.Id) &&
                (Email == recievedObject.Email))
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
