using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers
{
    internal class SecurityMapper : BaseMapper
    {
        public SecurityMapper(OpenApiDocument document, GeneratorSettings settings) : base(document, settings)
        {
        }

        public RestEaseSecurity Map()
        {
            if (Document.SecurityRequirements != null && Document.SecurityRequirements.Any())
            {
                return MapSwaggerVersion2();
            }

            if (Document.Components?.SecuritySchemes != null)
            {
                return MapOpenApiVersion3();
            }

            return null;
        }

        private RestEaseSecurity MapOpenApiVersion3()
        {
            if (Document.Components.SecuritySchemes.TryGetValue("api_key", out var openApiSecurityScheme))
            {
                return new RestEaseSecurity
                {
                    Definitions = Map(new[] { openApiSecurityScheme }),
                    SecurityVersionType = SecurityVersionType.OpenApi3
                };
            }

            return null;
        }

        private RestEaseSecurity MapSwaggerVersion2()
        {
            var openApiSecuritySchemes = Document.SecurityRequirements
                .Select(sr => sr.Keys.FirstOrDefault())
                .Where(k => k != null);

            return new RestEaseSecurity
            {
                Definitions = Map(openApiSecuritySchemes),
                SecurityVersionType = SecurityVersionType.Swagger2
            };
        }

        private ICollection<RestEaseSecurityDefinition> Map(IEnumerable<OpenApiSecurityScheme> openApiSecuritySchemes)
        {
            var definitions = new List<RestEaseSecurityDefinition>();
            foreach (var openApiSecurityScheme in openApiSecuritySchemes)
            {
                string name = openApiSecurityScheme.Name ?? openApiSecurityScheme.Description ?? "RestEaseClientGeneratorSecurityName";
                var restEaseSecurityDefinition = new RestEaseSecurityDefinition
                {
                    Name = name,
                    IdentifierName = name.ToValidIdentifier(CasingType.Pascal)
                };

                switch (openApiSecurityScheme.In)
                {
                    case ParameterLocation.Header:
                        restEaseSecurityDefinition.Type = SecurityDefinitionType.Header;
                        break;

                    case ParameterLocation.Query:
                        restEaseSecurityDefinition.Type = SecurityDefinitionType.Query;
                        break;
                }

                definitions.Add(restEaseSecurityDefinition);
            }

            return definitions;
        }
    }
}