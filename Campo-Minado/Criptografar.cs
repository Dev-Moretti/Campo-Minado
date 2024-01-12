using System;
using System.Text;

namespace Campo_Minado
{
    static class Criptografar
    {
        public static string StringEncodeBase64(string textoEncode)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(textoEncode);

            return Convert.ToBase64String(bytes);
        }

        public static string StringDecodeBase64(string textoDecode)
        {
            byte[] bytes = Convert.FromBase64String(textoDecode);

            return Encoding.UTF8.GetString(bytes);
        }

        //public string EncodeIntBase64String(int encode)
        //{
        //    byte[] bytes = BitConverter.GetBytes(encode);

        //    return Convert.ToBase64String(bytes);
        //}

        //public int DecodeStringBase64Int(string decode)
        //{
        //    byte[] base64Bytes = Convert.FromBase64String(decode);

        //    return BitConverter.ToInt32(base64Bytes, 0);
        //}

    }
}
