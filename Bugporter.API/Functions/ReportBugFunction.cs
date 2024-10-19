using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Bugporter.API.Functions
{
    public class ReportBugFunction
    {
        private readonly ILogger _logger;

        public ReportBugFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ReportBugFunction>();
        }

        [Function("ReportBugFunction")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bugs")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
