using System;

namespace core_auth
{
    public static class Config
    {
        public static string SecretKey => Environment.GetEnvironmentVariable("SECRET_KEY");
    }
}