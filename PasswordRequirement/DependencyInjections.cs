#if NETCOREAPP3_1_OR_GREATER

using Microsoft.Extensions.DependencyInjection;

namespace PasswordRequirement;

public static class DependencyInjections
{
    public static void AddPasswordRequirement<T>(this IServiceCollection services) where T : class, IPasswordVerifierService
    {
        services.AddTransient<IPasswordVerifierService, T>();
    }
}

#endif