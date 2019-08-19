//Created by Sai Nay Lynn
//Created date is 21.6.2019

using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Domain.IRepositories {
    //TaskedRepository interface
    //interface ITaskedRepository for TaskedRepository
    public interface ITaskedRepository
    {
        Task<IEnumerable<Tasked>> ListAsync ();
        Task AddAsync (Tasked tasked);
        Task<Tasked> FindByIdAsync (int id);
        void Update (Tasked tasked);
        void Remove (Tasked tasked);
    }
}