using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OracleWebAPIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RezulatiController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiRezultate")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PreuzmiRezultate()
        {
            try
            {
                return new JsonResult(DataProvider.PreuzmiRezultate());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRezultat/{rezultatID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PreuzmiRezultat(int rezultatID)
        {
            try
            {
                return new JsonResult(DataProvider.PreuzmiRezultat(rezultatID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRezultat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajRezultat([FromBody]Rezultati_View rez)
        {
            try
            {
                DataProvider.DodajRezultat(rez);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniRezultat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PromeniRezultat([FromBody]Rezultati_View rez)
        {
            try
            {
                DataProvider.AzurirajRezultate(rez);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiRezultat/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzbrisiRezultat(int id)
        {
            try
            {
                DataProvider.ObrisiRezultat(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
