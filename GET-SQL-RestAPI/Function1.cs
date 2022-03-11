using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace GET_SQL_RestAPI
{
    public class Information_Schema
    {
        public string TABLE_CATALOG { get; set; }
        public string TABLE_SCHEMA { get; set; }
        public string TABLE_NAME { get; set; }
        public string TABLE_TYPE { get; set; }

    }
    public static class SQLRestAPIGet
    {

        [FunctionName("SQLRestAPIGetSchema")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ServerShema/Schema")] HttpRequest req,
            ILogger log)
        {
            string keyVaultUrl = "https://secretsvault-dev.vault.azure.net/";

            // Create a new secret client using the default credential from Azure.Identity using environment variables previously set,
            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

            // Retrieve a secret using the secret client.
            KeyVaultSecret secret = client.GetSecret("azsql-connstring");

            log.LogInformation($"The Secret Name from the Vault is {secret.Name}");


            List<Information_Schema> data = new List<Information_Schema>();
            try
            {
                using (SqlConnection connection = new SqlConnection($"{secret.Value}"))
                {
                    connection.Open();
                    var query = @"select * from Information_schema.tables";
                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Information_Schema dataset = new Information_Schema()
                        {
                            TABLE_CATALOG = reader["TABLE_CATALOG"].ToString(),
                            TABLE_SCHEMA = reader["TABLE_SCHEMA"].ToString(),
                            TABLE_NAME = reader["TABLE_NAME"].ToString(),
                            TABLE_TYPE = reader["TABLE_TYPE"].ToString(),
                        };
                        data.Add(dataset);

                        data.Count()
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
            if (data.Count > 0)
            {
                return new OkObjectResult(data);
            }
            else
            {
                return new NotFoundResult();
            }

        }
    }
}
