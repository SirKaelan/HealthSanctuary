using System.Threading.Tasks;
using HealthSanctuary.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HealthSanctuary.Web.Extensions
{
    public static class HostExtensions
    {
        public static async Task RunWithTasks(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var startupTasks = scope.ServiceProvider.GetServices<IStartupTask>();

                foreach (var task in startupTasks)
                {
                    await task.Execute();
                }
            }

            await host.RunAsync();
        }
    }
}
