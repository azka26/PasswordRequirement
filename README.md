# PasswordRequirement

## Sample Usage
### Create Verifier Service
You can Create Class To Implement Verifier Service
```C#
using System;
using System.Collections.Generic;
using PasswordRequirement.Verifiers;

namespace MyPasswordVerifier;

public class MyPasswordVerifierService : IPasswordVerifierService
{
    /// <summary>
    /// Verifier Password By Combination Rules, if not valid will return list error
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public List<string> Verify(string password)
    {
        var verifiers = new List<PasswordVerifier>();
        verifiers.Add(new VerifiedContainsLetterAndNumber());
        verifiers.Add(new VerifiedContainsLowerAndUpperCase());
        // Add Other Verifiers here
        
        var errorList = new List<string>();
        foreach (var verifier in verifiers)
        {
            var result = verifier.Verified(password);
            if (string.IsNullOrEmpty(result)) continue;
            errorList.Add(result);
        }

        return errorList;
    }
}
```

### Inject On Startup (.NETCore)
```C#
services.AddPasswordRequirement<MyPasswordVerifierService>();
```

### Get Service (.NETCore)
```C#
public class MyService {
    private readonly IPasswordVerifierService _passwordVerifier;
    public MyService(IPasswordVerifierService passwordVerifier) {
        _passwordVerifier = passwordVerifier;
    }
    
    private readonly List<string> _errors = new List<string>();
    private void AddError(string error) 
    {
        _errors.Add(error);
    }
    public IReadOnlyList<string> Errors => _errors.AsReadOnly();
    
    public bool ValidatePassword(string password) 
    {
        var errorResult = _passwordVerifier.Verify(password);
        foreach (var error in errorResult)
        {
            AddError(error);
        }
        return Errors.Count == 0;
    }
}
```

### Using on NETFramework
```C#
public class MyService {
    private readonly IPasswordVerifierService _passwordVerifier;
    public MyService(IPasswordVerifierService passwordVerifier) {
        _passwordVerifier = passwordVerifier;
    }
    
    private readonly List<string> _errors = new List<string>();
    private void AddError(string error) 
    {
        _errors.Add(error);
    }
    public IReadOnlyList<string> Errors => _errors.AsReadOnly();
    
    public bool ValidatePassword(string password) 
    {
        var errorResult = _passwordVerifier.Verify(password);
        foreach (var error in errorResult)
        {
            AddError(error);
        }
        return Errors.Count == 0;
    }
}
```
```C#
public class Program {
    public void Main() 
    {
        var service = new MyService();
        var isValid = service.ValidatePassword("Test");
        ...
    }
}
```