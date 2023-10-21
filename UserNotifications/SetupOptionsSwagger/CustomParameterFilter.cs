using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace UserNotifications.SetupOptionsSwagger
{
    internal class CustomParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            IEnumerable<SwaggerParameterAttribute>? parameterAttributes = null;

            if (context.PropertyInfo != null)
            {
                parameterAttributes = context.PropertyInfo.GetCustomAttributes<SwaggerParameterAttribute>();
            }
            else if (context.ParameterInfo != null)
            {
                parameterAttributes = context.ParameterInfo.GetCustomAttributes<SwaggerParameterAttribute>();
            }
            if (parameterAttributes != null && parameterAttributes.Any())
            {
                AddExample(parameter, parameterAttributes);
            }
        }

        private void AddExample(OpenApiParameter parameter,
            IEnumerable<SwaggerParameterAttribute> parameterAttributes)
        {
            foreach (var item in parameterAttributes)
            {
                var exemple = new OpenApiExample
                {
                    Value = new Microsoft.OpenApi.Any.OpenApiString(item.Value)
                };
                parameter.Examples.Add(item.Name, exemple);
            }

        }
    }
}
