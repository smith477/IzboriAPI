using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using System;
using Microsoft.AspNetCore.Routing;

namespace OracleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReklameController : ControllerBase
    {
        #region Mediji
        [HttpGet]
        [Route("PreuzmiSveMedije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetMediji()
        {
            try
            {
                return new JsonResult(DataProvider.VratiMedije());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiveMedijePoId/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetMedijiID([FromRoute(Name = "id")]int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiMedijePoId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajMedije/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajMedije([FromRoute(Name = "id")]int id, [FromBody]Mediji_View m)
        {
            try
            {
                DataProvider.DodajMedije(id, m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKoordinatoraMediji/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajKoordinatoraMediji([FromRoute(Name = "id")]int id, [FromBody]Mediji_View m)
        {
            try
            {
                DataProvider.DodajKoordinatoraMediji(id, m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniMedije")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PromeniMedije([FromBody]Mediji_View m)
        {
            try
            {
                DataProvider.AzurirajMedije(m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiMedije/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiMedije([FromRoute(Name = "id")]int id)
        {
            try
            {
                DataProvider.ObrisiMedije(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion Mediji

        #region Pano

        [HttpGet]
        [Route("PreuzmiPano")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPano()
        {
            try
            {
                return new JsonResult(DataProvider.VratiPano());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPanoPoId/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPanoPoId([FromRoute(Name = "id")]int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiPanoPoId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPano/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajPano([FromRoute(Name = "id")]int id, [FromBody]Pano_View p)
        {
            try
            {
                DataProvider.DodajPano(id, p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKoordinatoraPano/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajKoordinatoraPano([FromRoute(Name = "id")]int id, [FromBody]Pano_View m)
        {
            try
            {
                DataProvider.DodajKoordinatoraPano(id, m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPano")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePano([FromBody]Pano_View p)
        {
            try
            {
                DataProvider.AzurirajPano(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPano/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePano([FromRoute(Name = "id")]int id)
        {
            try
            {
                DataProvider.ObrisiPano(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Stampa

        [HttpGet]
        [Route("PreuzmiSvuStampu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSvuStampu()
        {
            try
            {
                return new JsonResult(DataProvider.VratiStampu());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiStampuPoId/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetStampuPoId([FromRoute(Name = "id")]int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiStampuPoId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajStampu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddStampu([FromRoute(Name = "id")]int id, [FromBody]Stampa_View m)
        {
            try
            {
                DataProvider.DodajStampu(id, m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKoordinatoraStampa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajKoordinatoraStampa([FromRoute(Name = "id")]int id, [FromBody]Stampa_View m)
        {
            try
            {
                DataProvider.DodajKoordinatoraStampa(id, m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniStampu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeStampu([FromBody]Stampa_View m)
        {
            try
            {
                DataProvider.AzurirajStampa(m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiStampu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteStampu([FromRoute(Name = "id")]int id)
        {
            try
            {
                DataProvider.ObrisiStampu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion
    }
}
