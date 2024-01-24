using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Contoso;

public class SolarPanelOutput
{
    [ServiceBusOutput("nimbusnetworks", Connection = "ServiceBusConnection")]
    public SolarPanel NimbusNetworks { get; set; }

    [ServiceBusOutput("quantum-quill", Connection = "ServiceBusConnection")]
    public SolarPanel QuantumQuill { get; set; }    

    [ServiceBusOutput("vortex-dynamics", Connection = "ServiceBusConnection")]
    public SolarPanel VortexDynamics { get; set; }      

    public HttpResponseData HttpResponseData { get; set; }  
}