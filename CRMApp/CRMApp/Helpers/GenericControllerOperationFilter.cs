using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace CRMApp.Helpers
{
    public class GenericControllerOperationFilter 
    {
        //public void Apply(OpenApiOperation operation, OperationFilterContext context)
        //{
        //    if (context.ApiDescription.TryGetMethodInfo(out var methodInfo))
        //    {
                
        //        if (methodInfo.DeclaringType.IsGenericType && context.ApiDescription.ControllerAttributes().OfType<ApiExplorerSettingsAttribute>().Any())
        //        {
        //            // Generic kontrolcülerin Swagger belgelerini özelleştirin
        //            var typeArguments = methodInfo.DeclaringType.GetGenericArguments();
        //            var genericTypeName = methodInfo.DeclaringType.Name;
        //            var typeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
        //            var typeArgumentsString = string.Join(", ", typeArguments.Select(t => t.Name));
        //            operation.Summary = operation.Summary.Replace(typeName, $"{typeName}<{typeArgumentsString}>");
        //        }
        //    }
        //}
    }
}

