using System;
using System.Collections.Generic;
using PasswordRequirement.Verificators;

namespace PasswordRequirement;

public class DefaultPasswordVeficator : IPasswordVerificator
{
    public List<string> Verify(string password)
    {
        var verificators = new List<Verificator>();
        var assembly = this.GetType().Assembly;
        foreach (var type in assembly.ExportedTypes)
        {
            if (type.Name == nameof(Verificator) || type.BaseType == null  || type.BaseType != typeof(Verificator)) continue;
            if (type == typeof(VerifiedPattern)) continue;
                
            var instance = (Activator.CreateInstance(type) as Verificator)!;
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