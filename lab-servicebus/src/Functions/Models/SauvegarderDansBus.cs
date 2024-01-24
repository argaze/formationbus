using System.Net;
using System.Xml.Serialization;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Contoso
{
    public class SauvergarderDansBus
    {
        private readonly ILogger _logger;

        public SauvergarderDansBus(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SauvergarderDansBus>();
        }

        [Function("SauvergarderDansBus")]
        public async Task<SolarPanelOutput> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            if (req.Body is null)
            {
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                errorResponse.WriteString("Request body is null.");
                return new SolarPanelOutput
                {
                    HttpResponseData = errorResponse
                };
            }

            try
            {
                SolarPanel panel = await req.ReadFromJsonAsync<SolarPanel>();
                                                
                var output = new SolarPanelOutput
                {
                    NimbusNetworks = panel,
                    QuantumQuill = panel,
                    VortexDynamics = panel,
                    HttpResponseData = req.CreateResponse(HttpStatusCode.OK)
                };
                
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deserializing request body.");
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                errorResponse.WriteString("Invalid request body.");
                return new SolarPanelOutput
                {
                    HttpResponseData = errorResponse
                };
            }
        }
    }
}