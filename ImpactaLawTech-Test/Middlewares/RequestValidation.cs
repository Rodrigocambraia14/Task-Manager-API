using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImpactaLawTech_Test.Middlewares
{
    internal sealed class RequestValidation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public RequestValidation(IValidator<TRequest> validator)
        {
            _validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = _validator.Validate(request).Errors;

            if (errors.Any())
                throw new ValidationException(errors);

            return next();
        }
    }
}
