using System.Text.RegularExpressions;

namespace PasswordRequirement.Verifiers;
public class VerifiedContainsLetterAndNumber : PasswordVerifier
{
    public override string? Verified(UserData userData, params object[] parameters)
    {
        var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9]).+$");
        if (regex.IsMatch(userData.Password)) return null;
        return string.Format(ErrorMessage);
    }

    protected override string ErrorMessage => "Password should contains combination letter and number.";
}