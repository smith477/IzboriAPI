using System;
using DatabaseAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OracleWebAPIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AkcijeController : ControllerBase
    {
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

    }
}
