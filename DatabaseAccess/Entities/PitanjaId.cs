using System;

namespace DatabaseAccess.Entities
{
    public class PitanjaId
    {
        public virtual Duel Duel { get; set; }
        public virtual string Pitanja { get; set; }
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(PitanjaId))
                return false;

            PitanjaId recievedObject = (PitanjaId)obj;

            if ((Duel.Id == recievedObject.Duel.Id) &&
                (Pitanja == recievedObject.Pitanja))
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