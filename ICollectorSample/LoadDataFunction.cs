using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ICollectorSample
{
    public static class LoadDataFunction
	{
        [FunctionName("LoadDataFunction")]
		public static async Task Run(
			[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "LoadDataFunction")]HttpRequestMessage req,
			[Queue("defaultQueue")]ICollector<string> collector,
			TraceWriter log)
        {
	        for (var i = 0; i < 1000; i++)
	        {
		        collector.Add(i.ToString());
	        }
		}
    }
}
