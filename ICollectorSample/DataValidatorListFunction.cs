using System.Collections.Generic;
using ICollectorSample.Models;
using ICollectorSample.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace ICollectorSample
{
    public static class DataValidatorListFunction
	{
		[FunctionName("DataValidatorListFunction")]
		[return: Queue("defaultListProcessorQueue")]
		public static ListWrapper Run(
			[QueueTrigger("defaultListQueue")]ListWrapper listWrapper, 
			TraceWriter log)
		{
			log.Info($"Validating data");

			var validatorService = new ValidatorService();

			var response = new ListWrapper
			{
				Elements = new List<string>()
		
			};

			foreach (var element in listWrapper.Elements)
			{
				var isValidElement = validatorService.ValidateElement(element);

				if (isValidElement)
				{
					response.Elements.Add(element);
				}
			}

			log.Info($"Data validator function completed");

			return response;
		}
	}
}
