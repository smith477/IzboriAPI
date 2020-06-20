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
    public class AktivistaStrankeController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiAktivisteStranke")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProdavnice()
        {
            try
            {
                return new JsonResult(DataProvider.PreuzmiAktivisteStranke());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiAktivistuStranke/{aktivistaID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAktivistuStranke(int aktivistaID)
        {
            try
            {
                return new JsonResult(DataProvider.PreuzmiAktivistuStranke(aktivistaID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAktivistuStranke")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAktivistaStranke([FromBody]Aktivista_Stranke_View p)
        {
            try
            {
                DataProvider.DodajAktivistuStranke(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniAktivistuStranke")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeProdavnica([FromBody]Aktivista_Stranke_View p)
        {
            try
            {
                DataProvider.AzurirajAktivistuStranke(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiAktivistuStranke/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProdavnica(int id)
        {
            try
            {
                DataProvider.ObrisiAktivistuStranke(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
