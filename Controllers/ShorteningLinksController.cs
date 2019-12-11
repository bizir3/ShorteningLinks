using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShorteningLinks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShorteningLinksController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "";
        }
    }
}
