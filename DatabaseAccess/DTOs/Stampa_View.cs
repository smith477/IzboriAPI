using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class Stampa_View : Reklame_View
    {
        public virtual string Boja { get; set; }
        public virtual string NazivLista { get; set; }

        public Stampa_View() { }

        public Stampa_View(Stampa s) : base(s)
        {
            Boja = s.Boja;
            NazivLista = s.NazivLista;
        }
    }
}
