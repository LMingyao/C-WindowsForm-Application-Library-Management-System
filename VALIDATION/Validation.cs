using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FinalProject2021.VALIDATION
{
    public static class Validation
    {
        public static bool IsValidId(string input)
        {
            if (!(Regex.IsMatch(input, "^\\d{4}$")))
            {
                return false;
            }

            return true;
        }
        public static bool IsValidId(string input, int size, ref string errMessage)
        {
            if (input.Length == 0)
            {
                errMessage = "ClientNumber is required.";
                return false;
            }

            if (!(Regex.IsMatch(input, @"^\d{" + size + "}$")))
            {
                errMessage = "ClientNumber must be a" + size + "-digit number.";
                return false;
            }

            return true;
        }

        public static bool IsValidName(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if ((!(Char.IsLetter(input[i]))) && (!(Char.IsWhiteSpace(input[1]))))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
