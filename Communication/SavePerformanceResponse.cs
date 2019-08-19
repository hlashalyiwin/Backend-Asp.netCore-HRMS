using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication
{
    
        //SavePerformanceResponse class
        public class SavePerformanceResponse:BaseResponse
        {
            public Performance Performance { get; private set; }

            private SavePerformanceResponse(bool success, string message, Performance _performance) : base(success, message)
            {
                Performance = _performance;
            }

            /// <summary>
            /// Creates a success response.
            /// </summary>
            /// <param name="Performance">Saved Performance.</param>
            /// <returns>Response.</returns>
            public SavePerformanceResponse(Performance performance) : this(true, string.Empty, performance)
            {
                Performance = performance;
            }

            /// <summary>
            /// Creates am error response.
            /// </summary>
            /// <param name="message">Error message.</param>
            /// <returns>Response.</returns>
            public SavePerformanceResponse(string message) : this(false, message, null)
            { }
        }
}
