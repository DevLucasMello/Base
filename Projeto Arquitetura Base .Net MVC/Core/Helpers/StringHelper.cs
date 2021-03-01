using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class StringHelper
    {

        private const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
        private const string NUMBERS = "1234567890";
        private const string SPECIALS = "!@#$%&*()_+-=";

        public static string Generate(int size, bool uppercase = true, bool lowercase = true, bool numbers = true, bool specials = true)
        {
            var chars = "";
            if (uppercase)
            {
                chars += UPPERCASE;
            }
            if (lowercase)
            {
                chars += LOWERCASE;
            }
            if (numbers)
            {
                chars += NUMBERS;
            }
            if (specials)
            {
                chars += SPECIALS;
            }

            int max = chars.Length;

            Random random = new Random();
            StringBuilder generated;
            do
            {
                generated = new StringBuilder(size);
                for (int index = 0; index < size; index++)
                    generated.Append(chars[random.Next(0, max)]);
            }
            while (!Validate(generated.ToString(), size, uppercase ? 1 : 0, lowercase ? 1 : 0, numbers ? 1 : 0, specials ? 1 : 0));
            return generated.ToString();
        }

        public static bool Validate(string input, int size, int uppercase = 0, int lowercase = 0, int numbers = 0, int specials = 0)
        {
            if (input.Length < size)
            {
                return false;
            }

            if (input.Sum(i => UPPERCASE.Count(u => u == i)) < uppercase)
            {
                return false;
            }

            if (input.Sum(i => LOWERCASE.Count(l => l == i)) < lowercase)
            {
                return false;
            }

            if (input.Sum(i => NUMBERS.Count(n => n == i)) < numbers)
            {
                return false;
            }

            if (input.Sum(i => SPECIALS.Count(s => s == i)) < specials)
            {
                return false;
            }

            return true;
        }

    }
}
