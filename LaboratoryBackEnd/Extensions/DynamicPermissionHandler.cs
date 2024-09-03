using Microsoft.AspNetCore.Authorization;

namespace LaboratoryBackEnd.Extensions
{
    public class DynamicPermissionHandler : AuthorizationHandler<DynamicPermissionRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicPermissionRequirement requirement)
        {
            // Recupera o contexto HTTP para acessar a rota
            var httpContext = context.Resource as HttpContext;

            if (httpContext != null)
            {
                // Extrai o nome do controller da rota
                var controllerName = httpContext.GetRouteData().Values["controller"]?.ToString();

                // Build the expected permission claim like "ControllerName.Read" or "ControllerName.Write"
                bool hasReadPermission = false;
                bool hasWritePermission = false;
                var requiredPermission = $"{controllerName}.{requirement.PermissionType}";
                //se for escrita também busca a leitura
                if (requirement.PermissionType == "Write")
                {
                    hasWritePermission = context.User.HasClaim("Permission", requiredPermission);

                    if (hasWritePermission) { hasReadPermission = true; }
                }
                else
                {
                    //se a busca for por  leitura e tiver de escrita, tem também de leitura
                    var requiredPermissionTmp = $"{controllerName}.Write";
                    if (context.User.HasClaim("Permission", requiredPermissionTmp))
                        hasReadPermission = true;
                    else
                        hasReadPermission = context.User.HasClaim("Permission", requiredPermission);
                }


                // Check if the user has the required permission claim
                if (hasWritePermission
                    || hasReadPermission
                    )
                {
                    context.Succeed(requirement);  // Sucesso se a claim corresponder
                }
            }

            return Task.CompletedTask;
        }
    }
}
