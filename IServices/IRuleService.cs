using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.Models;


namespace Hr_Management_final_api.IServicess
{//return an enumeration of rule
    public interface IRuleService
    {
         Task<IEnumerable<Rule>> ListAsync();
           Task<Rule> GetByIdAsync(int id);       
        Task<SaveRuleResponse> SaveAsync(Rule rule);
        Task<SaveRuleResponse> UpdateAsync(int id, Rule rule);
        Task<SaveRuleResponse> DeleteAsync(int id);
    }
}