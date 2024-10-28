using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Web.Services;

namespace UrlShortener.Web.Pages;

public class Details : PageModel
{
    private readonly IUrlService _service;

    [BindProperty(SupportsGet = true)]
    public string? Id { get; set; }

    public string? RouteUrl { get; private set; }

    public Details(IUrlService service)
    {
        _service = service;
    }

    public IActionResult OnGet()
    {
        if (Id == null)
        {
            return NotFound();
        }

        RouteUrl = _service.GetRoute(this.Id);
        if (RouteUrl == null)
        {
            return NotFound();
        }

        return Page();
    }
}