using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static string IpAddress(this ControllerBase controllerBase)
        {
            string originIp = controllerBase.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            if (controllerBase.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                originIp = controllerBase.Request.Headers["X-Forwarded-For"][0];
            }

            return originIp;
        }
    }
}