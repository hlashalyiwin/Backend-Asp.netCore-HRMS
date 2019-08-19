
using Hr_Management_final_api.Domain.Models;

namespace Hr_Management_final_api.Communication {
    public class SavePointResponse : BaseResponse {
        public Point Point { get; private set; }

        private SavePointResponse (bool success, string message, Point point) : base (success, message) {
            Point = point;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="point">Saved point.</param>
        /// <returns>Response.</returns>
        public SavePointResponse (Point point) : this (true, string.Empty, point) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SavePointResponse (string message) : this (false, message, null) { }
    }
}