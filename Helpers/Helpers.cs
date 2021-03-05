using System;
using System.Text;

namespace Selenium_Homework.Helpers
{
    public static class Helpers
    {
        private static Random rnd = new Random();

        public static string RandomString(int size)
        {
            StringBuilder sb = new StringBuilder();
            char ch;
            for(int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*rnd.NextDouble() + 65)));
                sb.Append(ch);
            }
            return sb.ToString();
        }
    }
}
