using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShorteningLinks.Helper
{
    public class HelperUrl
    {
        private static string chars = "qweerrtyuyuiopasdfghjklzxcvbnm123456789";
        private static Random random = new Random();
        
        public static string GetShortUrlName(int length = 10)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string SetGuid()
        {
            return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        internal static string GetGuid(HttpRequest request)
        {
            if (request.Cookies["Guid"] != null)
                return request.Cookies["Guid"];

            return GetShortUrlName(30);

        }
    }
}
