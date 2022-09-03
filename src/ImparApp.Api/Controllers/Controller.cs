using System.Net;
using FluentValidation.Results;
using ImparApp.Application.Extensions;
using ImparApp.Application.Extensions.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ImparApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class Controller : ControllerBase
    {
        protected ActionResult CustomResponse(OperationResult result)
        {
            if (!result.IsValid) return ErrorResponse(result);

            return Ok(result.Content ?? string.Empty);
        }

        private ActionResult ErrorResponse(OperationResult result)
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(MapErrorsToResponse(result.Result));

                default:
                    return BadRequest(MapErrorsToResponse(result.Result));
            }
        }

        private static ErrorViewModel MapErrorsToResponse(ValidationResult? validationResult)
            => validationResult is not null ? 
            new ErrorViewModel(validationResult.Errors.Select(e => e.ErrorMessage).ToList()) : 
            new ErrorViewModel();
    }
}
