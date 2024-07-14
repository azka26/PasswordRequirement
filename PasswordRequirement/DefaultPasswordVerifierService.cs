using System;
using System.Collections.Generic;
using PasswordRequirement.Verifiers;

namespace PasswordRequirement;

public class DefaultPasswordVerifierService : IPasswordVerifierService
{
    /// <summary>
    /// Verifier Password By Combination Rules, if not valid will return list error
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public List<string> Verify(string password)
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
            var result = verificator.Verified(password);
            if (string.IsNullOrEmpty(result)) continue;
            errorList.Add(result);
        }

        return errorList;
    }
}