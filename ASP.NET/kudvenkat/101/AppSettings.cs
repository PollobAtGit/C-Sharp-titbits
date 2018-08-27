using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace _101
{
    public struct AppSettings
    {
        public const string AppTotalUser = "app_total_user";
        public const string SecretKeyKeyName = "secret-key";
        public const string UserNationalId = "nid";
    }

    internal static class Util
    {
        // TODO: Duplicate
        internal static object GetFromStorage(this HttpSessionState storage, string key)
        {
            try
            {
                return storage[key];
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static void SetToStorage(this HttpSessionState storage, string key, object value)
            => storage[key] = value;

        internal static object GetFromStorage(this HttpApplicationState storage, string key)
        {
            try
            {
                return storage[key];
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static void SetToStorage(this HttpApplicationState storage, string key, object value)
            => storage[key] = value;
    }
}