using System.Text;
using System.Security.Cryptography;
using Crypto.RIPEMD;
using TerraNetExtensions.StringExt;

namespace TerraNetExtensions.ChainExtensions
{
    public class HashExtensions
    {
        public static string GetSha256(string data) => new Plugin.Security.Core.PasswordEncoder()
            .Encode(data, Plugin.Security.Core.EncryptType.SHA_256);
        public static string GetRIPEMD160(string data) => RIPEMD160Managed.HashInString(data);

        public static string HashToHex(string data)
        {
            return GetSha256(TerraStringExtensions.GetStringFromBase64(data)).ToUpper();
        }


        public static byte[] sha256(string data)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return hash.ComputeHash(Encoding.ASCII.GetBytes(data));
            }
        }
        private static char ToHexDigit(int i)
        {
            if (i < 10)
                return (char)(i + '0');
            return (char)(i - 10 + 'A');
        }
        public static string ToHexString(byte[] bytes)
        {
            var chars = new char[bytes.Length * 2 + 2];

            chars[0] = '0';
            chars[1] = 'x';

            for (int i = 0; i < bytes.Length; i++)
            {
                chars[2 * i + 2] = ToHexDigit(bytes[i] / 16);
                chars[2 * i + 3] = ToHexDigit(bytes[i] % 16);
            }

            return new string(chars);
        }


        public static byte[] Ripemd160(string data)
        {
            using (RIPEMD160 rpmd = new RIPEMD160Managed())
            {
                return rpmd.ComputeHash(Encoding.ASCII.GetBytes(data));
            }
        }

        public static byte[] Bech32Encode(string data)
        {
            using (RIPEMD160 rpmd = new RIPEMD160Managed())
            {
                return rpmd.ComputeHash(Encoding.ASCII.GetBytes(data));
            }
        }
    }
}
