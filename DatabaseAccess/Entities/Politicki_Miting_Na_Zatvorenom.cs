namespace DatabaseAccess.Entities
{
    public class Politicki_Miting_Na_Zatvorenom : Politicki_Miting
    {
        public virtual string Vlasnik_Prostora { get; set; }
        public virtual int Cena_Iznajmljivanja { get; set; }
    }
}
