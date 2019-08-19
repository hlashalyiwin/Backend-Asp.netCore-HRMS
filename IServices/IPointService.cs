using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IServices {
//return an enumeration of point
    public interface IPointService {
        Task<IEnumerable<Point>> ListAsync ();
        Task<Point> GetByIdAsync (int id);
        Task<SavePointResponse> SaveAsync (Point point);
        Task<SavePointResponse> UpdateAsync (int id, Point point);
        Task<SavePointResponse> DeleteAsync (int id);
    }

}