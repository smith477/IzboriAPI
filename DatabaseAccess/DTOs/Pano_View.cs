using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class Pano_View : Reklame_View
    {
        public virtual string Grad { get; set; }
        public virtual string Agencija { get; set; }
        public virtual string Ulica { get; set; }
        public virtual string Povrsina { get; set; }

        public Pano_View() { }

        public Pano_View(Pano p) : base(p)
        {
            Grad = p.Grad;
            Agencija = p.Agencija;
            Ulica = p.Ulica;
            Povrsina = p.Povrsina;
        }
    }
}
