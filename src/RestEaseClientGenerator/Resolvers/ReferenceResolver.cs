using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace RestEaseClientGenerator.Resolvers
{
    internal class ExternalReferenceResolver
    {
        private IDictionary<string, OpenApiParameter> parameters = new ConcurrentDictionary<string, OpenApiParameter>();
        private IDictionary<string, OpenApiDocument> documents = new ConcurrentDictionary<string, OpenApiDocument>();

        private readonly string _directoryName;

        public ExternalReferenceResolver(string path)
        {
            _directoryName = Path.GetDirectoryName(path);
        }

        public OpenApiParameter ResolveAsOpenApiParameter(OpenApiReference reference)
        {
            if (!parameters.ContainsKey(reference.ReferenceV3))
            {
                var document = GetDocument(reference.ExternalResource);

                var localReference = new OpenApiReference()
                {
                    Id = reference.Id.Replace("parameters/", string.Empty),
                    Type = ReferenceType.Parameter
                };

                parameters[reference.ReferenceV3] = document.ResolveReference(localReference) as OpenApiParameter;
            }

            return parameters[reference.ReferenceV3];
        }

        private OpenApiDocument GetDocument(string path)
        {
            if (!documents.ContainsKey(path))
            {
                var reader = new OpenApiStreamReader();
                documents[path] = reader.Read(File.OpenRead(Path.Combine(_directoryName, path)), out _);
            }

            return documents[path];
        }
    }
}