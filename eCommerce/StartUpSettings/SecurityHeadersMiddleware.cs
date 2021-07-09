using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.StartUpSettings
{

    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Sayfanın herhangi bir frame içerisinde çağırılmasını tamamiyle engellemek için kullanılır.
            httpContext.Response.Headers.Add("X-Frame-Options", "DENY");
            //X-XSS - Protection
            httpContext.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
            httpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            //httpContext.Response.Headers.Add(
            //    "Content-Security-Policy",
            //    "default-src 'self'; " +
            //    "img-src 'self' {your_awesome_url}; " +
            //    "font-src 'self'; " +
            //    "style-src 'self'; " +
            //    "script-src 'self' 'nonce-{your_awesome_key}' " +
            //    " 'nonce-{your_awesome_key}'; " +
            //    "frame-src 'self';" +
            //    "connect-src 'self';");
            //Hedef site de yine Referer headerı ile bu gezinime kaynak teşkil eden siteyi görebilir. 
            httpContext.Response.Headers.Add("Referrer-Policy", "no-referrer");
            httpContext.Response.Headers.Add("Feature-Policy", "accelerometer 'none'; camera 'none';" +
                                                               " geolocation 'none'; gyroscope 'none'; " +
                                                               "magnetometer 'none'; microphone 'none'; " +
                                                               "payment 'none'; usb 'none'");


            await next(httpContext);
        }
    }

}
