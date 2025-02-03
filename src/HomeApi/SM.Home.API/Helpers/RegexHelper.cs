using System.Text.RegularExpressions;

namespace SM.Home.API.Helpers
{
    public static class RegexHelper
    {
        public static readonly Regex EmailValidationRegex = new(pattern: "^[A-Za-z0-9@._-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static readonly Regex AtLeastOneCapitalSymbol = new(pattern: "[A-Z]+", options: RegexOptions.Compiled);
        public static readonly Regex AtLeastOneNonSymbol = new(pattern: "(\\W)+", options: RegexOptions.Compiled);
    }
}
