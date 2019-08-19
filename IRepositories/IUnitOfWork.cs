using System.Threading.Tasks;

namespace  Hr_Management_final_api.Domain.IRepositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync(); 
    }
}