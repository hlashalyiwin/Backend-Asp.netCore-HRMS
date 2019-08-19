using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{ 
    public class SaveRuleResponse: BaseResponse
    {
        public Rule Rule { get; private set; }

        private SaveRuleResponse(bool success, string message, Rule rule) : base(success, message)
        {
            Rule = rule;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="rule">Saved rule.</param>
        /// <returns>Response.</returns>
        public SaveRuleResponse(Rule rule) : this(true, string.Empty, rule)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveRuleResponse(string message) : this(false, message, null)
        { }
    }
    }
