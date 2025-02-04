using System.Text.RegularExpressions;

namespace PasswordRequirement.Verifiers;
public class VerifiedContainsLowerAndUpperCase : PasswordVerifier
{
    public override string? Verified(UserData userData, params object[] parameters)
    {
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z]).+$");
        if (regex.IsMatch(userData.Password)) return null;
        return string.Format(ErrorMessage);
    }

    protected override string ErrorMessage => "Password should contains combination lower and upper case.";
}