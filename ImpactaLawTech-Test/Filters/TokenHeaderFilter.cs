using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ImpactaLawTech_Test.Filters
{
    public class TokenHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Tags.Any(x => x.Name == "Token"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    AllowEmptyValue = false,
                    Name = "token",
                    In = ParameterLocation.Header,
                    Required = false,
                });
            }

        }
    }
}
