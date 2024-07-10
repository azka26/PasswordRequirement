using System.Text.RegularExpressions;

namespace PasswordRequirement.Verificators
{
    public class VerifiedPattern : Verificator
    {
        public VerifiedPattern()
        {
            
        }

        public VerifiedPattern(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public VerifiedPattern(Regex pattern)
        {
            _pattern = pattern;
        }

        public VerifiedPattern(Regex pattern, string errorMessage)
        {
            _pattern = pattern;
            ErrorMessage = errorMessage;
        }
        
        public override string? Verified(string password, params object[] parameters)
        {
            if (_pattern.IsMatch(password)) return null;
            return string.Format(ErrorMessage, _pattern.ToString());
        }
        private readonly Regex _pattern = new Regex(@"[A-Za-z0-1\[\]~!@#$%^&*\-+_=?><]");
        protected override string ErrorMessage { get; } = "Password should match with pattern = {0}.";
    }
}