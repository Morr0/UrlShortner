using System;
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ShortcutWriteDto writeDto)
        {
            var dto = await _service.Shorten(writeDto);
            return dto == null ? BadRequest() : Ok(dto) as IActionResult;
        }
    }
}