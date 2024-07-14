# PasswordRequirement

## Sample Usage
### Create Verifier Service
You can Create Class To Implement Verifier Service
```C#
public class MyPasswordVerifierService : IPasswordVerifierService
{
    /// <summary>
    /// Verifier Password By Combination Rules, if not valid will return list error
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<List<string>> VerifyAsync(UserData userData, CancellationToken cancellationToken = default)
    {
        var verifiers = new List<PasswordVerifier>();
        verifiers.Add(new VerifiedContainsLetterAndNumber());
        verifiers.Add(new VerifiedContainsLowerAndUpperCase());
        // Add Other Verifiers here
        
        var errorList = new List<string>();
        foreach (var verifier in verifiers)
        {
            var result = verifier.Verified(userData);
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
    
    public async Task<bool> ValidatePassword(UserData userData, CancellationToken cancellationToken = default) 
    {
        var errorResult = await _passwordVerifier.VerifyAsync(userData, cancellationToken);
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
    
    public async Task<bool> ValidatePassword(UserData userData, CancellationToken cancellationToken = default) 
    {
        var errorResult = await _passwordVerifier.VerifyAsync(userData, cancellationToken);
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
        var isValid = service.ValidatePassword(new UserData("Test")).Result;
        ...
    }
}
```