using DatabaseAccess.DTOs;
using DatabaseAccess.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAccess
{
    public class DataProvider
    {
        #region AktivistaStranke

        public static List<Aktivista_Stranke_View> PreuzmiAktivisteStranke()
        {
            List<Aktivista_Stranke_View> rez = new List<Aktivista_Stranke_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Aktivista_Stranke> rez1 = from o in s.Query<Aktivista_Stranke>()
                                                      select o;

                foreach (Aktivista_Stranke a_s in rez1)
                {
                    var aktivista = new Aktivista_Stranke_View(a_s);
                    aktivista.Email = a_s.Email.Select(ak_str => new Email_View(ak_str)).ToList();
                    aktivista.Telefon = a_s.Telefon.Select(ak_str => new Telefon_View(ak_str)).ToList();

                    rez.Add(aktivista);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return rez;
        }

        public static Aktivista_Stranke_View PreuzmiAktivistuStranke(int id)
        {
            Aktivista_Stranke_View a;
            try
            {
                ISession s = DataLayer.GetSession();

                Aktivista_Stranke aktivista = s.Load<Aktivista_Stranke>(id);
                

                a = new Aktivista_Stranke_View(aktivista);
                a.Email = aktivista.Email.Select(akt => new Email_View(akt)).ToList();
                a.Telefon = aktivista.Telefon.Select(akt => new Telefon_View(akt)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return a;
        }

        public static void DodajAktivistuStranke(Aktivista_Stranke_View noviaktivista)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Aktivista_Stranke aktivista = new Aktivista_Stranke
                {
                    Licno_ime = noviaktivista.Licno_ime,
                    Ime_roditelja = noviaktivista.Ime_roditelja,
                    Prezime = noviaktivista.Prezime,
                    Datum_rodjenja = noviaktivista.Datum_rodjenja,
                    Ulica = noviaktivista.Ulica,
                    Broj = noviaktivista.Broj
                };

                s.SaveOrUpdate(aktivista);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static Aktivista_Stranke_View AzurirajAktivistuStranke(Aktivista_Stranke_View p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Aktivista_Stranke o = s.Load<Aktivista_Stranke>(p.Id);
                o.Licno_ime = p.Licno_ime;
                o.Ime_roditelja = p.Ime_roditelja;
                o.Prezime = p.Prezime;
                o.Datum_rodjenja = p.Datum_rodjenja;
                o.Ulica = p.Ulica;
                o.Broj = p.Broj;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }

        public static void ObrisiAktivistuStranke(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Aktivista_Stranke o = s.Load<Aktivista_Stranke>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region GlasackaMesta

        public static List<Glasacka_Mesta_View> PreuzmiGlasackaMesta()
        {
            List<Glasacka_Mesta_View> rez = new List<Glasacka_Mesta_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Glasacka_Mesta> rez1 = from o in s.Query<Glasacka_Mesta>()
                                                   select o;

                foreach (Glasacka_Mesta a_s in rez1)
                {
                    rez.Add(new Glasacka_Mesta_View(a_s));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return rez;
        }

        #endregion
    }
}
