using System.Linq;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers
{
    public abstract class BaseMapper
    {
        protected string DateTime => Settings.UseDateTimeOffset ? "DateTimeOffset" : "DateTime";

        protected readonly OpenApiDocument Document;
        protected readonly GeneratorSettings Settings;

        protected BaseMapper(OpenApiDocument document, GeneratorSettings settings)
        {
            Document = document;
            Settings = settings;
        }

        protected string MakeValidModelName(string name)
        {
            string last = name.Replace(" ", "").Split('.').Last();

            return last.ToValidIdentifier(CasingType.Pascal);
        }

        protected string MapArrayType(object value)
        {
            switch (Settings.ArrayType)
            {
                case ArrayType.IEnumerable:
                    return $"IEnumerable<{value}>";

                case ArrayType.ICollection:
                    return $"ICollection<{value}>";

                case ArrayType.IList:
                    return $"IList<{value}>";

                case ArrayType.List:
                    return $"List<{value}>";

                default:
                    return $"{value}[]";
            }
        }
    }
}