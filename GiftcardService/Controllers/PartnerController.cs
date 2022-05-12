using Microsoft.AspNetCore.Mvc;
using System;

namespace GiftcardService.Controllers
{
    [Route("api/gs/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        public PartnerController()
        {

        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("->> Inbound Connection");
            return Ok("Inbound OK");
        }

    }
}
