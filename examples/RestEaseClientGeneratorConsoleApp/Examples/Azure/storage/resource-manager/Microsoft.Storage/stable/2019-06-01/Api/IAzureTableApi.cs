using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace AzureRestStorage.Api
{
    /// <summary>
    /// The Azure Storage Management API.
    /// </summary>
    public interface IAzureTableApi
    {
        [Query("Azure Active Directory OAuth2 Flow")]
        string AzureActiveDirectoryOAuth2Flow { get; set; }

        [Query("api-version")]
        string ApiVersion { get; set; }

        /// <summary>
        /// TableServicesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices")]
        Task TableServicesListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// TableServicesSetServiceProperties (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/{tableServiceName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/{tableServiceName}")]
        [Header("Content-Type", "application/json")]
        Task TableServicesSetServicePropertiesAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// TableServicesGetServiceProperties (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/{tableServiceName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/{tableServiceName}")]
        Task TableServicesGetServicePropertiesAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// TableCreate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}")]
        Task TableCreateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// TableUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}")]
        Task TableUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// TableGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}")]
        Task TableGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// TableDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}")]
        Task TableDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// TableList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables")]
        Task TableListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);
    }
}
