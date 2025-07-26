namespace template_webapi.Common.Response
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }

        public List<string>? Errors { get; set; }

        public static ApiResponse<T> Ok(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }

        public static ApiResponse<T> Ok(string message)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Message = message
            };
        }
        public static ApiResponse<T> Fail(string message, List<string>? errors = null)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = errors
            };
        }
    }
}
