using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SeedWork
{
    public static class TextCorrective
    {
        private static Regex _multipleSpacesToOneRegex = new Regex("[ ]{2,}", RegexOptions.None);

        public static string Rectify(this string input, bool trim = true, bool nullToEmpty = true, bool multipleSpacesToOne = true)
        {
            if (input is null)
                return nullToEmpty ? string.Empty
                                   : input;

            if (multipleSpacesToOne)
                input = _multipleSpacesToOneRegex.Replace(input, " ").Trim();

            if (trim)
                return input.Trim();

            return input;
        }
    }
}
