using Microsoft.AspNetCore.Http;
using UAParser;

namespace Finanzuebersicht.Backend.Admin.Core.API.Tools.UserAgent
{
    public static class UserAgentParser
    {
        public static string GetBrowser(HttpRequest request)
        {
            ClientInfo c = GetClientInfoFromRequest(request);
            return c.UA.Family;
        }

        public static string GetOperatingSystem(HttpRequest request)
        {
            ClientInfo c = GetClientInfoFromRequest(request);
            return c.OS.ToString();
        }

        private static ClientInfo GetClientInfoFromRequest(HttpRequest request)
        {
            var adminEmailUserAgent = request.Headers["User-Agent"].ToString();

            var adminEmailUserAgentParser = Parser.GetDefault();

            ClientInfo c = adminEmailUserAgentParser.Parse(adminEmailUserAgent);
            return c;
        }
    }
}