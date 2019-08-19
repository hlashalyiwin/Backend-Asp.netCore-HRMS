
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{//interface IAbsenceRepository for AbsenceRepository
    public interface IAbsenceRepository
    {
     Task<IEnumerable<Absence>> ListAsync();
	 Task AddAsync(Absence absence);
    Task<IEnumerable<Absence>> FindByNameAsync(string name);

     Task<Absence> FindByIdAsync(int id);
	 void Update(Absence absence);
     void Remove(Absence absence);
    }
}