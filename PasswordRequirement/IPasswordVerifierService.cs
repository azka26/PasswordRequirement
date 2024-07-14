using System.Collections.Generic;

namespace PasswordRequirement;

public interface IPasswordVerifierService
{
    List<string> Verify(string password);
}