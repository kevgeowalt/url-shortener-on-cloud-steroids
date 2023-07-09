using Microsoft.AspNetCore.Mvc;
using Shortener.Models;

namespace Shortener.Controllers
{
    [ApiController]
    [Route("url")]
    public class UrlController : ControllerBase
    {
        public UrlController()
        {

        }

        [HttpPost]
        [Route("shorten")]
        public async Task ShortenUrl(UrlRequest model)
        {
            throw new NotImplementedException();
        }
    }
}