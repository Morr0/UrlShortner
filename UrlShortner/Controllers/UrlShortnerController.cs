using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortner.Dtos;
using UrlShortner.Services;

namespace UrlShortner.Controllers
{
    [Route("u")]
    [ApiController]
    public class UrlShortnerController : ControllerBase
    {
        private IUrlShortnerService _service;

        public UrlShortnerController(IUrlShortnerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _service.GetMostViewed(10));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ShortcutWriteDto writeDto)
        {
            var dto = await _service.Shorten(writeDto);
            return dto == null ? BadRequest() : Ok(dto) as IActionResult;
        }

        [HttpGet("{shortendUrl}")]
        public async Task<IActionResult> RedirectToOriginalUrl([FromRoute][NotNull] string shortendUrl)
        {
            string originalUrl = await _service.GetOriginalUrl(shortendUrl);
            if (originalUrl is null) return NotFound();

            return Redirect(originalUrl);
        }
    }
}