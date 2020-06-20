using System;

namespace DatabaseAccess.Entities
{
    public class ProtivkandidatiId
    {
        public virtual Duel Duel { get; set; }
        public virtual string Protivkandidat { get; set; }
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(ProtivkandidatiId))
                return false;

            ProtivkandidatiId recievedObject = (ProtivkandidatiId)obj;

            if ((Duel.Id == recievedObject.Duel.Id) &&
                (Protivkandidat == recievedObject.Protivkandidat))
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