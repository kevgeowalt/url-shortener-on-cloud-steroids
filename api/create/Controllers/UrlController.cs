using Microsoft.AspNetCore.Mvc;
using shared.Helpers;
using Shortener.Models;

using Microsoft.Extensions.Options;
using shared.services;

namespace Shortener.Controllers
{
    [ApiController]
    [Route("url")]
    public class UrlController : ControllerBase
    {
        private readonly IOptionsSnapshot<Settings> options;
        private readonly IUrlService urlService;
        private Settings _config;

        public UrlController(IOptionsSnapshot<Settings> options, IUrlService urlService)
        {
            this.options = options;
            this.urlService = urlService;
            _config = options.Value;
        }

        [HttpPost]
        [Route("shorten")]
        public async Task<IActionResult> ShortenUrl(UrlRequest model)
        {
            var createResult = await urlService.ShortenAsync(model.LongUrl);
            return Ok(createResult);
        }
    }
}