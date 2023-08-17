using Microsoft.AspNetCore.Mvc;
using shared.Helpers;
using Shortener.Models;

using Microsoft.Extensions.Options;
using shared.services;

namespace Shortener.Controllers
{
    [ApiController]
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

        [HttpGet("{code}")]
        public async Task<IActionResult> RetrieveUrl(string code)
        {
            string longUrl = string.Empty;

            var result = await urlService.RetrieveAsync(code);
            longUrl = result.Data;

            if (string.IsNullOrWhiteSpace(longUrl))
                return BadRequest(new { message = "URL cannot be empty", success = false });

            return RedirectPermanent(longUrl);
        }
    }
}