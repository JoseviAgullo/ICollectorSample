using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ICollectorSample.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ICollectorSample
{
    public static class LoadListDataFunction
	{
        [FunctionName("LoadListDataFunction")]
        [return: Queue("defaultListQueue")]
		public static async Task<ListWrapper> Run(
			[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, 
			TraceWriter log)
        {
			var response = new ListWrapper
	        {
		        Elements = new List<string>()
	        };

	        for (var i = 0; i < 1000; i++)
	        {
		        response.Elements.Add(i.ToString());
	        }

	        return response;
		}
    }
}
