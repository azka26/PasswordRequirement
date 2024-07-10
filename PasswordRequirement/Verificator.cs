using System.Collections.Generic;

namespace PasswordRequirement;

public abstract class Verificator
{
    /// <summary>
    /// If Success Return Value Should Be Null or String.Empty
    /// </summary>
    /// <param name="password"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public abstract string? Verified(string password, params object[] parameters);
    protected abstract string ErrorMessage { get; }
}