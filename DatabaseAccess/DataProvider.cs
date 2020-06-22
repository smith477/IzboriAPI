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

        #region akcije

        #region deljenjeletki

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
                    dlview.Lokacije = o.Lokacije.Select(o => new Lokacije_View(o)).ToList();
                    dlview.Aktivisti = o.Aktivisti.Select(o => new Aktivista_Stranke_View(o)).ToList();

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
                dl.Lokacije = deljenejLetki.Lokacije.Select(deljenejLetki => new Lokacije_View(deljenejLetki)).ToList();
                dl.Aktivisti = deljenejLetki.Aktivisti.Select(deljenejLetki => new Aktivista_Stranke_View(deljenejLetki)).ToList();

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
        
        public static void DodajLokacijuZaLetku(int id,LokacijeId lid)//200OK
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

        public static void DodajktivistuZaDeljenjeLetki(Aktivista_Stranke_View noviaktivista,int id)//200OK
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

        #region susretikandidatasagradjanima

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
                    sksg.Aktivisti = o.Aktivisti.Select(o => new Aktivista_Stranke_View(o)).ToList();
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
                    m.Aktivisti = o.Aktivisti.Select(o => new Aktivista_Stranke_View(o)).ToList();
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
                m.Aktivisti = miting.Aktivisti.Select(miting => new Aktivista_Stranke_View(miting)).ToList();

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
                    m.Aktivisti = o.Aktivisti.Select(o => new Aktivista_Stranke_View(o)).ToList();
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
                m.Aktivisti = miting.Aktivisti.Select(miting => new Aktivista_Stranke_View(miting)).ToList();

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

    }
}
