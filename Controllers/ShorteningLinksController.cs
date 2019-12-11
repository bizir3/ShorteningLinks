using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Flurl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShorteningLinks.Helper;
using ShorteningLinks.Models;
using ShorteningLinks.Services;

namespace ShorteningLinks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShorteningLinksController : ControllerBase
    {
        private readonly LinkService _linkService;

        public ShorteningLinksController(LinkService linkService)
        {
            _linkService = linkService;
        }

        [HttpGet]
        public ActionResult<Response<List<Link>>> Get(){
            var guid = HelperUrl.GetGuid(Request);
            return new Response<List<Link>>()
            {
                Errors = new List<string>(),
                Object = _linkService.GetByGuid(guid)
            };
        }

        [HttpPost]
        [Route("CreateLink")]
        public ActionResult<Response<string>> Create([FromForm]string fullUrl)
        {

            var guid = HelperUrl.GetGuid(Request);
            Response.Cookies.Append("Guid", guid);


            string shortUrl = "";
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(fullUrl)) errors.Add("Параметр url не должен быть пустым");

            if (errors.Count == 0)
            {
                shortUrl = GetShortUrlName();
                var link = new Link()
                {
                    FullUrl = fullUrl,
                    ShortUrl = shortUrl,
                    СlickThroughs = 0,
                    Guid = guid
                };
                _linkService.Create(link);
            }

            return new Response<string>()
            {
                Errors = errors,
                Object = shortUrl
            };
        }
        [HttpGet]
        [Route("GetFullUrlByShortUrl")]
        public ActionResult<Response<string>> GetFullUrlByShortUrl([FromQuery]string shortUrl)
        {
            string fullUrl = "";
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(shortUrl)) errors.Add("Параметр url не должен быть пустым");

            if (errors.Count == 0)
            {
                Link link = _linkService.GetByUrlShort(shortUrl);
                if (link != null)
                {
                    fullUrl = link.FullUrl;
                    link.СlickThroughs++;
                    _linkService.Update(link.Id, link);
                } else
                    errors.Add("По данному url ничего не найдено");
                
            }

            return new Response<string>()
            {
                Errors = errors,
                Object = fullUrl
            };
        }
        private string GetShortUrlName()
        {
            string shortUrl = HelperUrl.GetShortUrlName();
            Link link = _linkService.GetByUrlShort(shortUrl);
            if (link == null)
                return shortUrl;
            return GetShortUrlName();
        }
    }
}
