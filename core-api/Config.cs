using System;

namespace CoreApi
{
    public class Config
    {
        public static string SecretKey => Environment.GetEnvironmentVariable("SECRET_KEY");
    }
}