using System.Security.Cryptography;
using UrlShortener.Web.Database;

namespace UrlShortener.Web.Services;

public class UrlService : IUrlService
{
    private readonly DatabaseContext _context;

    public UrlService(DatabaseContext context)
    {
        _context = context;
    }

    public string CreateRoute(string url)
    {
        string hash = HashUrl(url);

        UrlEntity? route = _context.Urls
            .FirstOrDefault(x => x.Id == hash);

        if (route == null) {
            route = new UrlEntity() { Id = hash, Url = url };
            _context.Urls.Add(route);
            _context.SaveChanges();
        }

        return route.Id;
    }

    public string? GetRoute(string id)
    {
        UrlEntity? url = _context.Urls
            .FirstOrDefault(x => x.Id == id);

        return url?.Url;
    }

    private static string HashUrl(string url)
    {
        using MD5 md5 = MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(url);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes).Substring(0, 8);
    }
}