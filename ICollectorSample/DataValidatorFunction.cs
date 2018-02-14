using System.Collections.Generic;
using ICollectorSample.Models;
using ICollectorSample.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace ICollectorSample
{
    public static class DataValidatorFunction
	{
		[FunctionName("DataValidatorFunction")]
		[return: Queue("defaultProcessorQueue")]
		public static string Run(
			[QueueTrigger("defaultQueue")]string element, 
			TraceWriter log)
		{
			var validatorService = new ValidatorService();

			var isValidElement = validatorService.ValidateElement(element);

			if (isValidElement)
			{
				log.Info("Valid element");
				return element;
			}

			log.Warning("Invalid element");
			return null;
		}
	}
}
