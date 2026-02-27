using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProyect.Infrastructure.Shared
{
    public static class PhoneHelper
    {
        public static string FormatPhone(string? phone)
        {
            string cleaned = CleanPhone(phone);

            if (cleaned == "N/A")
                return "N/A";

            if (cleaned.Length == 10)
            {
                return $"({cleaned.Substring(0, 3)}) {cleaned.Substring(3, 3)}-{cleaned.Substring(6, 4)}";
            }
            else if (cleaned.Length == 11 && cleaned[0] == '1')
            {
                return $"+1 ({cleaned.Substring(1, 3)}) {cleaned.Substring(4, 3)}-{cleaned.Substring(7, 4)}";
            }
            else if (cleaned.Length == 7)
            {
                return $"{cleaned.Substring(0, 3)}-{cleaned.Substring(3, 4)}";
            }
            else
            {
                return cleaned;
            }
        }
        public static string CleanPhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return "N/A";

            if (phone.Contains('x') || phone.Contains('X'))
            {
                phone = phone.Split(new[] { 'x', 'X' })[0];
            }

            string cleaned = new string(phone.Where(char.IsDigit).ToArray()).Trim();

            return string.IsNullOrWhiteSpace(cleaned) ? "N/A" : cleaned;
        }
    }
}
