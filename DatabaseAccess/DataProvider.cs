using DatabaseAccess.DTOs;
using DatabaseAccess.Entities;
using DatabaseAccess.Mapping;
using FluentNHibernate.Utils;
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
                    aktivista.Akcije = a_s.Akcije.Select(ak_str => new Akcije_View(ak_str)).ToList();

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

        #region Izborne_Aktivnosti
        #region Akcije

        #region Deljenjeletki

        public static List<Deljenje_Letki_View> VratiDeljenjeLetki()//200OK
        {
            List<Deljenje_Letki_View> rez = new List<Deljenje_Letki_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Deljenje_Letki> dl = from o in s.Query<Deljenje_Letki>()
                                                 select o;

                foreach (Deljenje_Letki o in dl)
                {
                    var dlview = new Deljenje_Letki_View(o);
                    dlview.Lokacije = o.Lokacije.Select(lok => new Lokacije_View(lok)).ToList();
                    dlview.Aktivisti = o.Aktivisti.Select(ak => new Aktivista_Stranke_View(ak)).ToList();

                    rez.Add(dlview);
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

        public static Deljenje_Letki_View VratiDeljenjeLetkiID(int id)//200OK
        {
            Deljenje_Letki_View dl;
            try
            {
                ISession s = DataLayer.GetSession();

                Deljenje_Letki deljenejLetki = s.Load<Deljenje_Letki>(id);


                dl = new Deljenje_Letki_View(deljenejLetki);
                dl.Lokacije = deljenejLetki.Lokacije.Select(lok => new Lokacije_View(lok)).ToList();
                dl.Aktivisti = deljenejLetki.Aktivisti.Select(ak => new Aktivista_Stranke_View(ak)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return dl;
        }

        public static void DodajLetku(int idKoordinaoraOpstine, Deljenje_Letki dlview)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Deljenje_Letki dl = new Deljenje_Letki
                {
                    Grad = dlview.Grad,
                    Koordinator = kOpstine
                };

                s.SaveOrUpdate(dl);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DodajLokacijuZaLetku(int id, LokacijeId lid)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Deljenje_Letki deljenjeLetki = s.Load<Deljenje_Letki>(id);

                var l = new Lokacije
                {
                    Id = new LokacijeId
                    {
                        Deljenje_Letki = deljenjeLetki,
                        Lokacija = lid.Lokacija
                    }
                };


                deljenjeLetki.Lokacije.Add(l);

                s.SaveOrUpdate(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DodajktivistuZaDeljenjeLetki(Aktivista_Stranke_View noviaktivista, int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Aktivista_Stranke aktivistaStranke = s.Load<Aktivista_Stranke>(noviaktivista.Id);
                Deljenje_Letki deljenjeLetki = s.Load<Deljenje_Letki>(id);
                deljenjeLetki.Aktivisti.Add(aktivistaStranke);
                aktivistaStranke.Akcije.Add(deljenjeLetki);


                s.SaveOrUpdate(deljenjeLetki);
                s.SaveOrUpdate(aktivistaStranke);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static Deljenje_Letki_View AzurirajDeljenjeLetki(Deljenje_Letki_View dlview)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Deljenje_Letki o = s.Load<Deljenje_Letki>(dlview.Id);
                o.Grad = dlview.Grad;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return dlview;
        }

        public static void ObrisiDeljenjeLetki(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Deljenje_Letki dl = s.Load<Deljenje_Letki>(id);

                dl.Aktivisti.Clear();
                dl.Koordinator = null;
                dl.Lokacije.Clear();


                s.SaveOrUpdate(dl);
                s.Flush();

                s.Delete(dl);
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

        #region SusretiKandidataSaGradjanima

        public static List<Susreti_Kandidata_Sa_Gradjanima_View> VratiSveSusreteKandidataSaGradjanima()//200OK
        {
            List<Susreti_Kandidata_Sa_Gradjanima_View> rez = new List<Susreti_Kandidata_Sa_Gradjanima_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Susreti_Kandidata_Sa_Gradjanima> susreti = from o in s.Query<Susreti_Kandidata_Sa_Gradjanima>()
                                                                       select o;

                foreach (Susreti_Kandidata_Sa_Gradjanima o in susreti)
                {
                    var sksg = new Susreti_Kandidata_Sa_Gradjanima_View(o);
                    sksg.Aktivisti = o.Aktivisti.Select(ak => new Aktivista_Stranke_View(ak)).ToList();
                    rez.Add(sksg);
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

        public static Susreti_Kandidata_Sa_Gradjanima_View VratiSusreteKandidataSaGradjanimaID(int id)//200OK
        {
            Susreti_Kandidata_Sa_Gradjanima_View sk;
            try
            {
                ISession s = DataLayer.GetSession();

                Susreti_Kandidata_Sa_Gradjanima susretikandidata = s.Load<Susreti_Kandidata_Sa_Gradjanima>(id);


                sk = new Susreti_Kandidata_Sa_Gradjanima_View(susretikandidata);
                sk.Aktivisti = susretikandidata.Aktivisti.Select(deljenejLetki => new Aktivista_Stranke_View(deljenejLetki)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return sk;
        }

        public static void DodajktivistuZaSusretSaGradjanima(Aktivista_Stranke_View noviaktivista, int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Aktivista_Stranke aktivistaStranke = s.Load<Aktivista_Stranke>(noviaktivista.Id);
                Susreti_Kandidata_Sa_Gradjanima susret = s.Load<Susreti_Kandidata_Sa_Gradjanima>(id);
                susret.Aktivisti.Add(aktivistaStranke);
                aktivistaStranke.Akcije.Add(susret);

                s.SaveOrUpdate(susret);
                s.SaveOrUpdate(aktivistaStranke);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DodajSusretKandidataSaGradjanima(int idKoordinaoraOpstine, Susreti_Kandidata_Sa_Gradjanima_View sk)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Susreti_Kandidata_Sa_Gradjanima dl = new Susreti_Kandidata_Sa_Gradjanima
                {
                    Grad = sk.Grad,
                    Lokacija = sk.Lokacija,
                    Vreme = sk.Vreme,
                    Koordinator = kOpstine

                };

                s.SaveOrUpdate(dl);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Susreti_Kandidata_Sa_Gradjanima_View AzurirajSusretKandidataSaGradjanima(Susreti_Kandidata_Sa_Gradjanima_View sk)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Susreti_Kandidata_Sa_Gradjanima o = s.Load<Susreti_Kandidata_Sa_Gradjanima>(sk.Id);
                o.Grad = sk.Grad;
                o.Lokacija = sk.Lokacija;
                o.Vreme = sk.Vreme;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return sk;
        }

        public static void ObrisiSusretKandidataSaGradjanima(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Susreti_Kandidata_Sa_Gradjanima sk = s.Load<Susreti_Kandidata_Sa_Gradjanima>(id);

                sk.Aktivisti.Clear();
                sk.Koordinator = null;


                s.SaveOrUpdate(sk);
                s.Flush();

                s.Delete(sk);
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

        #region PolitickiMitingNaOtvorenom

        public static List<Politicki_Miting_Na_Otvorenom_View> VratiSveMitingeNaOtvorenom()//200OK
        {
            List<Politicki_Miting_Na_Otvorenom_View> rez = new List<Politicki_Miting_Na_Otvorenom_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Politicki_Miting_Na_Otvorenom> mitinzi = from o in s.Query<Politicki_Miting_Na_Otvorenom>()
                                                                     select o;

                foreach (Politicki_Miting_Na_Otvorenom o in mitinzi)
                {
                    var m = new Politicki_Miting_Na_Otvorenom_View(o);
                    m.Aktivisti = o.Aktivisti.Select(ak => new Aktivista_Stranke_View(ak)).ToList();
                    rez.Add(m);
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

        public static Politicki_Miting_Na_Otvorenom_View VratiMitingNaOtvorenomID(int id)//200OK
        {
            Politicki_Miting_Na_Otvorenom_View m;
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Otvorenom miting = s.Load<Politicki_Miting_Na_Otvorenom>(id);


                m = new Politicki_Miting_Na_Otvorenom_View(miting);
                m.Aktivisti = miting.Aktivisti.Select(ak => new Aktivista_Stranke_View(ak)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return m;
        }

        public static void DodajAktivistuMitingNaOtvorenom(Aktivista_Stranke_View noviaktivista, int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Aktivista_Stranke aktivistaStranke = s.Load<Aktivista_Stranke>(noviaktivista.Id);
                Politicki_Miting_Na_Otvorenom miting = s.Load<Politicki_Miting_Na_Otvorenom>(id);
                miting.Aktivisti.Add(aktivistaStranke);
                aktivistaStranke.Akcije.Add(miting);

                s.SaveOrUpdate(miting);
                s.SaveOrUpdate(aktivistaStranke);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DodajGostaMitingNaOtvorenom(Gost_View gost, int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Otvorenom m = s.Load<Politicki_Miting_Na_Otvorenom>(id);

                Gost g = new Gost
                {

                    Id = new GostId
                    {
                        Politicki_Miting = m
                    },
                    Licno_Ime = gost.Licno_Ime,
                    Prezime = gost.Prezime,
                    Titula = gost.Titula
                };
                m.Gosti.Add(g);

                s.Save(m);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DodajMitingNaOtvorenom(int idKoordinaoraOpstine, Politicki_Miting_Na_Otvorenom_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Politicki_Miting_Na_Otvorenom pmiting = new Politicki_Miting_Na_Otvorenom
                {
                    Lokacija = m.Lokacija,
                    Mesto = m.Mesto,
                    Koordinator = kOpstine
                };

                s.SaveOrUpdate(pmiting);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Politicki_Miting_Na_Otvorenom_View AzurirajMitingNaOtvorenom(Politicki_Miting_Na_Otvorenom_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Otvorenom o = s.Load<Politicki_Miting_Na_Otvorenom>(m.Id);
                o.Mesto = m.Mesto;
                o.Lokacija = m.Lokacija;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return m;
        }

        public static void ObrisiMitingNaOtvorenom(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Otvorenom m = s.Load<Politicki_Miting_Na_Otvorenom>(id);

                m.Aktivisti.Clear();
                m.Koordinator = null;
                m.Gosti.Clear();


                s.SaveOrUpdate(m);
                s.Flush();

                s.Delete(m);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiGostaSaMitingaNaOtvorenom(GostId_View g, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Otvorenom miting = s.Load<Politicki_Miting_Na_Otvorenom>(id);

                Gost m = s.Load<Gost>(g.Id);

                foreach (Gost gost in miting.Gosti)
                {
                    if (gost == m)
                    {
                        s.Delete(m);
                        s.Flush();
                        s.Close();
                    }
                }
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region PolitickiMitingNaZatvorenom

        public static List<Politicki_Miting_Na_Zatvorenom_View> VratiSveMitingeNaZatvorenom()//200OK
        {
            List<Politicki_Miting_Na_Zatvorenom_View> rez = new List<Politicki_Miting_Na_Zatvorenom_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Politicki_Miting_Na_Zatvorenom> mitinzi = from o in s.Query<Politicki_Miting_Na_Zatvorenom>()
                                                                      select o;

                foreach (Politicki_Miting_Na_Zatvorenom o in mitinzi)
                {
                    var m = new Politicki_Miting_Na_Zatvorenom_View(o);
                    m.Aktivisti = o.Aktivisti.Select(ak => new Aktivista_Stranke_View(ak)).ToList();
                    rez.Add(m);
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

        public static Politicki_Miting_Na_Zatvorenom_View VratiMitingNaZatvorenomID(int id)//200OK
        {
            Politicki_Miting_Na_Zatvorenom_View m;
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Zatvorenom miting = s.Load<Politicki_Miting_Na_Zatvorenom>(id);


                m = new Politicki_Miting_Na_Zatvorenom_View(miting);
                m.Aktivisti = miting.Aktivisti.Select(ak => new Aktivista_Stranke_View(ak)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return m;
        }

        public static void DodajAktivistuMitingNaZatvorenom(Aktivista_Stranke_View noviaktivista, int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Aktivista_Stranke aktivistaStranke = s.Load<Aktivista_Stranke>(noviaktivista.Id);
                Politicki_Miting_Na_Zatvorenom miting = s.Load<Politicki_Miting_Na_Zatvorenom>(id);
                miting.Aktivisti.Add(aktivistaStranke);
                aktivistaStranke.Akcije.Add(miting);

                s.SaveOrUpdate(miting);
                s.SaveOrUpdate(aktivistaStranke);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DodajGostaMitingNaZatvorenom(Gost_View gost, int id)//200OK?
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Zatvorenom m = s.Load<Politicki_Miting_Na_Zatvorenom>(id);

                Gost g = new Gost
                {

                    Id = new GostId
                    {
                        Politicki_Miting = m
                    },
                    Licno_Ime = gost.Licno_Ime,
                    Prezime = gost.Prezime,
                    Titula = gost.Titula
                };
                m.Gosti.Add(g);

                s.Save(m);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DodajMitingNaZatvorenom(int idKoordinaoraOpstine, Politicki_Miting_Na_Zatvorenom_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Politicki_Miting_Na_Zatvorenom pmiting = new Politicki_Miting_Na_Zatvorenom
                {
                    Lokacija = m.Lokacija,
                    Mesto = m.Mesto,
                    Cena_Iznajmljivanja = m.Cena_Iznajmljivanja,
                    Vlasnik_Prostora = m.Vlasnik_Prostora,
                    Koordinator = kOpstine
                };

                s.SaveOrUpdate(pmiting);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Politicki_Miting_Na_Zatvorenom_View AzurirajMitingNaZatvorenom(Politicki_Miting_Na_Zatvorenom_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Zatvorenom o = s.Load<Politicki_Miting_Na_Zatvorenom>(m.Id);
                o.Mesto = m.Mesto;
                o.Lokacija = m.Lokacija;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return m;
        }

        public static void ObrisiMitingNaZatvorenom(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Zatvorenom m = s.Load<Politicki_Miting_Na_Zatvorenom>(id);

                m.Aktivisti.Clear();
                m.Gosti.Clear();
                m.Koordinator = null;


                s.SaveOrUpdate(m);
                s.Flush();

                s.Delete(m);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void ObrisiGostaSaMitingaNaZatvorenom(int mitingid, int gostid)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Politicki_Miting_Na_Zatvorenom miting = s.Load<Politicki_Miting_Na_Zatvorenom>(mitingid);
                //Gost pom;

                foreach (Gost gost in miting.Gosti)
                {
                    if (gost.Id.Id == gostid)
                    {
                        miting.Gosti.Remove(gost);

                        s.SaveOrUpdate(miting);
                        s.Flush();

                        s.Delete(gost);
                        s.Flush();
                        s.Close();
                        break;
                    }
                }

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

        }

        #endregion

        #endregion

        #region Reklame

        #region Mediji
        public static List<Mediji_View> VratiMedije()
        {
            List<Mediji_View> rez = new List<Mediji_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Mediji> mitinzi = from o in s.Query<Mediji>()
                                              select o;

                foreach (Mediji o in mitinzi)
                {
                    var m = new Mediji_View(o);

                    rez.Add(m);
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

        public static Mediji_View VratiMedijePoId(int id)//200OK
        {
            Mediji_View m;
            try
            {
                ISession s = DataLayer.GetSession();

                Mediji mediji = s.Load<Mediji>(id);


                m = new Mediji_View(mediji);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return m;
        }

        public static void DodajMedije(int idKoordinaoraOpstine, Mediji_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Mediji pmiting = new Mediji
                {
                    BrojEmitovanja = m.BrojEmitovanja,
                    TrajanjeReklame = m.TrajanjeReklame,
                    NazivMedija = m.NazivMedija,
                    Cena = m.Cena,
                    TrajanjeOd = m.TrajanjeOd,
                    TrajanjeDo = m.TrajanjeDo,
                    Koordinator = kOpstine

                };

                s.SaveOrUpdate(pmiting);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Mediji_View AzurirajMedije(Mediji_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Mediji o = s.Load<Mediji>(m.Id);
                o.TrajanjeDo = m.TrajanjeDo;
                o.TrajanjeOd = m.TrajanjeOd;
                o.TrajanjeReklame = m.TrajanjeReklame;
                o.NazivMedija = m.NazivMedija;


                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return m;
        }

        public static void ObrisiMedije(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Mediji m = s.Load<Mediji>(id);

                m.Koordinator = null;


                s.SaveOrUpdate(m);
                s.Flush();

                s.Delete(m);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DodajKoordinatoraMediji(int idKoordinatora, Mediji_View m)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinatora);

                Mediji med = s.Load<Mediji>(m);


                med.Koordinator = kOpstine;

                kOpstine.Izborne_Aktivnosti.Add(med);


                s.SaveOrUpdate(med);
                s.Flush();
                s.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Stampa
        public static List<Stampa_View> VratiStampu()
        {
            List<Stampa_View> rez = new List<Stampa_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Stampa> stampa = from o in s.Query<Stampa>()
                                             select o;

                foreach (Stampa o in stampa)
                {
                    var m = new Stampa_View(o);

                    rez.Add(m);
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

        public static Stampa_View VratiStampuPoId(int id)//200OK
        {
            Stampa_View m;
            try
            {
                ISession s = DataLayer.GetSession();

                Stampa stampa = s.Load<Stampa>(id);


                m = new Stampa_View(stampa);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return m;
        }

        public static void DodajStampu(int idKoordinaoraOpstine, Stampa_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Stampa stampa = new Stampa
                {
                    Boja = m.Boja,
                    NazivLista = m.NazivLista,
                    TrajanjeDo = m.TrajanjeDo,
                    TrajanjeOd = m.TrajanjeOd,
                    Cena = m.Cena,
                    Koordinator = kOpstine

                };

                s.SaveOrUpdate(stampa);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Stampa_View AzurirajStampa(Stampa_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stampa o = s.Load<Stampa>(m.Id);
                o.Boja = m.Boja;
                o.Cena = m.Cena;
                o.NazivLista = m.NazivLista;
                o.TrajanjeDo = m.TrajanjeDo;
                o.TrajanjeOd = m.TrajanjeOd;



                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return m;
        }

        public static void ObrisiStampu(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stampa m = s.Load<Stampa>(id);

                m.Koordinator = null;


                s.SaveOrUpdate(m);
                s.Flush();

                s.Delete(m);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DodajKoordinatoraStampa(int idKoordinatora, Stampa_View m)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinatora);

                Stampa med = s.Load<Stampa>(m);


                med.Koordinator = kOpstine;

                kOpstine.Izborne_Aktivnosti.Add(med);


                s.SaveOrUpdate(med);
                s.Flush();
                s.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Pano
        public static List<Pano_View> VratiPano()
        {
            List<Pano_View> rez = new List<Pano_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Pano> pano = from o in s.Query<Pano>()
                                         select o;

                foreach (Pano o in pano)
                {
                    var m = new Pano_View(o);

                    rez.Add(m);
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

        public static Pano_View VratiPanoPoId(int id)//200OK
        {
            Pano_View m;
            try
            {
                ISession s = DataLayer.GetSession();

                Pano pano = s.Load<Pano>(id);


                m = new Pano_View(pano);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return m;
        }

        public static void DodajPano(int idKoordinaoraOpstine, Pano_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Pano pano = new Pano
                {
                    Grad = m.Grad,
                    Agencija = m.Agencija,
                    Ulica = m.Ulica,
                    Povrsina = m.Povrsina,
                    Cena = m.Cena,
                    TrajanjeOd = m.TrajanjeOd,
                    TrajanjeDo = m.TrajanjeOd,
                    Koordinator = kOpstine

                };

                s.SaveOrUpdate(pano);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Pano_View AzurirajPano(Pano_View m)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pano o = s.Load<Pano>(m.Id);
                o.Ulica = m.Ulica;
                o.Povrsina = m.Povrsina;
                o.Grad = m.Grad;
                o.Agencija = m.Agencija;
                o.Cena = m.Cena;
                o.TrajanjeDo = m.TrajanjeDo;
                o.TrajanjeOd = m.TrajanjeOd;



                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return m;
        }

        public static void ObrisiPano(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pano m = s.Load<Pano>(id);

                m.Koordinator = null;


                s.SaveOrUpdate(m);
                s.Flush();

                s.Delete(m);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DodajKoordinatoraPano(int idKoordinatora, Pano_View m)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinatora);

                Pano med = s.Load<Pano>(m);


                med.Koordinator = kOpstine;

                kOpstine.Izborne_Aktivnosti.Add(med);


                s.SaveOrUpdate(med);
                s.Flush();
                s.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #endregion

        #region Pojavljivanje_u_Medijima

        #region Intervjui_u_Stampi

        public static List<Intervju_U_Stampi_View> VratiSveIntervjueUStampi()//200OK
        {
            List<Intervju_U_Stampi_View> rez = new List<Intervju_U_Stampi_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Intervju_U_Stampi> intervjui = from o in s.Query<Intervju_U_Stampi>()
                                                           select o;

                foreach (Intervju_U_Stampi o in intervjui)
                {
                    var inter = new Intervju_U_Stampi_View(o);
                    rez.Add(inter);
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

        public static Intervju_U_Stampi_View VratiIntervjueUStampiID(int id)//200OK
        {
            Intervju_U_Stampi_View sk;
            try
            {
                ISession s = DataLayer.GetSession();

                Intervju_U_Stampi intervju = s.Load<Intervju_U_Stampi>(id);


                sk = new Intervju_U_Stampi_View(intervju);


                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return sk;
        }

        public static void DodajKoordinatoraZaIntervjuUStampi(Koordinator_Opstine_View novikoordinator, int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine koordinator = s.Load<Koordinator_Opstine>(novikoordinator.Id);
                Intervju_U_Stampi intervju = s.Load<Intervju_U_Stampi>(id);
                intervju.Koordinator = koordinator;
                koordinator.Izborne_Aktivnosti.Add(intervju);

                s.SaveOrUpdate(intervju);
                s.SaveOrUpdate(koordinator);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DodajIntervjuUStampi(int idKoordinaoraOpstine, Intervju_U_Stampi ius)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Intervju_U_Stampi dl = new Intervju_U_Stampi
                {
                    Naziv = ius.Naziv,
                    DatumIntervjua = ius.DatumIntervjua,
                    DatumObjavljivanja = ius.DatumObjavljivanja,
                    Novinar = ius.Novinar,
                    Koordinator = kOpstine

                };

                s.SaveOrUpdate(dl);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Intervju_U_Stampi_View AzurirajIntervjuUStampi(Intervju_U_Stampi_View ius)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Intervju_U_Stampi o = s.Load<Intervju_U_Stampi>(ius.Id);
                o.Naziv = ius.Naziv;
                o.DatumIntervjua = ius.DatumIntervjua;
                o.DatumObjavljivanja = ius.DatumObjavljivanja;
                o.Novinar = ius.Novinar;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return ius;
        }

        public static void ObrisiIntervjuUStampi(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Intervju_U_Stampi ius = s.Load<Intervju_U_Stampi>(id);

                ius.Koordinator = null;


                s.SaveOrUpdate(ius);
                s.Flush();

                s.Delete(ius);
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

        #region Gostovanja

        public static List<Gostovanja_View> VratiSvaGostovanja()//200OK
        {
            List<Gostovanja_View> rez = new List<Gostovanja_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Gostovanja> gostovanja = from o in s.Query<Gostovanja>()
                                                     select o;

                foreach (Gostovanja o in gostovanja)
                {
                    var gost = new Gostovanja_View(o);
                    rez.Add(gost);
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

        public static Gostovanja_View VratiGostovanjeID(int id)//200OK
        {
            Gostovanja_View g;
            try
            {
                ISession s = DataLayer.GetSession();

                Gostovanja gost = s.Load<Gostovanja>(id);


                g = new Gostovanja_View(gost);


                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return g;
        }

        public static void DodajKoordinatoraZaGostovanje(Koordinator_Opstine_View novikoordinator, int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine koordinator = s.Load<Koordinator_Opstine>(novikoordinator.Id);
                Gostovanja gost = s.Load<Gostovanja>(id);
                gost.Koordinator = koordinator;
                koordinator.Izborne_Aktivnosti.Add(gost);

                s.SaveOrUpdate(gost);
                s.SaveOrUpdate(koordinator);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void DodajGostovanje(int idKoordinaoraOpstine, Gostovanja_View g)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Gostovanja dl = new Gostovanja
                {
                    ProcenjenaGledanost = g.ProcenjenaGledanost,
                    NazivEmisije = g.NazivEmisije,
                    NazivMedija = g.NazivMedija,
                    Voditelj = g.Voditelj,
                    Koordinator = kOpstine

                };

                s.SaveOrUpdate(dl);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Gostovanja_View AzurirajGostovanja(Gostovanja_View g)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Gostovanja o = s.Load<Gostovanja>(g.Id);
                o.ProcenjenaGledanost = g.ProcenjenaGledanost;
                o.NazivEmisije = g.NazivEmisije;
                o.NazivMedija = g.NazivMedija;
                o.Voditelj = g.Voditelj;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return g;
        }

        public static void ObrisiGostovanja(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Gostovanja g = s.Load<Gostovanja>(id);

                g.Koordinator = null;


                s.SaveOrUpdate(g);
                s.Flush();

                s.Delete(g);
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

        #region Duel

        public static List<Duel_View> VratiDuele()//200OK
        {
            List<Duel_View> rez = new List<Duel_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Duel> dl = from o in s.Query<Duel>()
                                       select o;

                foreach (Duel o in dl)
                {
                    var dlview = new Duel_View(o);
                    dlview.Protivkandidati = o.Protivkandidati.Select(prot => new Protivkandidati_View(prot)).ToList();
                    dlview.Pitanja = o.Pitanja.Select(pit => new Pitanja_View(pit)).ToList();

                    rez.Add(dlview);
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

        public static Duel_View VratiDuelID(int id)//200OK
        {
            Duel_View dl;
            try
            {
                ISession s = DataLayer.GetSession();

                Duel duel = s.Load<Duel>(id);


                dl = new Duel_View(duel);
                dl.Protivkandidati = duel.Protivkandidati.Select(prot => new Protivkandidati_View(prot)).ToList();
                dl.Pitanja = duel.Pitanja.Select(prot => new Pitanja_View(prot)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return dl;
        }

        public static void DodajDuel(int idKoordinaoraOpstine, Duel dlview)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine kOpstine = s.Load<Koordinator_Opstine>(idKoordinaoraOpstine);

                Duel dl = new Duel
                {
                    Koordinator = kOpstine
                };

                s.SaveOrUpdate(dl);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DodajProtivkandidata(int id, ProtivkandidatiId lid)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Duel duel = s.Load<Duel>(id);

                var l = new Protivkandidati
                {
                    Id = new ProtivkandidatiId
                    {
                        Duel = duel,
                        Protivkandidat = lid.Protivkandidat
                    }
                };


                duel.Protivkandidati.Add(l);

                s.SaveOrUpdate(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DodajPitanja(int id, PitanjaId lid)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Duel duel = s.Load<Duel>(id);

                var l = new Pitanja
                {
                    Id = new PitanjaId
                    {
                        Duel = duel,
                        Pitanja = lid.Pitanja
                    }
                };


                duel.Pitanja.Add(l);

                s.SaveOrUpdate(l);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ObrisiDuel(int id)//200OK
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Duel dl = s.Load<Duel>(id);

                dl.Pitanja.Clear();
                dl.Koordinator = null;
                dl.Protivkandidati.Clear();


                s.SaveOrUpdate(dl);
                s.Flush();

                s.Delete(dl);
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

        #endregion
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
                    Glasacka_Mesta_View gm = new Glasacka_Mesta_View(a_s)
                    {
                        Primedbe = a_s.Primedbe.Select(prim => new Primedbe_View(prim)).ToList(),
                        Aktivisti = a_s.Aktivisti.Select(akt => new Aktivista_Stranke_View(akt)).ToList(),
                        Rezultati = a_s.Rezultati.Select(rezultati => new Rezultati_View(rezultati)).ToList()
                    };

                    rez.Add(gm);

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


        public static Glasacka_Mesta_View PreuzmiGlasackoMesto(int id)
        {
            Glasacka_Mesta_View gm;
            try
            {
                ISession s = DataLayer.GetSession();

                Glasacka_Mesta glasacko_mesto = s.Load<Glasacka_Mesta>(id);


                gm = new Glasacka_Mesta_View(glasacko_mesto)
                {
                    Aktivisti = glasacko_mesto.Aktivisti.Select(akt => new Aktivista_Stranke_View(akt)).ToList(),
                    Primedbe = glasacko_mesto.Primedbe.Select(prim => new Primedbe_View(prim)).ToList(),
                    Rezultati = glasacko_mesto.Rezultati.Select(rez => new Rezultati_View(rez)).ToList()
                };

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return gm;
        }

        public static void DodajGlasackoMesto(Glasacka_Mesta_View gm)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glasacka_Mesta glasacko_mesto = new Glasacka_Mesta
                {
                    Naziv = gm.Naziv,
                    Broj_biraca = gm.Broj_biraca,
                    Broj_mesta = gm.Broj_mesta
                };

                s.SaveOrUpdate(glasacko_mesto);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static Glasacka_Mesta_View AzurirajGlasackoMesto(Glasacka_Mesta_View gm)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glasacka_Mesta o = s.Load<Glasacka_Mesta>(gm.Id);
                o.Naziv = gm.Naziv;
                o.Broj_biraca = gm.Broj_biraca;
                o.Broj_mesta = gm.Broj_mesta;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return gm;
        }

        public static void ObrisiGlasackoMesto(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Glasacka_Mesta o = s.Load<Glasacka_Mesta>(id);

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

        #region Rezultati

        public static List<Rezultati_View> PreuzmiRezultate()
        {
            List<Rezultati_View> rez = new List<Rezultati_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Rezultati> rez1 = from o in s.Query<Rezultati>()
                                              select o;

                foreach (Rezultati a_s in rez1)
                {
                    Rezultati_View gm = new Rezultati_View(a_s);

                    rez.Add(gm);
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


        public static Rezultati_View PreuzmiRezultat(int id)
        {
            Rezultati_View rez;
            try
            {
                ISession s = DataLayer.GetSession();

                Rezultati rezultati = s.Load<Rezultati>(id);


                rez = new Rezultati_View(rezultati);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return rez;
        }

        public static void DodajRezultat(Rezultati_View rez)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rezultati glasacko_mesto = new Rezultati
                {
                    Broj_Biraca = rez.Broj_Biraca,
                    Procenat_Glasanja = rez.Procenat_Glasanja,
                    Krug_Izbora = rez.Krug_Izbora
                };

                s.SaveOrUpdate(glasacko_mesto);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static Rezultati_View AzurirajRezultate(Rezultati_View rez)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rezultati o = s.Load<Rezultati>(rez.Id);
                o.Broj_Biraca = rez.Broj_Biraca;
                o.Procenat_Glasanja = rez.Procenat_Glasanja;
                o.Krug_Izbora = rez.Krug_Izbora;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return rez;
        }

        public static void ObrisiRezultat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rezultati o = s.Load<Rezultati>(id);

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

        #region KoordinatorOpstine

        public static List<Koordinator_Opstine_View> PreuzmiKoordinatoreOpstine()
        {
            List<Koordinator_Opstine_View> rez = new List<Koordinator_Opstine_View>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Koordinator_Opstine> rez1 = from o in s.Query<Koordinator_Opstine>()
                                                        select o;

                foreach (Koordinator_Opstine koordinator in rez1)
                {
                    var k = new Koordinator_Opstine_View(koordinator);
                    k.Izborne_Aktivnosti = koordinator.Izborne_Aktivnosti.Select(krd => new Izborne_Aktivnosti_View(krd)).ToList();

                    rez.Add(k);
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

        public static Koordinator_Opstine_View PreuzmiKoordinatoraOpstineID(int id)
        {
            Koordinator_Opstine_View k;
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine koordinator = s.Load<Koordinator_Opstine>(id);


                k = new Koordinator_Opstine_View(koordinator);
                k.Izborne_Aktivnosti = koordinator.Izborne_Aktivnosti.Select(krd => new Izborne_Aktivnosti_View(krd)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return k;
        }

        public static void DodajKoordinatoraOpstine(Koordinator_Opstine_View koordinator)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine aktivista = new Koordinator_Opstine
                {
                    Licno_ime = koordinator.Licno_ime,
                    Ime_roditelja = koordinator.Ime_roditelja,
                    Prezime = koordinator.Prezime,
                    Datum_rodjenja = koordinator.Datum_rodjenja,
                    Ulica = koordinator.Ulica,
                    Broj = koordinator.Broj,
                    Ime_Opstine = koordinator.Ime_Opstine,
                    Adresa_Kancelarije = koordinator.Adresa_Kancelarije
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

        public static Koordinator_Opstine_View AzurirajKoordinatoraOpstine(Koordinator_Opstine_View koordinator)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine o = s.Load<Koordinator_Opstine>(koordinator.Id);
                o.Licno_ime = koordinator.Licno_ime;
                o.Ime_roditelja = koordinator.Ime_roditelja;
                o.Prezime = koordinator.Prezime;
                o.Datum_rodjenja = koordinator.Datum_rodjenja;
                o.Ulica = koordinator.Ulica;
                o.Broj = koordinator.Broj;
                o.Adresa_Kancelarije = koordinator.Adresa_Kancelarije;
                o.Ime_Opstine = koordinator.Ime_Opstine;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return koordinator;
        }

        public static void ObrisiKoordinatoraOpstine(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Koordinator_Opstine o = s.Load<Koordinator_Opstine>(id);
                o.Izborne_Aktivnosti.Clear();

                s.SaveOrUpdate(o);
                s.Flush();

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion KoordinatorOpstine

    }
}
