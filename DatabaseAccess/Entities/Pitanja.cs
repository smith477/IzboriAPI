namespace DatabaseAccess.Entities
{
    public class Pitanja
    {
        public virtual PitanjaId Id { get; set; }

        public Pitanja()
        {
            Id = new PitanjaId();
        }
    }
}