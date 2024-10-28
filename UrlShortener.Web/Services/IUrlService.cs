namespace UrlShortener.Web.Services;

public interface IUrlService
{
    public string? GetRoute(string id);
    public string CreateRoute(string url);
}