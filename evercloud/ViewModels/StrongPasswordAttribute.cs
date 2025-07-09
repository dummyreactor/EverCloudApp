using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace evercloud.ViewModels
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var password = value as string;
            if (string.IsNullOrEmpty(password)) return false;

            // Checks
            bool hasUpper = Regex.IsMatch(password, "[A-Z]");
            bool hasLower = Regex.IsMatch(password, "[a-z]");
            bool hasDigit = Regex.IsMatch(password, "[0-9]");
            bool hasSymbol = Regex.IsMatch(password, "[^a-zA-Z0-9]");

            return hasUpper && hasLower && hasDigit && hasSymbol;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.";
        }
    }
}
