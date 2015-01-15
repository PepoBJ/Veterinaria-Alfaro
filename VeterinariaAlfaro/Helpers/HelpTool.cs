using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace VeterinariaAlfaro.Helpers
{
    public class HelpTool
    {
        public static string md5(string password)
        {
            System.Security.Cryptography.MD5 md5;
            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            Byte[] encodedBytes = md5.ComputeHash(ASCIIEncoding.Default.GetBytes(password));  
            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes).ToLower(), @"-", ""); 
        }
        public static string convertDouble ( double parse )
        {
            return Convert.ToString(parse).Replace(',', '.');
        }
        public static bool soloNumeros(string cadena)
        {
            return Regex.IsMatch(cadena, "^[0-9]+$");
        }
        public static bool soloTexto(string cadena)
        {
            return Regex.IsMatch(cadena, "^[a-z-]+$");
        }
        public static bool alfanumerico(string cadena)
        {
            return Regex.IsMatch(cadena, "^[a-z0-9\\ á-ú.-:+]+$");
        }
    }
}