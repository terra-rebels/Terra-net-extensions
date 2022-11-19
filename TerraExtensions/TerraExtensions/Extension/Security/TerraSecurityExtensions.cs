using RandomStringCreator;

namespace TerraNetExtensions.Security
{
    public static class TerraSecurityExtensions
    {
        public static string GetRandomStringFor128Encryption()
        {
            using (var randomString = new StringCreator())
            {
                return randomString.Get(16);
            }
        }

        public static string GetRandomStringFor256BitEncryption()
        {
            using (var randomString = new StringCreator())
            {
                return randomString.Get(32);
            }
        }
    }
}
