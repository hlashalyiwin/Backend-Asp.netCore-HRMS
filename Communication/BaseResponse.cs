namespace Hr_Management_final_api.Communication
{
    public abstract class BaseResponse
    { 
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        //<param name="success">Used for success response </param>
        //<param name="meassage">Used for message response </param>

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        
    }
}