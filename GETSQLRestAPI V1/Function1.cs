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

namespace GETSQLRestAPI
{
    public class TaskModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
    public static class Function1
    {

        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "datasets")] HttpRequest req,
            ILogger log)
        {
            string keyVaultUrl = "https://secretsvault-dev.vault.azure.net/";

            // Create a new secret client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

            // Retrieve a secret using the secret client.
            KeyVaultSecret secret = client.GetSecret("azsql-connstring");

            log.LogInformation($"The Secret Name from the Vault is {secret.Name}");

            //List object of TaskModel Class to, tasklist is an object that stores the list objects returned from query in the taskmodel formatt
            List<TaskModel> taskList = new List<TaskModel>();
            try
            {   //Connect to SQL connection string
                using (SqlConnection connection = new SqlConnection($"{secret.Value}"))
                {   //Open Connection to the DB
                    connection.Open();
                    var query = @"Select * from TaskList";
                    //create SQL command object
                    SqlCommand command = new SqlCommand(query, connection);
                    //wait for sql query to execute & read data async
                    var reader = await command.ExecuteReaderAsync();

                    //While the reader reads
                    while (reader.Read())
                    {
                        //create a dataset object that will store the data returned
                        TaskModel task = new TaskModel()
                        {
                            //left(is the id defined on the task model pub class, right(the data returned from the sql query))
                            Id = (int)reader["Id"],
                            Description = reader["Description"].ToString(),
                            CreatedOn = (DateTime)reader["CreatedOn"],
                            IsDone = (bool)reader["IsDone"]
                        };

                        //whatever is returned from the task object, add it to the tasklist List
                        taskList.Add(task);
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
