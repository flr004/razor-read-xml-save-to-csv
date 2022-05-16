using System;
using System.Text.RegularExpressions;

namespace ReadFromFactoryAndSaveCSV.Extensions
{
    public static class StringExtensions
    {
        public static string StripHTML(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}