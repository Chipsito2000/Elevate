namespace ElevateERP.Filtro
{

    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// clase extension de sesiones
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Recibe la sesion tomada
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }


        /// <summary>
        /// Manda la sesion tomada
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
