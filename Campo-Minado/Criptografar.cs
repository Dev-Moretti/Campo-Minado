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


    }
}
