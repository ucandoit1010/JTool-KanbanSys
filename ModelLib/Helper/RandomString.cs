using System;
using System.Collections.Generic;


namespace ModelLib.Helper
{
    public class RandomString
    {
        public string GetRandomString()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[8];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = string.Format("{0}{1}", new String(stringChars), DateTime.Now.Millisecond.ToString());

            return finalString;
        }


    }
}
