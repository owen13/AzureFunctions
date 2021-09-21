using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyFirstFunction
{
    public static class TweetSentimentFunction
    {
        [FunctionName("TweetSentimentFunction")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("TweetSentimentFunction Triggered");
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            return new OkObjectResult(requestBody);
            
            //  
            
            // dynamic score = JsonConvert.DeserializeObject(requestBody);
            //
            // string value = "Positive";
            // if (score < .3)
            //     value = "Negative";
            // else if (score < .6)
            //     value = "Neutral";
            //
            //
            // return !string.IsNullOrWhiteSpace(requestBody)
            //     ? (ActionResult) new OkObjectResult(value)
            //     : new BadRequestObjectResult("Pass a sentiment score in the request body.");
            
        }
    }
}