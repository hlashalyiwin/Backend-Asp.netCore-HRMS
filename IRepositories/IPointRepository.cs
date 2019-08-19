using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.IRepositories
{//interface IPointRepository for PointRepository
    public interface IPointRepository {
        Task<IEnumerable<Point>> ListAsync ();
        Task AddAsync (Point point);
        Task<Point> FindByIdAsync (int id);
        void Update (Point point);
        void Remove (Point point);
    }
}