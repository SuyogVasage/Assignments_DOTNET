using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace SuperMarket_23March.SessionExtensions
{
    public static class SessionExtensions
    {
        public static void SetSessionData<T>(this ISession session, string sessionKey, T sessionValue)
        {
            session.SetString(sessionKey, JsonSerializer.Serialize(sessionValue));
        }

        public static T GetSessionData<T>(this ISession session, string sessionKey)
        {
            var data = session.GetString(sessionKey);
            if (data == null)
            {
                return default(T);
            }
            else
            {
                return JsonSerializer.Deserialize<T>(data);
            }
        }
    }
}
