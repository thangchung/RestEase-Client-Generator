﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGeneratorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();

            var azureRestStorageSettings = new GeneratorSettings
            {
                Namespace = "AzureRestStorage",
                ApiName = "AzureTableApi"
            };
            foreach (var file in generator.FromFile("Examples\\AzureRestStorage\\table.json", azureRestStorageSettings, out OpenApiDiagnostic diagnosticPetStoreOpenApi3))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/AzureRestStorage/{file.Path}/{file.Name}", file.Content);
            }


            // Corrupte enums
            var computerVisionSettings = new GeneratorSettings
            {
                SingleFile = true,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.ComputerVision",
                ApiName = "ComputerVision"
            };
            foreach (var file in generator.FromFile("Examples\\ComputerVision.json", computerVisionSettings, out var diagnosticComputerVision))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/ComputerVision/{file.Path}/{file.Name}", file.Content);
            }

            // TODO : `Action`
            //var mediaWikiRamlSettings = new GeneratorSettings
            //{
            //    Namespace = "RestEaseClientGeneratorConsoleApp.Examples.MediaWikiRaml",
            //    ApiName = "MediaWikiRaml"
            //};
            //foreach (var file in generator.FromFile("Examples\\MediaWiki.Raml", mediaWikiRamlSettings, out var diagnosticMMR))
            //{
            //    File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/MediaWikiRaml/{file.Path}/{file.Name}", file.Content);
            //}

            // TODO : `Action`
            // https://medium.com/raml-api/oas-raml-converter-quick-start-3a20664fa94a
            //var mediaWikiSettings = new GeneratorSettings
            //{
            //    Namespace = "RestEaseClientGeneratorConsoleApp.Examples.MediaWiki",
            //    ApiName = "MediaWiki",
            //    UseOperationIdAsMethodName = false
            //};
            //foreach (var file in generator.FromFile("Examples\\MediaWiki.json", mediaWikiSettings, out var diagnosticMM))
            //{
            //    File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/MediaWiki/{file.Path}/{file.Name}", file.Content);
            //}

            // Errors enums
            var iSettings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.Infura",
                ApiName = "Infura"
            };
            foreach (var file in generator.FromFile("Examples\\infura.yaml", iSettings, out OpenApiDiagnostic diagnosticInfura))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Infura/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreSettings = new GeneratorSettings
            {
                ArrayType = ArrayType.ICollection,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStore",
                ApiName = "PetStore",
                SupportExtensionXNullable = true,
                ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified = true
            };
            foreach (var file in generator.FromFile("Examples\\petstore.yaml", petStoreSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStore/{file.Path}/{file.Name}", file.Content);
            }

            var ramlSettings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.HelloWorldRaml",
                ApiName = "HelloWorldRaml"
            };
            foreach (var file in generator.FromFile("Examples\\helloworld.raml", ramlSettings, out var diagnosticHW))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/HelloWorldRaml/{file.Path}/{file.Name}", file.Content);
            }

            var wpSettings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.wpraml",
                ApiName = "wpraml",
                DefineSharedMethodQueryParametersOnInterface = true
            };
            foreach (var file in generator.FromFile("Examples\\wp.raml", wpSettings, out var diagnosticWPR))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/wpraml/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreOpenApi3Settings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302",
                ApiName = "PetStoreOpenApi3",
                GenerateFormUrlEncodedExtensionMethods = true,
                GenerateMultipartFormDataExtensionMethods = true,
                GenerateApplicationOctetStreamExtensionMethods = true,
                ApplicationOctetStreamType = ApplicationOctetStreamType.ByteArray,
                PreferredContentType = ContentType.ApplicationJson,
                DefineAllMethodHeadersOnInterface = true,
                MethodReturnType = MethodReturnType.Type,
                PreferredEnumType = EnumType.Enum
            };
            foreach (var file in generator.FromFile("Examples\\petstore-openapi3.json", petStoreOpenApi3Settings, out OpenApiDiagnostic diagnosticPetStoreOpenApi3))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStoreOpenApi302/{file.Path}/{file.Name}", file.Content);
            }
            
            //var drcSettings = new GeneratorSettings
            //{
            //    Namespace = "RestEaseClientGeneratorConsoleApp.Examples.Drc",
            //    ApiName = "Drc",
            //    ForceContentTypeToApplicationJson = true,
            //    UseOperationIdAsMethodName = false
            //};
            //foreach (var file in generator.FromStream(File.OpenRead("Examples\\drc.json"), drcSettings, out var diagnosticFormRecognizer))
            //{
            //    File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Drc/{file.Path}/{file.Name}", file.Content);
            //}

            var sharedQueryParamsWithExtensionMethodSettings = new GeneratorSettings
            {
                SingleFile = false,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.SharedQuery",
                ApiName = "SharedQuery",
                GenerateFormUrlEncodedExtensionMethods = true,
                GenerateMultipartFormDataExtensionMethods = true,
                GenerateApplicationOctetStreamExtensionMethods = true
            };
            foreach (var file in generator.FromFile("Examples\\SharedQueryParamsWithExtensionMethod.json", sharedQueryParamsWithExtensionMethodSettings, out OpenApiDiagnostic sharedDiag))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/SharedQuery/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreJsonSettings = new GeneratorSettings
            {
                SingleFile = true,
                ArrayType = ArrayType.IEnumerable,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson",
                ApiName = "PetStoreJson",
                UseDateTimeOffset = true,
                MethodReturnType = MethodReturnType.Type,
                MultipartFormDataFileType = MultipartFormDataFileType.Stream,
                ApiNamespace = "Test123",
                ModelsNamespace = "Modelz"
            };
            foreach (var file in generator.FromFile("Examples\\petstore.json", petStoreJsonSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStoreJson/{file.Name}", file.Content);
            }

            var cogSettings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.Cog",
                ApiName = "Cog",
                ForceContentTypeToApplicationJson = true
            };
            foreach (var file in generator.FromFile("Examples\\cognitive-services-personalizer.json", cogSettings, out var diagnosticCog))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Cog/{file.Path}/{file.Name}", file.Content);
            }

            // TODO : Events
            //var spSettings = new GeneratorSettings
            //{
            //    Namespace = "RestEaseClientGeneratorConsoleApp.Examples.SpeechServices",
            //    ApiName = "SpeechServices"
            //};
            //foreach (var file in generator.FromFile("Examples\\SpeechServices.json", spSettings, out var diagnosticSpeech))
            //{
            //    File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/SpeechServices/{file.Path}/{file.Name}", file.Content);
            //}

            // Errors enums
            var formSettings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2",
                ApiName = "FormRecognizerV2",
                SupportExtensionXNullable = true,
                PreferredSecurityDefinitionType = SecurityDefinitionType.Query
            };
            foreach (var file in generator.FromFile("Examples\\FormRecognizerV2.json", formSettings, out var diagnosticFormRecognizerV2))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/FormRecognizerV2/{file.Path}/{file.Name}", file.Content);
            }

            // PetStoreTests.Run().GetAwaiter().GetResult();

            PetStoreOpenApi3ApiTests.Run().GetAwaiter().GetResult();
        }
    }
}