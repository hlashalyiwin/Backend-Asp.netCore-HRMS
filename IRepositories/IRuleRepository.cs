using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.IRepositories
{
    public interface IRuleRepository
    {
        //interface IRuleRepository for RuleRepository
    Task<IEnumerable<Rule>> ListAsync();
	Task AddAsync(Rule rule);

    Task<Rule> FindByIdAsync(int id);
	void Update(Rule rule);
    void Remove(Rule rule);
    }
    
}