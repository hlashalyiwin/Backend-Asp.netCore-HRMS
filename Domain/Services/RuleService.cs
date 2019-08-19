
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hr_Management_final_api.Communication;
using Hr_Management_final_api.Domain.IRepositories;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.IRepositories;
using Hr_Management_final_api.IServicess;



namespace Hr_Management_final_api.Domain.Services
{ //to get the list of objects..
    public class RuleService :IRuleService
    {	private readonly IRuleRepository _ruleRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RuleService(IRuleRepository ruleRepository, IUnitOfWork unitOfWork)
	{
		_ruleRepository = ruleRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<IEnumerable<Rule>> ListAsync()
	{
		return await _ruleRepository.ListAsync();
	}

	public async Task<SaveRuleResponse> SaveAsync(Rule rule)
	{
		try
		{
			await _ruleRepository.AddAsync(rule);
			await _unitOfWork.CompleteAsync();
			
			return new SaveRuleResponse(rule);
		}
		catch (Exception ex)
		{
			// Do some logging stuff
			return new SaveRuleResponse($"An error occurred when saving the rule: {ex.Message}");
		}
    }
    public async Task<SaveRuleResponse> UpdateAsync(int id, Rule rule)
   {
	var existingRule = await _ruleRepository.FindByIdAsync(id);

	if (existingRule == null)
		return new SaveRuleResponse("Rule not found.");

	existingRule.Rule_no = rule.Rule_no;
	existingRule.Description=rule.Description;

	try
	{
		_ruleRepository.Update(existingRule);
		await _unitOfWork.CompleteAsync();

		return new SaveRuleResponse(existingRule);
	}
	catch (Exception ex)
	{
		// Do some logging stuff
		return new SaveRuleResponse($"An error occurred when updating the rule: {ex.Message}");
	}
}


public async Task<SaveRuleResponse> DeleteAsync(int id)
{
	var existingRule = await _ruleRepository.FindByIdAsync(id);

	if (existingRule == null)
		return new SaveRuleResponse("Rule not found.");

	try
	{
		_ruleRepository.Remove(existingRule);
		await _unitOfWork.CompleteAsync();

		return new SaveRuleResponse(existingRule);
	}
	catch (Exception ex)
	{
		// Do some logging stuff
		return new SaveRuleResponse($"An error occurred when deleting the rule: {ex.Message}");
	}
}

        public async Task<Rule> GetByIdAsync(int id)
        {
             return await _ruleRepository.FindByIdAsync(id); 
        }
    }
    
    }