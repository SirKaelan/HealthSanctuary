using System.Threading.Tasks;

namespace HealthSanctuary.Core.Services
{
    public interface IStartupTask
    {
        Task Execute();
    }
}
