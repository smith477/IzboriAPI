using System;

namespace DatabaseAccess.Entities
{
    public class GostId
    {
        public virtual int Id { get; set; }
        public virtual Politicki_Miting Politicki_Miting { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(GostId))
                return false;

            GostId recievedObject = (GostId)obj;

            if ((Politicki_Miting.Id == recievedObject.Politicki_Miting.Id) &&
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