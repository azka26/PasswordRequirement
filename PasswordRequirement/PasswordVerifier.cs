using System.Collections.Generic;

namespace PasswordRequirement;

public abstract class PasswordVerifier
{
    /// <summary>
    /// If Success Return Value Should Be Null or String.Empty
    /// </summary>
    /// <param name="password"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public abstract string? Verified(UserData userData, params object[] parameters);
    protected abstract string ErrorMessage { get; }
}