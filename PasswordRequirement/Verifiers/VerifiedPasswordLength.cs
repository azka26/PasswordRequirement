
namespace PasswordRequirement.Verifiers;
public class VerifiedPasswordLength : PasswordVerifier
{
    private readonly int _minLength = 8;
    public VerifiedPasswordLength()
    {
            
    }

    public VerifiedPasswordLength(int minLength)
    {
        _minLength = minLength;
    }
        
    public VerifiedPasswordLength(int minLength, string errorMessage)
    {
        _minLength = minLength;
        ErrorMessage = errorMessage;
    }
        
    public override string? Verified(string password, params object[] parameters)
    {
        if (string.IsNullOrEmpty(password) || password.Length < _minLength)
        {
            return string.Format(ErrorMessage, _minLength.ToString());
        }

        return null;
    }

    protected override string ErrorMessage { get; } = "Minimum password length should be {0} character.";
}