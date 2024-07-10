using System.Collections.Generic;

namespace PasswordRequirement
{
    public interface IPasswordVerificator
    {
        List<string> Verify(string password);
    }
}