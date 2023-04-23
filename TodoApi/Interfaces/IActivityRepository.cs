using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Interfaces
{
    public interface IActivityRepository
    {
        Task<IEnumerable<ActivityModel>> GetAll();
        void Add(ActivityModel activity);
        void Update(ActivityModel activity);
        void Delete(string activityId);

    }
}
