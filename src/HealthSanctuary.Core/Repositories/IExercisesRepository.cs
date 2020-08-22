using System.Collections.Generic;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;

namespace HealthSanctuary.Core.Repositories
{
    public interface IExercisesRepository
    {
        Task<List<Exercise>> GetMany();

        Task<Exercise> GetOne(int id);

        void CreateOne(Exercise exercise);

        void UpdateOne(Exercise exercise);

        void DeleteOne(int id);

        Task SaveChanges();
    }
}
