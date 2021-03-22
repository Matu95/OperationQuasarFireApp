using Mess;
using Microsoft.Extensions.DependencyInjection;
using OperationQuasarFireApp.Services;

namespace OperationQuasarFireApp
{
    public static class Extensions
    {
        public static IMessBuilder AddServices(this IMessBuilder builder)
        {
            builder.Services.AddTransient<IMainService, MainService>();
            builder.Services.AddTransient<ILocationService, LocationService>();
            builder.Services.AddTransient<IMessageService, MessageService>();
            return builder;
        }
    }
}
