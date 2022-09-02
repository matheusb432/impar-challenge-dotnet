using System.Net;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using ImparApp.Application.Extensions;
using ImparApp.Application.Extensions.ViewModels;
using ImparApp.Domain.Models;

namespace ImparApp.Application.Services
{
    public abstract class Service
    {
        protected readonly IMapper Mapper;

        private ValidationResult _validationResult = null!;

        protected Service(IMapper mapper) => Mapper = mapper;

        protected OperationResult Error() => new OperationResult(_validationResult);

        protected OperationResult Error(HttpStatusCode statusCode) => new OperationResult(_validationResult, statusCode);

        protected OperationResult Error(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };
            return new OperationResult(new ValidationResult(failures), statusCode);
        }

        protected OperationResult Success(object? obj = null) => new OperationResult(obj);

        protected OperationResult Success(long id) => new OperationResult(new PostReturnViewModel(id));

        protected void NotifyError(string errorMessage)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };
            _validationResult = new ValidationResult(failures);
        }

        protected bool EntityIsValid<TV, TE>(TV validator, TE entity) 
            where TV : AbstractValidator<TE> 
            where TE : BaseEntity
        {
            var result = validator.Validate(entity);
            if (result.IsValid) return true;

            _validationResult = result;

            return false;
        }

        protected bool EntityIsValid<TV, TE>(TV validator, IEnumerable<TE> entities) 
            where TV : AbstractValidator<TE> 
            where TE : BaseEntity
        {
            foreach (var entity in entities)
            {
                var result = validator.Validate(entity);
                if (result.IsValid) continue;

                _validationResult = result;
                return false;
            }

            return true;
        }
    }
}
