using Microsoft.AspNetCore.Mvc;
using UrlShortener.Web.Services;

namespace UrlShortener.Web.Controllers;

[Route("/")]
[ApiController]
public class MainController : ControllerBase
{
    private readonly IUrlService _service;

    public MainController(IUrlService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult RedirectedUrl(string id) {
        string? url = _service.GetRoute(id);
        if (url == null)
        {
            return NotFound();
        }

        return Redirect(url);
    }
}