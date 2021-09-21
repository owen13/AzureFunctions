using System.Threading.Tasks;
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace MyFirstFunction
{
    public static class QueueTrigger
    {
        [FunctionName("QueueTrigger")]
        public static void RunAsync(
            [QueueTrigger("http-trigger-queue", Connection = "AzureWebJobsStorage")] string myQueueItemInput,
            [Queue("queue-trigger-queue", Connection = "AzureWebJobsStorage")] out string myQueueItemCopy,
            [Queue("queue-trigger-queue-copy", Connection = "AzureWebJobsStorage")] out string myQueueItemCopy2,
            ILogger log)
        {
            log.LogInformation($"CopyQueueMessage function processed: {myQueueItemInput}");
            myQueueItemCopy = myQueueItemInput;
            myQueueItemCopy2 = $"COPY: {myQueueItemInput}";
        }
    }
}