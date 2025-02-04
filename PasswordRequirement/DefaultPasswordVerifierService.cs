using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PasswordRequirement.Verifiers;

namespace PasswordRequirement;

public class DefaultPasswordVerifierService : IPasswordVerifierService
{
    /// <summary>
    /// Verifier Password By Combination Rules, if not valid will return list error
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<List<string>> VerifyAsync(UserData userData, CancellationToken cancellationToken = default)
    {
        var verificators = new List<PasswordVerifier>();
        var assembly = this.GetType().Assembly;
        foreach (var type in assembly.ExportedTypes)
        {
            if (type.Name == nameof(PasswordVerifier) || type.BaseType == null  || type.BaseType != typeof(PasswordVerifier)) continue;
            if (type == typeof(VerifiedPattern)) continue;
                
            var instance = (Activator.CreateInstance(type) as PasswordVerifier)!;
            verificators.Add(instance);
        }

        var errorList = new List<string>();
        foreach (var verificator in verificators)
        {
            var result = verificator.Verified(userData);
            if (string.IsNullOrEmpty(result)) continue;
            errorList.Add(result);
        }

        return errorList;
    }
}