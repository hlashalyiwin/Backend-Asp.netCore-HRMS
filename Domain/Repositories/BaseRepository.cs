
using Hr_Management_final_api.Domain.Context;

namespace Hr_Management_final_api.Domain.Repositories
{  //this class connect with Database 
    public class BaseRepository
    {
         protected readonly AppDbContext _context;

        //<param name="context">Use for database</param>
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}