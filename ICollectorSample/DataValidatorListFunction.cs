using System;
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
					log.Info("Valid element");
					response.Elements.Add(element);
				}
				else
				{
					log.Warning("Invalid element");
				}
			}

			log.Info($"Data validator function completed");

			return response;
		}
	}
}
