using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHotel.Repository.Helper
{
    public class Utility
    {
        private static readonly Random Random = new Random();
        public static string GenerateUnikeAuditId()
        {
            var seconds = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            var guidStr = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var guid = Encoding.UTF8.GetBytes(guidStr);
            var timeBytes = Encoding.UTF8.GetBytes(seconds.ToString());
            var randomBytes = Encoding.UTF8.GetBytes(GetRandomAlphaNumericString(5));

            var combinedBites = CombineTwoByteArrays(timeBytes, randomBytes);
            combinedBites = CombineTwoByteArrays(combinedBites, guid);

            string unikeId = Encoding.UTF8.GetString(combinedBites, 0, combinedBites.Length - 20);
            return unikeId;

        }

        private static string GetRandomAlphaNumericString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        private static byte[] CombineTwoByteArrays(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        private static int convertStringToAscIICode(string stringToConvert)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(stringToConvert);
            int result = BitConverter.ToInt32(bytes, 0);
            return result;
        }
    }
}
