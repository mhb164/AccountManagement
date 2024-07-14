using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SeedWork
{
    /// <summary>
    /// https://www.geeksforgeeks.org/validate-phone-numbers-with-country-code-extension-using-regular-expression/
    /// </summary>
    public static class MobileNumberValidator
    {
        private static readonly string _regexMatchPattern = @"^[+]{1}(?:[0-9\\-\\(\\)\\/\\.]\\s?){6,15}[0-9]{1}$";

        public static bool IsMobileNumber(this string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
                return false;

            try
            {
                return Regex.IsMatch(mobileNumber, _regexMatchPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch 
            {
                return false;
            }
        }
    }
}
