using DatabaseAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DatabaseAccess.DTOs;

namespace OracleWebAPIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KoordinatorOpstineController : ControllerBase
    {
        #region KoordinatorOpstine
        [HttpGet]
        [Route("PreuzmiKoordinatoreOpstine")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKoordinatoreOpstine()
        {
            try
            {
                return new JsonResult(DataProvider.PreuzmiKoordinatoreOpstine());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiKoordinatoraOpstineID/{koordinatorID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKoordinatoraOpstineID(int koordinatorID)
        {
            try
            {
                return new JsonResult(DataProvider.PreuzmiKoordinatoraOpstineID(koordinatorID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKoordinatoraOpstine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddDodajKoordinatoraOpstine([FromBody]Koordinator_Opstine_View koordinator)
        {
            try
            {
                DataProvider.DodajKoordinatoraOpstine(koordinator);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniKoordinatoraOpstine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeKoordinatoraOpstine([FromBody]Koordinator_Opstine_View koordinator)
        {
            try
            {
                DataProvider.AzurirajKoordinatoraOpstine(koordinator);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiKoordinatoraOpstine/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteKoordinatoraOpstine(int id)
        {
            try
            {
                DataProvider.ObrisiKoordinatoraOpstine(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion KoordinatorOpstine
    }
}
