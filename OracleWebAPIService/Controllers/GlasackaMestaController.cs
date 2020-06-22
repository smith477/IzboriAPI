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
    public class GlasackaMestaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiGlasackaMesta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PreuzmiGlasackaMesta()
        {
            try
            {
                return new JsonResult(DataProvider.PreuzmiGlasackaMesta());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiGlasackoMesto/{glasackoMestoID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PreuzmiGlasackoMesto(int glasackoMestoID)
        {
            try
            {
                return new JsonResult(DataProvider.PreuzmiGlasackoMesto(glasackoMestoID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajGlasackoMesto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajGlasackoMesto([FromBody]Glasacka_Mesta_View gm)
        {
            try
            {
                DataProvider.DodajGlasackoMesto(gm);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniGlasackoMesto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PromeniGlasackoMesto([FromBody]Glasacka_Mesta_View gm)
        {
            try
            {
                DataProvider.AzurirajGlasackoMesto(gm);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiGlasackoMesto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiGlasackoMesto(int id)
        {
            try
            {
                DataProvider.ObrisiGlasackoMesto(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
