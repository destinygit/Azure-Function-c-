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


namespace SQLRestAPI
{
    public class Employeestbl
    {
        public int empid { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string title { get; set; }
        public string titleofcourtesy { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime hiredate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public int postalcode { get; set; }
        public string country { get; set; }

        public string phone { get; set; }
        public int mgrid { get; set; }
    }
    public static class SQLRestAPIGet
    {

        [FunctionName("SQLRestAPIGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SQLDatasets")] HttpRequest req,
            ILogger log)
        {
            string keyVaultUrl = "https://az-kv-mdl-dev-01-san-01.vault.azure.net/";

            // Create a new secret client using the default credential from Azure.Identity using environment variables previously set,
            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

            // Retrieve a secret using the secret client.
            KeyVaultSecret secret = client.GetSecret("azuresql-connstring-01");

            log.LogInformation($"The Secret from the Vault is {secret.Name}, {secret.Value}");


            List<Employeestbl> data = new List<Employeestbl>();
            try
            {
                using (SqlConnection connection = new SqlConnection($"{secret.Value}"))
                {   
                    connection.Open();
                    var query = @"Select * from Employees";
                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {   
                        Employeestbl dataset = new Employeestbl()
                        {
                            empid = (int)reader["empid"],
                            lastname = reader["lastname"].ToString(),
                            firstname = reader["firstname"].ToString(),
                            title = reader["title"].ToString(),
                            titleofcourtesy = reader["titleofcourtesy"].ToString(),
                            birthdate = (DateTime)reader["birthdate"],
                            hiredate = (DateTime)reader["hiredate"],
                            address = reader["address"].ToString(),
                            city = reader["city"].ToString(),
                            region = reader["region"].ToString(),
                            postalcode = (int)reader["postalcode"],
                            country = reader["country"].ToString(),
                        };
                        data.Add(dataset);
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
            if (taskList.Count > 0)
            {
                return new OkObjectResult(taskList);
            }
            else
            {
                return new NotFoundResult();
            }

        }
    }
}
