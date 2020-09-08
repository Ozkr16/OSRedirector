using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UAParser;

namespace Zetill.Utils
{
    public static class OSRedirector
    {
        [FunctionName("OSRedirector")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var uaParser = Parser.GetDefault();

            var userAgent = req.Headers["User-Agent"].ToString();
            ClientInfo clientInfo = uaParser.Parse(userAgent);


            var redirectUrl = Environment.GetEnvironmentVariable($"RedirectUrl:{clientInfo.OS.Family}");

            return !string.IsNullOrWhiteSpace(redirectUrl) ?
                new RedirectResult(redirectUrl)
                : new RedirectResult(Environment.GetEnvironmentVariable($"RedirectUrl:Default"));
        }
    }
}
