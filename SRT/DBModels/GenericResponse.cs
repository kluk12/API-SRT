using System.Text.Json;

namespace SRT.DBModels
{
   
    public class GenericResponse
    {
        public bool Success { get; set; }
        public bool UnhandledException { get; set; }
        public string Message { get; set; } = "";
        public string ExceptionMessage { get; set; } = "";
        public string InnerExceptionMessage { get; set; } = "";
        public string ExceptionStackTrace { get; set; } = "";


        public GenericResponse()
        {

        }

        public GenericResponse(string message = "")
        {
            Success = true;
            Message = message;
        }

        public void Error(Exception ex, string message)
        {
            Success = false;
            if (ex is ApiException)
            {
                this.Message = ex.Message;
                UnhandledException = false;
            }
            else if (ex is FluentValidation.ValidationException)
            {
                FluentValidation.ValidationException fvex = (ex as FluentValidation.ValidationException)!;
          
                this.Message = fvex.Errors.First().ErrorMessage;
                UnhandledException = false;
            }
            else
            {
                this.Message = message;
                UnhandledException = true;
                this.InnerExceptionMessage = ex?.InnerException?.Message ?? "";
            }
            ExceptionMessage = ex?.Message ?? "";
            ExceptionStackTrace = ex?.StackTrace ?? "";
        }

    }

    public class GenericResponse<T> : GenericResponse
    {
        public T? Data { get; set; }

        public GenericResponse(T data, string message = "") : base(message)
        {
            Data = data;
        }

        public GenericResponse(GenericResponse baseResponse, string serializedData)
        {
            Data = JsonSerializer.Deserialize<T>(serializedData);
            this.Success = baseResponse.Success;
            this.Message = baseResponse.Message;
            this.ExceptionMessage = baseResponse.ExceptionMessage;
            this.UnhandledException = baseResponse.UnhandledException;
            this.InnerExceptionMessage = baseResponse.InnerExceptionMessage;
        }

        public GenericResponse() : base("")
        {
        }
    }

    public class GenericResponse<T1, T2> : GenericResponse
    {
        public T1? Data1 { get; set; }
        public T2? Data2 { get; set; }

        public GenericResponse(T1 data1, T2 data2, string message = "") : base(message)
        {
            Data1 = data1;
            Data2 = data2;
        }

        public GenericResponse() : base("")
        {
        }
    }
    public class ApiException : Exception
    {
        public int? StatusCode { get; set; }

        public ApiException()
            : base()
        {
        }

        public ApiException(string message)
            : base(message)
        {
        }

        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApiException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }

}
