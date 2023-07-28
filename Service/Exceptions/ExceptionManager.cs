using FluentValidation.Results;

namespace Service.Exceptions
{
    public class ExceptionManager
    {
        public int? Code { get; set; }

        public string? Message { get; set; }

        public ICollection<ErrorValidation>? Errors { get; set; }

        public static ExceptionManager RequestError(int code, string message, ValidationResult validationResult)
        {
            return new ExceptionManager
            {
                Code = code,
                Message = message,
                Errors = validationResult.Errors.Select
                (x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ExceptionManager<T> RequestError<T>(int code, string message, ValidationResult validationResult)
        {
            return new ExceptionManager<T>
            {
                Code = code,
                Message = message,
                Errors = validationResult.Errors.Select
                (x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ExceptionManager<T> NotFound<T>(string message) => new ExceptionManager<T> { Code = 404, Message = message };
        public static ExceptionManager<T> BadRequest<T>(string message) => new ExceptionManager<T> { Code = 400, Message = message };
        public static ExceptionManager<T> Unauthorized<T>(string message) => new ExceptionManager<T> { Code = 401, Message = message };
        public static ExceptionManager<T> Forbidden<T>(string message) => new ExceptionManager<T> { Code = 403, Message = message };
        public static ExceptionManager<T> Ok<T>(T Data) => new ExceptionManager<T> { Code = 200, Data = Data };
        public static ExceptionManager<T> Created<T>(T Data) => new ExceptionManager<T> { Code = 201, Data = Data };
    }
    public class ExceptionManager<T> : ExceptionManager
    {
        public T Data { get; set; }
    }

}
