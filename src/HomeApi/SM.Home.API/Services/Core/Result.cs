namespace SM.Home.API.Services.Core
{
    public class Result
    {
        private readonly OperationResult _operationResult;

        private Result(OperationResult operationResult, string message = default, object payload = default)
        {
            _operationResult = operationResult;
            Message = message;
            Payload = payload;
        }
        
        public bool IsSuccess => _operationResult == OperationResult.Success;

        public bool IsValidationFailed => _operationResult == OperationResult.ValidationFailed;

        public bool IsNotFound => _operationResult == OperationResult.NotFound;

        public string Message { get; }

        public object Payload { get; }

        public static Result Ok(object payload)
        {
            return new Result(OperationResult.Success, payload: payload);
        }

        public static Result ValidationFailed(string message)
        {
            return new Result(OperationResult.ValidationFailed, message: message);
        }

        public static Result NotFound(string message)
        {
            return new Result(OperationResult.NotFound, message: message);
        }
    }
}
