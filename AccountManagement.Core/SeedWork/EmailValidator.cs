using System;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SeedWork
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
    /// </summary>
    public static class EmailValidator
    {
        private static readonly string _regexNormalizePattern = @"(@)(.+)$";
        private static readonly string _regexMatchPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, _regexNormalizePattern, DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                Regex.IsMatch(email, _regexMatchPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            try
            {
                var mailAddress = new MailAddress(email);
                return email.Equals(mailAddress.Address, StringComparison.InvariantCultureIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        // Examines the domain part of the email and normalizes it.
        private static string DomainMapper(Match match)
        {
            // Use IdnMapping class to convert Unicode domain names.
            var idn = new IdnMapping();

            // Pull out and process domain name (throws ArgumentException on invalid)
            var domainName = idn.GetAscii(match.Groups[2].Value);

            return match.Groups[1].Value + domainName;
        }

    }
}
