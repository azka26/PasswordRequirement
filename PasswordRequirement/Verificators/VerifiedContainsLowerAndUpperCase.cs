using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PasswordRequirement.Verificators
{
    public class VerifiedContainsLowerAndUpperCase : Verificator
    {
        public override string? Verified(string password, params object[] parameters)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z]).+$");
            if (regex.IsMatch(password)) return null;
            return string.Format(ErrorMessage);
        }

        protected override string ErrorMessage => "Password should contains combination lower and upper case.";
    }
}