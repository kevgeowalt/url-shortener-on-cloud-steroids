using Microsoft.AspNetCore.Mvc;
using shared.Helpers;
using Shortener.Models;

using Microsoft.Extensions.Options;

namespace Shortener.Controllers
{
    [ApiController]
    [Route("url")]
    public class UrlController : ControllerBase
    {
        private readonly IOptionsSnapshot<Settings> options;
        private Settings _config;

        public UrlController(IOptionsSnapshot<Settings> options)
        {
            this.options = options;
            _config = options.Value;
        }

        [HttpPost]
        [Route("shorten")]
        public async Task<IActionResult> ShortenUrl(UrlRequest model)
        {
            return Ok();
        }
    }
}