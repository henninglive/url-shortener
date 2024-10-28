using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Web.Services;

namespace UrlShortener.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IUrlService _service;

    public IndexModel(ILogger<IndexModel> logger, IUrlService service)
    {
        _logger = logger;
        _service = service;
    }
    
    public ActionResult OnPost()
    {
        var url = Request.Form["url"];
        var id = _service.CreateRoute(url);
        return Redirect($"/Details/{id}");
    }
}