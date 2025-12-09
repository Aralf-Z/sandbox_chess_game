using UnityEngine;

namespace FastGameDev.Helper
{
    public static partial class Extension
    {
        public static string ColorToHex(this Color color)
        {
            var r = (byte)(color.r * 255f);
            var g = (byte)(color.g * 255f);
            var b = (byte)(color.b * 255f);
            var a = (byte)(color.a * 255f);
            
            return $"#{r:X2}{g:X2}{b:X2}{a:X2}";
        }
        
        /// <summary>
        /// 十六进制转换成Color，格式#A6B422FF或者A6B422FF
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static Color Hex2Color(this string hexStr)
        {
            hexStr = hexStr.Replace("#", "");

            var r = byte.Parse(hexStr.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            var g = byte.Parse(hexStr.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            var b = byte.Parse(hexStr.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            if(hexStr.Length == 8)
            {
                var a = byte.Parse(hexStr.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                return new Color32(r, g, b, a);
            }
            else
            {
                return new Color32(r, g, b, 255);
            }
        }
    }
}