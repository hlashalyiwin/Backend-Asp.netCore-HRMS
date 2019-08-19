using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Hr_Management_final_api.Extensions
{ //ModelStateExtensions class for error message
    public static class ModelStateExtensions
    {  //Represents the state of an attempt to bind a posted form to an action method, which includes validation information.
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary) 
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }
    }
}