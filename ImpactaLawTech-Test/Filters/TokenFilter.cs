using ImpactaLawTech_Test.CustomAttributes;
using LawTech.CrossCutting.Helper;
using LawTech.Infra.Context.Persistence.Context.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImpactaLawTech_Test.Filters
{
    public class TokenFilter : ActionFilterAttribute
    {
        private readonly IDefaultContext defaultContext;
        private readonly IConfiguration config;

        public TokenFilter(IDefaultContext defaultContext,
                          IConfiguration config)
        {
            this.defaultContext = defaultContext;
            this.config = config;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var attributes = descriptor.MethodInfo.CustomAttributes;

            if (attributes.Any(a => a.AttributeType == typeof(TokenAttribute)))
            {
                var token = context.HttpContext.Request.Headers["Token"].ToString().Replace("Bearer ", string.Empty);

                var userLogin = this.defaultContext.UserLogins.FirstOrDefault(x => x.Token == token);

                if (userLogin is null)
                    context.Result = new UnauthorizedObjectResult(ContractResponse.InvalidContractResponse("Usuário não autorizado !"));
                else
                {
                    if (userLogin.ExpirationDate < DateTime.Now)
                        context.Result = new UnauthorizedObjectResult(ContractResponse.InvalidContractResponse("Sessão expirada, realize login novamente !"));
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
