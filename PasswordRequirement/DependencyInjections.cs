#if NETFRAMEWORK
using Microsoft.Extensions.DependencyInjection;

namespace PasswordRequirement;

public static class DependencyInjections
{
    public static void AddPasswordRequirement<T>(this IServiceCollection services) where T : class, IPasswordVerificator
    {
        services.AddTransient<IPasswordVerificator, T>();
    }
}
#endif


