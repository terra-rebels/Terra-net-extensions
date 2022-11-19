namespace TerraNetExtensions.StringExt
{
    public static class Bech32NanoExtensions
    {
        public static string? GetBech32EncodeFromString(string hrp, string text) => Nano.Bech32.Bech32Encoder.Encode(hrp, TerraStringExtensions.GetBytesFromString(text));
        public static string? GetBech32EncodeFromData(string hrp, byte[] data) => Nano.Bech32.Bech32Encoder.Encode(hrp, data);

        public static string? DecodeBech32EncodeFromData(string bech32Encoded)
        {
            var hrp = "";
            var data = new byte[bech32Encoded.Length];
            Nano.Bech32.Bech32Encoder.Decode(bech32Encoded, out hrp, out data);

            if (data != null && data.Length != 0)
            {
                return TerraStringExtensions.GetStringFromBytes(data);
            }

            return string.Empty;
        }


        public static bool CheckPrefixAndLength(string prefix, string data, int length)
        {
            var bech32 = DecodeBech32EncodeFromData(data);
            if (!string.IsNullOrWhiteSpace(bech32))
            {
                return bech32.StartsWith(prefix) && data.Length == length;
            }

            return false;
        }
    }
}
