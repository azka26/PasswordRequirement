using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PasswordRequirement.Verificators
{
    public class VerifiedContainsLetterAndNumber : Verificator
    {
        public override string? Verified(string password, params object[] parameters)
        {
            var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9]).+$");
            if (regex.IsMatch(password)) return null;
            return string.Format(ErrorMessage);
        }

        protected override string ErrorMessage => "Password should contains combination letter and number.";
    }
}   