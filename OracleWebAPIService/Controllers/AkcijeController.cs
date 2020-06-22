using System;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using DatabaseAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OracleWebAPIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AkcijeController : ControllerBase
    {
        #region DeljenjeLetki
        [HttpGet]
        [Route("PreuzmiDeljenjeLetki")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAktivistuStranke(int aktivistaID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiDeljenjeLetki());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiDeljenjeLetkiID/{deljenjeLetkiID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiDeljenjeLetkiID(int deljenjeLetkiID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiDeljenjeLetkiID(deljenjeLetkiID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAktivistuZaDL/{deljenjeLetkiID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddOdeljenjeDo5WithProdavnica([FromRoute(Name = "deljenjeLetkiID")]int deljenjeLetkiID, [FromBody]Aktivista_Stranke_View aktivista)
        {
            try
            {
                DataProvider.DodajktivistuZaDeljenjeLetki(aktivista,deljenjeLetkiID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajLetku/{idKoordinatora}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLetku(int idKoordinatora, [FromBody]Deljenje_Letki dlview)
        {
            try
            {
                DataProvider.DodajLetku(idKoordinatora, dlview);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajLokacijuZaLetku/{letkaID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLetku(int letkaID,[FromBody]LokacijeId dlview)
        {
            try
            {
                DataProvider.DodajLokacijuZaLetku(letkaID, dlview);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajDeljenjeLetki")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeProdavnica([FromBody]Deljenje_Letki_View dlview)
        {
            try
            {
                DataProvider.AzurirajDeljenjeLetki(dlview);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiDeljenjeLetki/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProdavnica(int id)
        {
            try
            {
                DataProvider.ObrisiDeljenjeLetki(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion DeljenjeLetki

        #region SusretiKandidataSaGradjanima

        [HttpGet]
        [Route("PreuzmiSusreteKandidataSaaGradjnima")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSusreteKandidataSaGradjanima(int aktivistaID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveSusreteKandidataSaGradjanima());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiSusreteKandidataSaaGradjnimaID/{sksgID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSusreteKandidataSaGradjanimaID(int sksgID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSusreteKandidataSaGradjanimaID(sksgID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAktivistuZaSusretSaGradjanima/{skID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAktvistaZaSusretKandidataSaGradjanima([FromRoute(Name = "skID")]int skID, [FromBody]Aktivista_Stranke_View aktivista)
        {
            try
            {
                DataProvider.DodajktivistuZaSusretSaGradjanima(aktivista, skID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSusretKandidataSaGradjanima/{idKoordinatora}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddSusretKandidataSaGradjanima(int idKoordinatora, [FromBody]Susreti_Kandidata_Sa_Gradjanima_View skview)
        {
            try
            {
                DataProvider.DodajSusretKandidataSaGradjanima(idKoordinatora, skview);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajSusretKandidataSaGrdjanima")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeSusretKandidataSaGradjanima([FromBody]Susreti_Kandidata_Sa_Gradjanima_View skview)
        {
            try
            {
                DataProvider.AzurirajSusretKandidataSaGradjanima(skview);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiSusretKandidataSaGradjanima/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSusretKandidataSaGradjanima(int id)
        {
            try
            {
                DataProvider.ObrisiSusretKandidataSaGradjanima(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion SusretiKandidataSaGradjanima

        #region PolitickiMitingNaOtvorenom

        [HttpGet]
        [Route("PreuzmiPolitickiMitingNaOtvorenom")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPolitickiMitingNaOtvorenom()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveMitingeNaOtvorenom());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("VratiMitingNaOtvorenomID/{mitingID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetMitingNaOtovrenomID(int mitingID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiMitingNaOtvorenomID(mitingID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAktivistuMitingNaOtvorenom/{mitingID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAktivistuMitingNaOtvorenom([FromRoute(Name = "mitingID")]int mitingID, [FromBody]Aktivista_Stranke_View aktivista)
        {
            try
            {
                DataProvider.DodajAktivistuMitingNaOtvorenom(aktivista, mitingID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        [Route("DodajGostaMitingNaOtvorenom/{mitingID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAktivistuMitingNaOtvorenom([FromRoute(Name = "mitingID")]int mitingID, [FromBody]Gost_View gost)
        {
            try
            {
                DataProvider.DodajGostaMitingNaOtvorenom(gost, mitingID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajMitingNaOtvorenom/{idKoordinatora}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddMitingNaOtvorenom(int idKoordinatora, [FromBody]Politicki_Miting_Na_Otvorenom_View mitingView)
        {
            try
            {
                DataProvider.DodajMitingNaOtvorenom(idKoordinatora, mitingView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajMitingNaOtvorenom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeMitingNaOtvorenom([FromBody]Politicki_Miting_Na_Otvorenom_View mitingView)
        {
            try
            {
                DataProvider.AzurirajMitingNaOtvorenom(mitingView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiMitingNaOtvorenom/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteMitingNaOtvorenom(int id)
        {
            try
            {
                DataProvider.ObrisiMitingNaOtvorenom(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiGostaMitingNaOtvorenom/{mitingID}/{gostID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteGostMitingNaOtvorenom([FromRoute(Name = "mitingID")]int mitingID, [FromRoute(Name = "gostID")]int gostID)
        {
            try
            {
                DataProvider.ObrisiGostaSaMitingaNaZatvorenom(mitingID, gostID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion PolitickiMitingNaOtvorenom

        #region PolitickiMitingNaZatvorenom

        [HttpGet]
        [Route("PreuzmiPolitickiMitingNaZatvorenom")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPolitickiMitingNaZatvorenom()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveMitingeNaZatvorenom());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("VratiMitingNaZatvorenomID/{mitingID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetMitingNaZatvorenomID(int mitingID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiMitingNaZatvorenomID(mitingID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAktivistuMitingNaZatvorenom/{mitingID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAktivistuMitingNaZatvorenom([FromRoute(Name = "mitingID")]int mitingID, [FromBody]Aktivista_Stranke_View aktivista)
        {
            try
            {
                DataProvider.DodajAktivistuMitingNaZatvorenom(aktivista, mitingID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        [Route("DodajGostaMitingNaZatvorenom/{mitingID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAktivistuMitingNaZatvorenom([FromRoute(Name = "mitingID")]int mitingID, [FromBody]Gost_View gost)
        {
            try
            {
                DataProvider.DodajGostaMitingNaZatvorenom(gost, mitingID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajMitingNaZatvorenom/{idKoordinatora}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddMitingNaZatvorenom(int idKoordinatora, [FromBody]Politicki_Miting_Na_Zatvorenom_View mitingView)
        {
            try
            {
                DataProvider.DodajMitingNaZatvorenom(idKoordinatora, mitingView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajMitingNaZatvorenom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeMitingNaZatvorenom([FromBody]Politicki_Miting_Na_Zatvorenom_View mitingView)
        {
            try
            {
                DataProvider.AzurirajMitingNaZatvorenom(mitingView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiMitingNaZatvorenom/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteMitingNaZatvorenom(int id)
        {
            try
            {
                DataProvider.ObrisiMitingNaZatvorenom(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiGostaMitingNaZatvorenom/{mitingID}/{gostID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteGostMitingNaZatvorenom([FromRoute(Name = "mitingID")]int mitingID, [FromRoute(Name = "gostID")]int gostID)
        {
            try
            {
                DataProvider.ObrisiGostaSaMitingaNaZatvorenom(mitingID, gostID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion PolitickiMitingNaZatvorenom

    }
}
