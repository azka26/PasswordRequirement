using System.Collections.Generic;

namespace PasswordRequirement;

public class UserData
{
    public UserData(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public UserData(string password)
    {
        Password = password;
    }
    
    public string UserName { get; }
    public string Password { get; }
    public Dictionary<string, object> Parameters { get; } = new Dictionary<string, object>();
}