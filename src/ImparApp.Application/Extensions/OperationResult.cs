using System.Net;
using FluentValidation.Results;

namespace ImparApp.Application.Extensions
{
    /// <summary>
    /// Modelo de resultado de operação em endpoints que facilita o tratamento de erros dos serviços
    /// </summary>
    public class OperationResult
    {
        public object? Content { get; private set; }
        public ValidationResult? Result { get; private set; }
        public bool IsValid => Result?.IsValid ?? false;
        public HttpStatusCode StatusCode { get; private set; }

        public OperationResult(ValidationResult? result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }

        public OperationResult(ValidationResult? result) => Result = result;

        public OperationResult(object? content)
        {
            Result = new ValidationResult();
            Content = content;
        }
    }
}
