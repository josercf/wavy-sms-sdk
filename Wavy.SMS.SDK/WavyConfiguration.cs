using Microsoft.Extensions.DependencyInjection;
using System;

namespace Wavy.SMS.SDK
{
    public static class WavyConfiguration
    {
        public static void AddWavySMSClient(this IServiceCollection services, Action<WavySMSOptions> config)
        {
            services.Configure(config);
            services.AddScoped<ISMSSender, SMSSender>();
        }
    }
}
