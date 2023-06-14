namespace Business.Helpers
{
    public static class Base64Converter
    {
        public static byte[] Base64ToBytes(string base64)
        {
            return Convert.FromBase64String(base64);
        }
    }
}
