using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PasswordRequirement.Verifiers;

public class VerifiedSpecialCharacterPattern : PasswordVerifier
{
    public VerifiedSpecialCharacterPattern()
    {
            
    }

    public VerifiedSpecialCharacterPattern(string error)
    {
        ErrorMessage = error;
    }
        
    private readonly Regex _pattern = new Regex(@"[\[\]~!@#$%^&*\-+_=?><]");
    public override string? Verified(string password, params object[] parameters)
    {
        if (_pattern.Matches(password).Count > 0)
        {
            return null;
        }

        return string.Format(ErrorMessage, _pattern.ToString());
    }

    protected override string ErrorMessage { get; } = "Password should contains special character = {0}.";
}