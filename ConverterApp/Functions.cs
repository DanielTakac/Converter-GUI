using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp{

    internal class Functions{

        public static string HashString(string plainText)
        {

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            return System.Convert.ToBase64String(plainTextBytes);

        }

        public static string UnhashString(string base64EncodedData)
        {

            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);

            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

        }

        public static string StringToBinary(string data)
        {

            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {

                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));

            }

            return sb.ToString();

        }

        public static string BinaryToString(string data)
        {

            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {

                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));

            }

            return Encoding.ASCII.GetString(byteList.ToArray());

        }

        public static string StringToHex(string data)
        {

            byte[] ba = Encoding.Default.GetBytes(data);

            var hexString = BitConverter.ToString(ba);

            hexString = hexString.Replace("-", "");

            return hexString;

        }

        public static string HexToString(string data)
        {

            byte[] bb = Enumerable.Range(0, data.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(data.Substring(x, 2), 16))
                     .ToArray();
            return Encoding.ASCII.GetString(bb);

        }

        public static string StringToMorse(string data)
        {

            char[] letters = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            string[] morseLetters = { "    ", ". ___", "___ . . .", "___ . ___ .", "___ . .", ".", ". . ___ .", "___ ___ .", ". . . .", ". .", ". ___ ___ ___", "___ . ___", ". ___ . .", "___ ___", "___ .", "___ ___ ___", ". ___ ___ .", "___ ___ . ___", ". ___ .", ". . .", "_", ". . ___", ". . . ___", ". ___ ___", "___ . . ___", "___ . ___ ___", "___ ___ . .", ". ___ ___ ___ ___", ". . ___ ___ ___", ". . . ___ ___", ". . . . ___", ". . . . .", "___ . . . .", "___ ___ . . .", "___ ___ ___ . .", "___ ___ ___ ___ .", "___ ___ ___ ___ ___" };
            string textToChange = "";
            string newText = "";
            textToChange = data;
            textToChange = textToChange.ToLower();
            for (int i = 0; i < textToChange.Length; i++)
            {

                for (short j = 0; j < 37; j++)
                {

                    if (textToChange[i] == letters[j])
                    {

                        newText += morseLetters[j];
                        newText += "   ";
                        break;

                    }

                }

            }

            return newText;

        }

    }

}
