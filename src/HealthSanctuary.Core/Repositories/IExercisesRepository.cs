using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthSanctuary.Core.Models;

namespace HealthSanctuary.Core.Repositories
{
    public interface IExercisesRepository
    {
        IQueryable<Exercise> GetQueryableExercises();

        Task<List<Exercise>> GetMany();

        Task<Exercise> GetOne(int id);

        void CreateOne(Exercise exercise);

        void UpdateOne(Exercise exercise);

        void DeleteOne(int id);

        Task SaveChanges();
    }
}
