using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GitHubMonitorApp
{
    public static class GitHubMonitor
    {
        [FunctionName("GitHubMonitor")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function ,"get",  "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Github processed a push action.");
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            log.LogInformation($"BODY {requestBody}");
            string name = req.Query["name"];


            return new OkObjectResult($"Olla {name} ");
        }
    }
}
