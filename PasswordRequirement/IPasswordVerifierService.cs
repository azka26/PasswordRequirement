using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordRequirement;

public interface IPasswordVerifierService
{
    Task<List<string>> VerifyAsync(UserData userData, CancellationToken cancellationToken = default);
}