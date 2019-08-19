using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Context;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hr_Management_final_api.Domain.Repositories
{
    public class RuleRepository: BaseRepository, IRuleRepository
    { //to manage data from databases.
        public RuleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Rule>> ListAsync()
        {
            return await _context.Rules.ToListAsync();
        }
        public async Task AddAsync(Rule rule)
	    {
		await _context.Rules.AddAsync(rule);
	    }

        public async Task<Rule> FindByIdAsync(int id)
        {
            return await _context.Rules.FindAsync(id);
        }

        public void Update(Rule rule)
        {
            _context.Rules.Update(rule);
        }   
        public void Remove(Rule rule)
        {
	     _context.Rules.Remove(rule);
        }

            }
}